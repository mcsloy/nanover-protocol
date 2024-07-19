"""
Command line interface for nanover.omni.
"""

import time
import textwrap
import argparse
from contextlib import contextmanager
from glob import glob
from typing import Iterable

from nanover.omni import OmniRunner
from nanover.omni.openmm import OpenMMSimulation
from nanover.omni.ase_omm import ASEOpenMMSimulation
from nanover.omni.playback import PlaybackSimulation
from nanover.omni.record import record_from_server


def handle_user_arguments(args=None) -> argparse.Namespace:
    """
    Parse the arguments from the command line.

    :return: The namespace of arguments read from the command line.
    """
    description = textwrap.dedent(
        """\
    Multi-simulation server for NanoVer
    """
    )
    parser = argparse.ArgumentParser(description=description)

    parser.add_argument(
        "--omm",
        dest="openmm_xml_entries",
        action="append",
        nargs="+",
        default=[],
        metavar="PATH",
        help="Simulation to run via OpenMM (XML format)",
    )

    parser.add_argument(
        "--ase-omm",
        dest="ase_xml_entries",
        action="append",
        nargs="+",
        default=[],
        metavar="PATH",
        help="Simulation to run via ASE OpenMM (XML format)",
    )

    parser.add_argument(
        "--playback",
        dest="recording_entries",
        action="append",
        nargs="+",
        default=[],
        metavar="PATH",
        help="Recorded session to playback (one or both of .traj and .state)",
    )

    parser.add_argument(
        "--record",
        dest="record_to_path",
        nargs="?",
        default=None,
        const="",
        metavar="PATH",
        help="Record trajectory and state to files.",
    )

    parser.add_argument(
        "--rich",
        action="store_true",
        default=False,
        help="Provide an interactive rich interface in the terminal.",
    )

    parser.add_argument(
        "-n",
        "--name",
        help="Give a friendly name to the server.",
    )
    parser.add_argument("-p", "--port", type=int, default=None)
    parser.add_argument("-a", "--address", default=None)

    arguments = parser.parse_args(args)
    return arguments


def get_all_paths(path_sets: Iterable[Iterable[str]]):
    for paths in path_sets:
        for pattern in paths:
            for path in glob(pattern, recursive=True):
                yield path


@contextmanager
def initialise_runner(arguments: argparse.Namespace):
    with OmniRunner.with_basic_server(
        name=arguments.name,
        address=arguments.address,
        port=arguments.port,
    ) as runner:
        for paths in arguments.recording_entries:
            runner.add_simulation(PlaybackSimulation.from_paths(paths))

        for path in get_all_paths(arguments.openmm_xml_entries):
            runner.add_simulation(OpenMMSimulation.from_xml_path(path))

        for path in get_all_paths(arguments.ase_xml_entries):
            runner.add_simulation(ASEOpenMMSimulation.from_xml_path(path))

        if arguments.record_to_path is not None:
            stem = arguments.record_to_path
            if stem == "":
                timestamp = time.strftime("%Y-%m-%d-%H%M-%S", time.gmtime())
                stem = f"omni-recording-{timestamp}"

            traj_path = f"{stem}.traj"
            state_path = f"{stem}.state"
            print(f"Recording to {traj_path} & {state_path}")

            record_from_server(
                f"localhost:{runner.app_server.port}",
                traj_path,
                state_path,
            )

        yield runner


def main():
    """
    Entry point for the command line.
    """
    arguments = handle_user_arguments()

    with initialise_runner(arguments) as runner:
        if len(runner.simulations) > 0:
            runner.next()

        if arguments.rich:
            try:
                from nanover.omni.rich import OmniTextualApp
            except ImportError as error:
                print(f"Error: {error.msg}\nTry `pip install textual`")
            else:
                app = OmniTextualApp(runner)
                app.run()
        else:
            runner.print_basic_info_and_wait()


if __name__ == "__main__":
    main()
