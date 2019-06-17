import time
from narupa.lammps import LammpsHook


# Test call of the routine when running outside of lammps
def main():
    h = LammpsHook()
    print("Starting Trajectory Server")
    while True:
        h.lammps_hook()
        print("FRAME STUFF", h.frame_index, h.frame_data.raw)
        time.sleep(1.0 / 10.0)


if __name__ == '__main__':
    main()