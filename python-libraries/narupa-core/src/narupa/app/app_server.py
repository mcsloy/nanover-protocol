"""
Module providing an out-of-the-box Narupa application server,
with an underyling gRPC server, discovery, multiplayer and commands.
"""
from typing import Tuple

from narupa.core import NarupaServer, DEFAULT_SERVE_ADDRESS
from narupa.essd import DiscoveryServer, ServiceHub
from narupa.multiplayer.multiplayer_service import MultiplayerService, MULTIPLAYER_SERVICE_NAME
from narupa.protocol.multiplayer import add_MultiplayerServicer_to_server


def start_default_server_and_discovery() -> Tuple[NarupaServer, DiscoveryServer]:
    """
    Utility method for creating a default Narupa server along with ESSD discovery.
    :return: tuple of Narupa server and ESSD discovery.
    """
    server = NarupaServer(address=DEFAULT_SERVE_ADDRESS, port=0)
    discovery = DiscoveryServer()
    return server, discovery


class NarupaApplicationServer:
    """
    Provides a convenient Narupa server for typical applications, with local area network discovery provided by
    ESSD, multiplayer configuration and a command service.

    Use this a base for building specific applications by inheriting from it and attaching additional services.
    """

    def __init__(self, server: NarupaServer, discovery: DiscoveryServer, name="Narupa Server"):
        self._server = server
        self._discovery = discovery
        self._service_hub = ServiceHub(name=name,
                                       address=self._server.address,
                                       port=self._server.port)
        self._services = set()
        self._setup_multiplayer()

    def __enter__(self):
        return self

    def __exit__(self, exc_type, exc_val, exc_tb):
        self.close()

    @classmethod
    def basic_server(cls, name="Narupa Server"):
        """
        Initialises a basic Narupa application server with default settings,
        with a default unencrypted server and ESSD discovery server for
        finding it on a local area network.

        :param name: Name of the server for the purposes of discovery.
        :return: An instantiation of a basic Narupa server, registered with an ESSD discovery server.
        """
        server, discovery = start_default_server_and_discovery()
        return cls(server, discovery, name)

    @property
    def name(self) -> str:
        """
        Name of the server.
        :return: The name of the server.
        """
        return self._service_hub.name

    @property
    def address(self) -> str:
        """
        Address of the server.
        :return: Address of the server.
        """
        return self._server.address

    @property
    def port(self) -> int:
        """
        Server port.
        :return: Port of the server.
        """
        return self._server.port

    @property
    def server(self) -> NarupaServer:
        """
        The underlying Narupa server for this application.
        One can use this to manage commands and services.
        :return: The Narupa server.
        """
        # TODO expose command api directly?
        return self._server

    @property
    def discovery(self) -> DiscoveryServer:
        """
        The discovery service that can be used to allow clients to find services hosted by this application.
        :return: The discovery service.

        Services added directly to the server running on this application via :fun:`NarupaApplicationServer.add_service`
        are automatically added to this discovery service.

        Accessing the discovery service directly enables one to register their own server that may be running
        separately to the core application.
        """
        return self._discovery

    def close(self):
        """
        Close the application server and all services.
        """
        self._discovery.close()
        for service in self._services:
            service.close()
        self._server.close()

    def add_service(self, service_name, service, service_registration_method):
        """
        Adds a gRPC service to the server and broadcast it on discovery.
        :param service_name: Name of the service.
        :param service: Service implementation
        :param service_registration_method: Method to register service.
        """
        # TODO this seems a bit low level, but we need a way to add services to both the server and discovery.
        # TODO package up a service, service name and method?
        self._server.add_service(service, add_service_method=service_registration_method)
        self._service_hub.add_service(service_name, self._server.port)
        self._update_discovery_services()

    def _setup_multiplayer(self):
        self._multiplayer = MultiplayerService()
        # TODO it would be great if this didn't need to know about gRPC details.
        self.add_service(MULTIPLAYER_SERVICE_NAME, self._multiplayer, add_MultiplayerServicer_to_server)

    def _update_discovery_services(self):
        try:
            self._discovery.unregister_service(self._service_hub)
        except KeyError:
            pass
        self._discovery.register_service(self._service_hub)
