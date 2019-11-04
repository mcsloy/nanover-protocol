# Copyright (c) Intangible Realities Lab, University Of Bristol. All rights reserved.
# Licensed under the GPL. See License.txt in the project root for license information.
"""
Module providing time-dependent utility methods.
"""
import time
from typing import Iterable


def yield_interval(interval: float):
    """
    Yield at a set interval, accounting for the time spent outside of this
    function.

    :param interval: Number of seconds to put between yields
    """
    last_yield = time.monotonic() - interval
    while True:
        time_since_yield = time.monotonic() - last_yield
        wait_duration = max(0., interval - time_since_yield)
        time.sleep(wait_duration)
        yield time.monotonic() - last_yield
        last_yield = time.monotonic()


def delayed_generator(iterable: Iterable, delay: float):
    """
    Generate items from the given iterable, with the given delay between
    each item.

    :param iterable: Iterable object to generate items from.
    :param delay: Delay, in seconds, between each item.
    :yield The items in the iterable.
    """
    for item in iterable:
        time.sleep(delay)
        yield item
