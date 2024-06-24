from concurrent.futures import ThreadPoolExecutor
from pathlib import Path
from typing import List, Optional

from nanover.app import NanoverImdApplication
from nanover.mdanalysis.recordings import iter_trajectory_file, FrameEntry
from nanover.utilities.timing import yield_interval


class PlaybackSimulation:
    def __init__(self, paths: List[str]):
        paths = [Path(path) for path in paths]

        self.name = paths[0].stem

        self.traj_path = next((path for path in paths if path.suffix == ".traj"), None)
        self.state_path = next(
            (path for path in paths if path.suffix == ".state"), None
        )

        self.app_server: Optional[NanoverImdApplication] = None

        self.frames: List[FrameEntry] = []
        self.frame_index = 0
        self.time = 0

        self.threads = ThreadPoolExecutor(max_workers=1)
        self._cancelled = False
        self._run_task = None

    def load(self, app_server: NanoverImdApplication):
        self.app_server = app_server

        self.frames = []
        self.frame_index = 0
        self.time = 0

        if self.traj_path:
            self.frames = [
                (elapsed / 1000000, index, frame)
                for elapsed, index, frame in iter_trajectory_file(self.traj_path)
            ]

        if self.state_path:
            pass

    def run(self):
        if self.is_running:
            raise RuntimeError("Already running on a thread!")
        self._run_task = self.threads.submit(self._run)

    def cancel_run(self):
        if self._run_task is None:
            return

        if self._cancelled:
            return
        self._cancelled = True
        self._run_task.result()
        self._cancelled = False

    def _run(self):
        last_time = self.frames[-1][0]

        for dt in yield_interval(1 / 30):
            if self._cancelled:
                break

            prev_time = self.time
            next_time = prev_time + dt

            for time, index, frame in self.frames:
                if prev_time <= time < next_time:
                    self.app_server.frame_publisher.send_frame(self.frame_index, frame)
                    self.frame_index += 1

            # loop one second after the last frame
            self.time = next_time % (last_time + 1)

    @property
    def is_running(self) -> bool:
        """
        Whether or not the molecular dynamics is currently running on a
        background thread or not.
        :return: `True`, if molecular dynamics is running, `False` otherwise.
        """
        # ideally we'd just check _run_task.running(), but there can be a delay
        # between the task starting and hitting the running state.
        return self._run_task is not None and not (
            self._run_task.cancelled() or self._run_task.done()
        )
