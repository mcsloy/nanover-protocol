import numpy as np
from MDAnalysis import Universe
from MDAnalysis.topology.guessers import guess_atom_element

from narupa.trajectory import FrameData

element_index = {
    'H': 1,
    'C': 6,
    'N': 7,
    'O': 8,
    'S': 16
}


def mdanalysis_to_frame_data(u: Universe, topology=True, positions=True) -> FrameData:
    frame_data = FrameData()

    if topology:
        frame_data.residue_names = u.residues.resnames
        frame_data.residue_chains = u.residues.segindices
        frame_data.particle_names = u.atoms.names
        elements = [element_index[guess_atom_element(name)] for name in u.atoms.names]
        frame_data.particle_elements = elements
        frame_data.particle_residues = u.atoms.resids
        frame_data.bond_pairs = u.atoms.bonds.indices

    if positions:
        frame_data.particle_positions = u.atoms.positions * 0.1

    return frame_data
