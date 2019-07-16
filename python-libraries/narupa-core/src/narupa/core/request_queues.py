"""
Provides a dictionary of queues.
"""

from typing import Dict, Hashable, Generator, Tuple
from queue import Queue, Empty
from threading import Lock
from contextlib import contextmanager


class DictOfQueues:
    """
    Dictionary of request queues.

    .. example::

        # A thread working on its own queue
        many_queues = DictOfQueues()
        request_id = 0
        with many_queues.one_queue(request_id) as queue:
            # do stuff

        # A thread populating all the queues
        many_queues = DictOfQueues(queue_max_size=100)
        for queue in many_queue.iter_queue():
            queue.put('something')


    Adding or removing a key from the dictionary *must* be done while holding
    :attr:`DictOfQueues.lock`. The recommended way to register and unregister
    a queue is to use the :meth:`one_queue` context manager.
    """
    queue_max_size: int
    queues: Dict[Hashable, Queue]
    lock: Lock

    def __init__(self, queue_max_size=0):
        """
        :param queue_max_size: The maximum size of each queue. If set to 0,
            there is no maximum size and queues can grow indefinitely. When a
            queue reaches its maximum size, adding a element is blocking until
            the size of the queue decreases.
        """
        self.queue_max_size = queue_max_size
        self.queues = {}
        self.lock = Lock()
    
    def __contains__(self, key):
        with self.lock:
            return key in self.queues

    @contextmanager
    def one_queue(self, request_id, queue_class=Queue):
        """
        Works with a queue.

        This method is a context manager that creates and registers the queue,
        provides the queue to the calling scope, and un-registers the queue
        when exiting the context.

        :param request_id: The key for the queue. This key has to be unique, if
            a queue is already registered with that key, then a
            :exc:`ValueError` is raised.
        :param queue_class: The class to instantiate for that queue. By default,
            a :class:`Queue` is instantiated.
        """
        queue = queue_class(maxsize=self.queue_max_size)
        with self.lock:
            if request_id in self.queues:
                raise ValueError(f'The key {request_id} is already registered.')
            self.queues[request_id] = queue
        try:
            yield queue
        finally:
            with self.lock:
                del self.queues[request_id]

    def iter_queues(self) -> Generator[Queue, None, None]:
        """
        Iterate over the queues.

        The method places a lock on the dictionary so no queue can be added or
        removed while iterating.
        """
        with self.lock:
            yield from self.queues.values()
    
    def iter_queues_items(self) -> Generator[Tuple[Hashable, Queue], None, None]:
        """
        Iterate over the queues and their keys.

        The method places a lock on the dictionary so no queue can be added or
        removed while iterating.
        """
        with self.lock:
            yield from self.queues.items()


class SingleItemQueue:
    """
    Mimics the basic interface of a :class:`Queue` but only stores one item.
    """
    def __init__(self, maxsize=None):
        """
        :param maxsize: Unused parameter, included for compatibility with
            :class:`Queue`.
        """
        self._lock = Lock()
        self._item = None

    def put(self, item, **kwargs):
        """
        Store a value, replace the previous one if any.

        This method is thread-safe and is meant to be a drop in replacement
        to :meth:`Queue.put`.

        :param item: The value to store.
        :param kwargs: Unused arguments for compatibility with :meth:`Queue.put`.
        """
        with self._lock:
            self._item = item

    def get(self, **kwargs):
        """
        Get the stored value, and remove it from storage.

        If there is no value to get, then the method raises an :exc:`Empty`
        exception.

        This method is thread-safe and is meant to be a drop in replacement
        to :meth:`Queue.get`.

        :param kwargs: Unused arguments for compatibility with :meth:`Queue.get`.
        :return: The stored value.
        """
        if kwargs.get('block', True):
            raise NotImplementedError("Blocking not implemented.")

        with self._lock:
            item = self._item
            if item is None:
                raise Empty('No value available.')
            else:
                self._item = None
            return item
