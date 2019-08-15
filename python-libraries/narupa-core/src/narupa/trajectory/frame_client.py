from concurrent.futures import Future
from typing import Optional

import grpc
from narupa.core import get_requested_port_or_default, GrpcClient
from narupa.protocol.trajectory import TrajectoryServiceStub, GetFrameRequest
from narupa.trajectory import FrameData
from narupa.trajectory.frame_server import DEFAULT_PORT


class FrameClient(GrpcClient):
    def __init__(self, *, address: Optional[str] = None,
                 port: Optional[int] = None):
        port = get_requested_port_or_default(port, DEFAULT_PORT)
        super().__init__(address=address, port=port, stub=TrajectoryServiceStub)

    def subscribe_frames_async(self, callback, frame_interval=0) -> Future:
        return self.threads.submit(self.subscribe_frames_blocking,
                                   callback,
                                   frame_interval)

    def subscribe_frames_blocking(self, callback, frame_interval=0):
        request = GetFrameRequest(frame_interval=frame_interval)
        for response in self.stub.SubscribeFrames(request):
            callback(frame_index=response.frame_index,
                     frame=FrameData(response.frame))

    def subscribe_last_frames_async(self, callback, frame_interval=0) -> Future:
        return self.threads.submit(self.subscribe_last_frames_blocking,
                                   callback,
                                   frame_interval)

    def subscribe_last_frames_blocking(self, callback, frame_interval=0):
        request = GetFrameRequest(frame_interval=frame_interval)
        for response in self.stub.SubscribeLatestFrames(request):
            callback(frame_index=response.frame_index,
                     frame=FrameData(response.frame))
