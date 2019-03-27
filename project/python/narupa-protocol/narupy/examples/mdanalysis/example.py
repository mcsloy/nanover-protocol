import MDAnalysis
from MDAnalysis.tests.datafiles import PSF, DCD  # test trajectory

u = MDAnalysis.Universe(PSF, DCD)  # always start with a Universe

import time

from narupy.trajectory.frame_server import FrameServer
from narupy.mdanalysis import mdanalysis_to_topology_data, mdanalysis_to_frame_data


frameServer = FrameServer(address='localhost', port=54321)

topology_data = mdanalysis_to_topology_data(u)

frame_index = 0
frameServer.send_topology(frame_index, topology_data)

print("Starting Trajectory Server")

while True:

    for frame in u.trajectory:
        frame_data = mdanalysis_to_frame_data(u)

        frameServer.send_frame(frame_index, frame_data)
        time.sleep(1.0 / 30.0)
        frame_index = frame_index + 1
