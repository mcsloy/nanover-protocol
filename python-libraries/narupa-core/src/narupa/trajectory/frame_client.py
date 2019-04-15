from concurrent import futures

import grpc

from narupa.protocol.trajectory import TrajectoryServiceStub, GetFrameRequest


class FrameClient:

    def __init__(self, *, address: str, port: int):
        self.channel = grpc.insecure_channel("{0}:{1}".format(address, port))
        self.stub = TrajectoryServiceStub(self.channel)
        self.threads = futures.ThreadPoolExecutor(max_workers=10)

    def subscribe_frames_async(self, callback):
        self.threads.submit(self.subscribe_frames_blocking, callback)

    def subscribe_frames_blocking(self, callback):
        for response in self.stub.SubscribeFrames(GetFrameRequest()):
            callback(frame_index=response.frame_index, frame=response.frame)

    def close(self):
        self.channel.close()
        self.threads.shutdown(wait=False)