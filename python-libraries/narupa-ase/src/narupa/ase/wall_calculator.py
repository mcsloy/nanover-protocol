# Copyright (c) Intangible Realities Lab, University Of Bristol. All rights reserved.
# Licensed under the GPL. See License.txt in the project root for license information.

"""
ASE calculator that implement a wall around the simulation box.

The wall avoids particle to fly out of the box in non-periodic system. Instead,
the particles bounced against the wall.
"""

from typing import Optional
import numpy as np
from ase.calculators.calculator import Calculator, all_changes
from ase import Atoms


class VelocityWallCalculator(Calculator):
    def __init__(
            self,
            calculator: Optional[Calculator] = None,
            atoms: Optional[Atoms] = None,
            **kwargs
    ):
        super().__init__(**kwargs)
        self._calculator = calculator
        self.implemented_properties = ('energy', 'forces')
        if self._calculator is not None:
            self.implemented_properties = tuple(
                set(self.implemented_properties)
                | set(self._calculator.implemented_properties)
            )

    def calculate(self, atoms: Atoms = None, properties=('energy', 'forces'),
                  system_changes=all_changes):
        if atoms is None:
            raise ValueError(
                'No ASE atoms supplied to IMD calculation, '
                'and no ASE atoms supplied with initialisation.'
            )

        energy = 0.0
        forces = np.zeros((len(atoms), 3))
        if self._calculator is not None:
            self._calculator.calculate(atoms, properties, system_changes)
            for key, value in self._calculator.results.items():
                self.results[key] = value
        self.results['energy'] = energy
        self.results['forces'] = forces

        self._bounce_atoms(atoms)

    def _bounce_atoms(self, atoms: Atoms):
        # TODO: fail if there is no box defined.
        # TODO: fail if the box is not orthorhombic.
        # TODO: fail if the box volume is 0.
        box = atoms.cell
        positions = atoms.get_positions()
        velocities = atoms.get_velocities()
        for dimension in range(3):
            box_max = box[dimension][dimension]
            left = np.logical_and(positions[:, dimension] <= 0,
                                  velocities[:, dimension] < 0)
            right = np.logical_and(positions[:, dimension] >= box_max,
                                   velocities[:, dimension] > 0)
            mask = np.logical_or(left, right)
            velocities[mask, dimension] *= -1
        atoms.set_velocities(velocities)
    
    @property
    def topology(self):
        # TODO: this property is very ad hoc. I need a better solution.
        return self._calculator.topology