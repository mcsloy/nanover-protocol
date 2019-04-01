from queue import Queue
from typing import List

from narupa.protocol.instance import TrajectoryServiceServicer
from narupa.protocol.trajectory import GetFrameResponse, FrameData


class FramePublisher(TrajectoryServiceServicer):
    """
    An implementation of a trajectory service. Call send_frame
    to send data to clients when called by other python code.
    """

    frame_queues: List[Queue]

    last_frame: FrameData

    def __init__(self):
        self.frame_queues = []
        self.last_frame = FrameData()

    def SubscribeFrames(self, request, context):

        yield self.last_frame

        queue = Queue()
        self.frame_queues.append(queue)

        while True:
            item = queue.get(True)
            yield item

    def send_frame(self, frame_index: int, frame: FrameData):
        for key in frame.arrays.keys():
            self.last_frame.arrays[key] = frame.arrays[key]
        for key in frame.values.keys():
            self.last_frame.values[key] = frame.values[key]
        for queue in self.frame_queues:
            queue.put(GetFrameResponse(frame_index=frame_index, frame=frame))
