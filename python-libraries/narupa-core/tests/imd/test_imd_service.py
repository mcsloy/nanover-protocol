"""
Unit tests of the IMD service, without any connections.
"""

from narupa.imd.imd_service import ImdService
from narupa.imd.particle_interaction import ParticleInteraction


def test_add_duplicate_interaction_id():
    service = ImdService()
    service.insert_interaction('test', ParticleInteraction())
    service.insert_interaction('test', ParticleInteraction())
    assert len(service.active_interactions) == 1


def test_multiple_keys():
    service = ImdService()
    service.insert_interaction('test1', ParticleInteraction())
    service.insert_interaction('test2', ParticleInteraction())
    assert len(service.active_interactions) == 2
