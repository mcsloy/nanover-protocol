# Copyright (c) Intangible Realities Lab, University Of Bristol. All rights reserved.
# Licensed under the GPL. See License.txt in the project root for license information.
"""
Tests for :mod:`narupa.openmm.runner`.
"""
# Pylint does not recognize pytest fixtures which creates fake warnings.
# pylint: disable=redefined-outer-name,unused-import
# Inherited test methods loose the staticmethod decorator. Test method that
# will not be overwritten therefore cannot be staticmethods, even if they do
# not use self.
# pylint: disable=no-self-use
import time

import pytest

from narupa.app import NarupaImdClient
from narupa.openmm import Runner
from narupa.openmm.imd import add_imd_force_to_system
from narupa.trajectory.frame_server import (
    PLAY_COMMAND_KEY,
    PAUSE_COMMAND_KEY,
    RESET_COMMAND_KEY,
    STEP_COMMAND_KEY,
)

from .simulation_utils import (
    DoNothingReporter,
    basic_simulation_with_imd_force,
    basic_simulation,
    serialized_simulation_path,
)


class TestRunner:
    """
    Tests for the :class:`Runner` class.

    This class can be inherited to test subclasses of :class:`Runner`. The
    :meth:`runner` fixture and the :meth:`test_class` test must then be
    overwritten. If the subclass adds any reporters, then the
    :attr:`expected_expected_number_of_reporters_verbosity`
    class attribute must be overwritten as well to reflect the default number
    of reporters when the verbosity is set to ``True`` or ``False``.
    """
    expected_number_of_reporters_verbosity = {
        True: 3,
        False: 2,
    }

    @pytest.fixture
    def runner(self, basic_simulation_with_imd_force):
        """
        Setup a :class:`Runner` on a basic simulation.

        The simulation has a reporter attached to it to assure removing a reporter
        only removes only that reporter.
        """
        simulation, _ = basic_simulation_with_imd_force
        runner = Runner(simulation, port=0)
        runner.simulation.reporters.append(DoNothingReporter())
        yield runner
        runner.close()

    @pytest.fixture
    def client_server(self, runner):
        server_port = runner.app.port
        with NarupaImdClient.connect_to_single_server(port=server_port) as client:
            yield client, runner

    @staticmethod
    def test_class(runner):
        """
        Make sure the :meth:`runner` fixture returns an object of the expected
        class.

        This assures that test classes that inherit from that class use their
        own fixture.
        """
        assert isinstance(runner, Runner)

    def test_simulation_without_imd_force(self, basic_simulation):
        """
        When created on a simulation without imd force, the runner fails.
        """
        with pytest.raises(ValueError):
            Runner(basic_simulation, port=0)

    def test_simulation_multiple_imd_force(self, caplog, basic_simulation):
        """
        When created on a simulation with more than one imd force, the runner
        issues a warning.
        """
        # The forces added to the system will not be accounted for when running
        # the dynamics until the context is reset as the system is already
        # compiled in a context. It does not matter here, as the force is still
        # listed in the system, which is what we check.
        system = basic_simulation.system
        for _ in range(3):
            add_imd_force_to_system(system)

        runner = Runner(basic_simulation, port=0)
        runner.close()
        assert 'More than one force' in caplog.text

    def test_default_verbosity(self, runner):
        """
        Test that the verbosity is off by default
        """
        assert not runner.verbose

    @pytest.mark.parametrize('initial_value', (True, False))
    @pytest.mark.parametrize('set_value_to', (True, False))
    def test_set_verbosity_from_property(self, runner, initial_value, set_value_to):
        """
        Test that the verbosity can be set from the :attr:`Runner.verbose` property.

        The test makes sure that the value can be set from one value to an other,
        and from one value to itself.
        """
        reporters = runner.simulation.reporters
        runner.verbose = initial_value
        assert runner.verbose == initial_value
        assert len(reporters) == self.expected_number_of_reporters_verbosity[initial_value]
        runner.verbose = set_value_to
        assert runner.verbose == set_value_to
        assert len(reporters) == self.expected_number_of_reporters_verbosity[set_value_to]

    @pytest.mark.parametrize('initial_value', (True, False))
    def test_make_verbose(self, runner, initial_value):
        """
        Test that :meth:`Runner.make_verbose` sets the verbosity on.
        """
        reporters = runner.simulation.reporters
        runner.verbose = initial_value
        assert runner.verbose == initial_value
        runner.make_verbose()
        assert runner.verbose
        assert len(reporters) == self.expected_number_of_reporters_verbosity[True]

    @pytest.mark.parametrize('initial_value', (True, False))
    def test_make_quiet(self, runner, initial_value):
        """
        Test that :meth:`Runner.make_quiet` sets the verbosity off.
        """
        reporters = runner.simulation.reporters
        runner.verbose = initial_value
        assert runner.verbose == initial_value
        runner.make_quiet()
        assert not runner.verbose
        assert len(reporters) == self.expected_number_of_reporters_verbosity[False]

    def test_run(self, runner):
        """
        Test that :meth:`Runner.run` runs the simulation.
        """
        assert runner.simulation.currentStep == 0
        runner.run(steps=5)
        assert runner.simulation.currentStep == 5

    def test_from_xml_input(self, serialized_simulation_path):
        """
        Test that a :class:`Runner` can be built from a serialized simulation.
        """
        n_atoms_in_system = 8
        with Runner.from_xml_input(serialized_simulation_path, port=0) as runner:
            assert runner.simulation.system.getNumParticles() == n_atoms_in_system

    @pytest.mark.parametrize('name, target_attribute', (
        ('frame_interval', 'frame_interval'),
        ('force_interval', 'force_interval'),
    ))
    def test_interval_get(self, runner, name,  target_attribute):
        """
        The shortcut the the NarupaImdReporter intervals return the expected
        values.
        """
        attribute = getattr(runner.reporter, target_attribute)
        assert getattr(runner, name) == attribute

    @pytest.mark.parametrize('name, target_attribute', (
            ('frame_interval', 'frame_interval'),
            ('force_interval', 'force_interval'),
    ))
    def test_interval_set(self, runner, name, target_attribute):
        """
        The shortcut the the NarupaImdReporter intervals set the expected
        values.
        """
        setattr(runner.reporter, name, 70)
        assert getattr(runner.reporter, name) == 70

    @pytest.mark.parametrize('is_verbose, expectation', (
            (True, 10),
            (False, 0),
    ))
    def test_verbosity_interval_get(self, runner, is_verbose, expectation):
        runner.verbose = is_verbose
        assert runner.verbosity_interval == expectation

    @pytest.mark.parametrize('is_verbose', (True, False))
    @pytest.mark.parametrize('interval', (3, 70))
    def test_verbosity_interval_set_non_zero(self, runner, interval, is_verbose):
        runner.verbose = is_verbose
        runner.verbosity_interval = interval
        assert runner._verbose_reporter._reportInterval == interval
        assert runner.verbose is True

    @pytest.mark.parametrize('is_verbose', (True, False))
    def test_verbosity_interval_set_zero(self, runner, is_verbose):
        runner.verbose = is_verbose
        runner.verbosity_interval = 0
        assert runner.verbose is False

    def test_run_non_blocking(self, runner):
        runner.run(100, block=False)
        # Here we count on the context switching to the assertions before finishing
        # the run.
        assert runner.simulation.currentStep < 100
        assert runner._run_task is not None
        assert not runner._cancelled

    def test_cancel_run(self, runner):
        runner.run(block=False)
        assert runner.is_running
        runner.cancel_run(wait=True)
        assert runner.is_running is False

    def test_cancel_never_running(self, runner):
        # Cancelling a non running simulation should not raise an exception.
        runner.cancel_run()

    def test_run_twice(self, runner):
        runner.run(block=False)
        with pytest.raises(RuntimeError):
            runner.run(block=False)

    def test_step(self, runner):
        step_count = runner.simulation.currentStep
        runner.step()
        assert runner.simulation.currentStep == step_count + runner.frame_interval

    def test_multiple_steps(self, runner):
        num_steps = 10
        runner.run(block=False)
        runner.cancel_run(wait=True)
        step_count = runner.simulation.currentStep
        for i in range(num_steps):
            runner.step()
        assert runner.simulation.currentStep == step_count + (num_steps * runner.frame_interval)

    def test_pause(self, runner):
        runner.run(block=False)
        runner.pause()
        step_count = runner.simulation.currentStep
        assert runner._run_task.done() is True
        time.sleep(0.1)
        assert runner.simulation.currentStep == step_count

    def test_play(self, runner):
        runner.run(block=False)
        assert runner.is_running
        runner.pause()
        assert runner.is_running is False
        runner.play()
        assert runner.is_running

    def test_play_twice(self, runner):
        runner.play()
        assert runner.is_running
        runner.play()
        assert runner.is_running

    @pytest.mark.timeout(1)
    def test_play_command(self, client_server):
        client, server = client_server
        assert not server.is_running
        client.run_command(PLAY_COMMAND_KEY)
        while True:
            if server.is_running:
                return

    @pytest.mark.timeout(1)
    def test_pause_command(self, client_server):
        client, server = client_server
        server.run()
        client.run_command(PAUSE_COMMAND_KEY)
        while server.is_running:
            continue
        step_count = server.simulation.currentStep
        time.sleep(0.1)
        assert server.simulation.currentStep == step_count

    @pytest.mark.timeout(1)
    @pytest.mark.parametrize('running_before', (True, False))
    def test_reset_command(self, client_server, running_before):
        client, server = client_server
        server.run(10)
        if running_before:
            server.run()

        reset = False

        def on_reset():
            nonlocal reset
            reset = True

        server.on_reset.add_callback(on_reset)
        client.run_command(RESET_COMMAND_KEY)

        while not reset:
            continue
        assert server.is_running == running_before

    @pytest.mark.timeout(1)
    def test_step_command(self, client_server):
        client, server = client_server
        step_count = server.simulation.currentStep
        client.run_command(STEP_COMMAND_KEY)
        time.sleep(0.1)
        assert server.is_running is False
        assert server.dynamics.get_number_of_steps() == step_count + 1