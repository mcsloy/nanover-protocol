# Copyright (c) Intangible Realities Lab, University Of Bristol. All rights reserved.
# Licensed under the GPL. See License.txt in the project root for license information.

"""
Module providing a wrapper around the running of GRPC servers.
"""
from concurrent import futures
from typing import Optional

import grpc

DEFAULT_SERVE_ADDRESS = '[::]'
DEFAULT_CONNECT_ADDRESS = 'localhost'

# We expect that reserving a large number of threads should not present a
# performance issue. Each concurrent GRPC request requires a worker, and streams
# occupy those workers indefinitely, so several workers must be available for
# each expected client.
DEFAULT_MAX_WORKERS = 128


class GrpcServer:
    """
    A base class for running GRPC servers that handles the starting and closing
    of the underlying server.

    :param address: The IP address at which to run the server.
    :param port: The port on which to run the server.
    """

    def __init__(
            self,
            *,
            address: str,
            port: int,
            max_workers=DEFAULT_MAX_WORKERS,
    ):
        grpc_options = (
            # do not allow hosting two servers on the same port
            ('grpc.so_reuseport', 0),
        )
        executor = futures.ThreadPoolExecutor(max_workers=max_workers)
        self.server = grpc.server(executor, options=grpc_options)
        self.setup_services()
        self._address = address
        self._port = self.server.add_insecure_port(address=f"{address}:{port}")

        if self._port == 0:
            if port == 0:
                raise IOError(f"Could not open any port.")
            raise IOError(f"Could not open on port {port}.")
        print(f'Running server {self.__class__.__name__} on port {self.port}')
        self.server.start()

    @property
    def address(self):
        """
        Get the address that this server is or was provided at.
        """
        return self._address

    @property
    def port(self):
        """
        Get the port that the server is or was provided on. This is 0 if a port
        was unable to be chosen.
        """
        return self._port

    def setup_services(self):
        pass

    def close(self):
        self.server.stop(grace=False)

    def __enter__(self):
        return self

    def __exit__(self, exc_type, exc_val, exc_tb):
        self.close()


def get_requested_port_or_default(port: Optional[int], default: int) -> int:
    """
    Returns the port you asked for, or the default one is `port` is `None`.
    """
    if port is None:
        port = default
    return port
