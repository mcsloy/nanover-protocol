import time

import pytest
import numpy as np
from ase import Atoms
from ase.calculators.lj import LennardJones
from narupa.imd.imd_client import ImdClient, delayed_generator
from narupa.imd.imd_server import ImdServer
from narupa.ase.imd_calculator import ImdCalculator, get_periodic_box_lengths
from narupa.imd.interaction import Interaction

EV_PER_KJMOL = 0.01036


def co_atoms():
    d = 1.1
    co = Atoms('CO', positions=[(0, 0, 0), (0, 0, d)],
               cell=[2, 2, 2],
               pbc=[1, 1, 1])
    return co


@pytest.fixture
def atoms():
    return co_atoms()


@pytest.fixture
def interact_c():
    interaction = Interaction(position=[1, 0, 0], particles=[0], scale=100., interaction_type='spring')
    return interaction


@pytest.fixture
def imd_calculator_co():
    server = ImdServer(address=None, port=None)
    atoms = co_atoms()
    calculator = LennardJones()
    imd_calculator = ImdCalculator(server.service, calculator, atoms)
    yield imd_calculator, atoms
    server.close()


@pytest.fixture
def imd_calculator_no_atoms():
    server = ImdServer(address=None, port=None)
    calculator = LennardJones()
    imd_calculator = ImdCalculator(server.service, calculator)
    yield imd_calculator
    server.close()


@pytest.fixture
def imd_client():
    client = ImdClient(address='localhost', port=54322)
    yield client
    client.close()


def test_imd_calculator_no_interactions(imd_calculator_co):
    imd_calculator, atoms = imd_calculator_co
    properties = ('energy', 'forces')
    imd_calculator.calculator.calculate(atoms=atoms, properties=properties)
    expected_results = imd_calculator.calculator.results
    imd_calculator.calculate()
    results = imd_calculator.results
    for key in results:
        assert np.allclose(results[key], expected_results[key])


def test_imd_calculator_one_dimension_pbc(imd_calculator_co):
    imd_calculator, atoms = imd_calculator_co
    atoms.set_pbc((True, False, False))
    with pytest.raises(NotImplementedError):
        imd_calculator.calculate()


def test_imd_calculator_no_pbc(imd_calculator_co):
    imd_calculator, atoms = imd_calculator_co
    atoms.set_pbc((False, False, False))
    assert get_periodic_box_lengths(atoms) is None


def test_imd_calculator_not_orthorhombic(imd_calculator_co):
    imd_calculator, atoms = imd_calculator_co
    atoms.set_cell([1, 1, 1, 45, 45, 45])
    with pytest.raises(NotImplementedError):
        imd_calculator.calculate()


def test_imd_calculator_late_atoms(imd_calculator_no_atoms, atoms):
    """
    tests that the imd calculator works if atoms supplied after initialisation.
    """
    imd_calculator_no_atoms.calculate(atoms=atoms)


def test_imd_calculator_no_atoms(imd_calculator_no_atoms):
    """
    tests that the imd calculator throws an exception if no atoms are supplied.
    """
    with pytest.raises(ValueError):
        imd_calculator_no_atoms.calculate()


@pytest.mark.parametrize("position, imd_energy",
                         [([1, 0, 0], -1),
                          ([3, 0, 0], -1),
                          ([-1, 0, 0], -1),
                          ([0, 1, 0], -1),
                          ([0, 3, 0], -1),
                          ([0, -1, 0], -1),
                          ([0, 0, 1], -1),
                          ([0, 0, 3], -1),
                          ([0, 0, -1], -1),
                          ([5, 0, 0], -1),
                          ])
def test_one_interaction(position, imd_energy, imd_calculator_co, interact_c, imd_client):
    """
    tests an interaction in several different positions, including periodic boundary positions.
    """
    imd_calculator, atoms = imd_calculator_co
    properties = ('energy', 'forces')
    imd_calculator.calculator.calculate(atoms=atoms, properties=properties)
    internal_energy = imd_calculator.calculator.results['energy']

    interact_c.position = position
    imd_client.publish_interactions_async(delayed_generator([interact_c] * 10, delay=0.01))

    time.sleep(0.02)

    assert len(imd_calculator.interactions) == 1
    expected_imd_energy_kjmol = interact_c.scale * imd_energy * atoms.get_masses()[0]
    expected_imd_energy = expected_imd_energy_kjmol * EV_PER_KJMOL
    expected_energy = internal_energy + expected_imd_energy

    imd_calculator.calculate()
    results = imd_calculator.results
    assert np.allclose(results['energy'], expected_energy)
