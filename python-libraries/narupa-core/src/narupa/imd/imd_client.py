# Copyright (c) Intangible Realities Lab, University Of Bristol. All rights reserved.
# Licensed under the GPL. See License.txt in the project root for license information.
import logging
from uuid import uuid4
from concurrent.futures import Future
from queue import Queue
from typing import Iterable, Dict, Any, NamedTuple, Set

import grpc
from narupa.core import NarupaStubClient
from narupa.imd.particle_interaction import (
    ParticleInteraction,
    DEFAULT_MAX_FORCE,
)
from narupa.protocol.imd import (
    InteractiveMolecularDynamicsStub,
    InteractionEndReply,
    SubscribeInteractionsRequest,
)
from narupa.utilities.change_buffers import DictionaryChange
from narupa.utilities.protobuf_utilities import struct_to_dict


class _LocalInteractionState(NamedTuple):
    """
    Internal state for managing and publishing the client's active interactions.
    """
    queue: Queue
    sentinel: Any
    future: Future


def queue_generator(queue: Queue, sentinel: object):
    """
    Produces a generator that can be used to iterate over the values submitted
    to a queue, until the given sentinel is added to the queue. The iterator
    will block until this sentinel is passed.

    Enables one to take control of when items are passed to a streaming
    iterator, such as that used in :func:`publish_interactions_async`.

    :param queue: Queue that items will be submitted to.
    :param sentinel: A sentinel that indicates the end of iteration. When added
        to the queue, the generator stops.
    :return: Yields the items in put into the queue, in the order they were put in.

    >>> queue = Queue()
    >>> sentinel = object()
    >>> queue.put(1)
    >>> queue.put(2)
    >>> queue.put(sentinel)
    >>> generator = queue_generator(queue, sentinel)
    >>> for item in generator:
    ...     print(item)
    1
    2

    """
    for val in iter(queue.get, sentinel):
        yield val


def _to_proto(interactions: Iterable[ParticleInteraction]):
    for interaction in interactions:
        yield interaction.proto


class ImdClient(NarupaStubClient):
    """
    A simple IMD client, primarily for testing the IMD server.

    """
    stub: InteractiveMolecularDynamicsStub
    interactions: Dict[str, ParticleInteraction]
    _local_interaction_ids: Set[str]
    _logger: logging.Logger

    def __init__(self, *,
                 channel: grpc.Channel,
                 make_channel_owner: bool = False):
        super().__init__(channel=channel, stub=InteractiveMolecularDynamicsStub, make_channel_owner=make_channel_owner)
        self.interactions = {}
        self._local_interaction_ids = set()
        self._logger = logging.getLogger(__name__)

        self.subscribe_interactions()

    def start_interaction(self) -> str:
        """
        Start an interaction

        :return: A unique identifier to be used to update the interaction.
        """
        interaction_id = str(uuid4())
        self._local_interaction_ids.add(interaction_id)
        return interaction_id

    def update_interaction(
            self,
            interaction_id: str,
            interaction: ParticleInteraction,
    ):
        """
        Updates the interaction identified with the given interaction_id on the server with
        parameters from the given interaction.

        :param interaction_id: The unique interaction ID, created with
            :func:`~ImdClient.start_interaction`, that identifies the
            interaction to update.
        :param interaction: The :class: ParticleInteraction providing new
            parameters for the interaction.

        :raises: KeyError, if the given interaction ID does not exist.
        """
        if interaction_id not in self._local_interaction_ids:
            raise KeyError("Attempted to update an interaction with an "
                           "unknown interaction ID.")
        key = 'interaction.' + interaction_id
        value = _interaction_to_dict(interaction)
        change = DictionaryChange(updates={key: value}, removals=[])
        result = self.attempt_update_state(change)
        return result

    def stop_interaction(self, interaction_id: str) -> bool:
        """
        Stops the interaction identified with the given interaction_id on the server.

        :param interaction_id: The unique interaction ID, created with
            :func:`~ImdClient.start_interaction`, that identifies the
            interaction to stop.

        :raises: KeyError, if the given interaction ID does not exist.
        """
        if interaction_id not in self._local_interaction_ids:
            raise KeyError("Attempted to stop an interaction with an unknown "
                           "interaction ID.")
        self._local_interaction_ids.remove(interaction_id)
        change = DictionaryChange(
            updates={},
            removals=['interaction.' + interaction_id]
        )
        return self.attempt_update_state(change)

    def stop_all_interactions(self):
        """
        Stops all active interactions governed by this client.
        """
        for interaction_id in list(self._local_interaction_ids):
            self.stop_interaction(interaction_id)

    def subscribe_interactions(self) -> Future:
        """
        Begin receiving updates known interactions.
        """
        return self.threads.submit(self._subscribe_interactions)

    def _subscribe_interactions(self):
        with self._state.get_change_buffer() as change_buffer:
            for change in change_buffer.subscribe_changes():
                for key in change.removals:
                    if key.startswith('interaction.'):
                        interaction_id = key[len('interaction.'):]
                        removed = self.interactions.pop(interaction_id, None)
                for key, value in change.updates.items():
                    if key.startswith('interaction.'):
                        interaction_id = key[len('interaction.'):]
                        self.interactions[interaction_id] = _dict_to_interaction(value)

    def close(self):
        """
        Closes the IMD client.
        """
        try:
            self.stop_all_interactions()
        except grpc.RpcError as e:
            self._logger.exception(e)
            raise e
        finally:
            super().close()


def _interaction_to_dict(interaction: ParticleInteraction):
    try:
        return {
            "position": [float(f) for f in interaction.position],
            "particles": [int(i) for i in interaction.particles],
            "properties": struct_to_dict(interaction.properties),
        }
    except AttributeError as e:
        raise TypeError from e


def _dict_to_interaction(dictionary: Dict[str, object]) -> ParticleInteraction:
    properties: Dict[str, object] = dictionary['properties']
    max_force = properties.get(ParticleInteraction.MAX_FORCE_KEY, DEFAULT_MAX_FORCE)
    if max_force == 'Infinity':
        max_force = float('inf')

    return ParticleInteraction(
        position=dictionary['position'],
        particles=[int(i) for i in dictionary['particles']],

        interaction_type=properties.get(ParticleInteraction.TYPE_KEY, 'gaussian'),
        scale=properties.get(ParticleInteraction.SCALE_KEY, 1),
        mass_weighted=properties.get(ParticleInteraction.MASS_WEIGHTED_KEY, True),
        reset_velocities=properties.get(ParticleInteraction.RESET_VELOCITIES_KEY, False),
        max_force=max_force,
    )
