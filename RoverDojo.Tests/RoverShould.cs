using System;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using RoverDojo.Core.Data;
using RoverDojo.Services;
using RoverDojo.Services.Impl;
using RoverDojo.Tests.Test.Mocks;
using Xunit;

namespace RoverDojo.Tests
{
    public class RoverShould
    {
        [Fact]
        public void BeValid()
        {
            var roverStateMachine = new RoverStateMachine();
            var logger = NSubstitute.Substitute.For<ILogger>();
            var sut = new Rover(roverStateMachine, new ConsoleCommandReader(roverStateMachine, logger),
                new CommandStrategiesFactory(), logger);

            sut.CurrentVector.Direction.Should().Be(Direction.North);
            sut.CurrentVector.Position.Should().BeEquivalentTo(new Point(0, 0));
            sut.StateMachine.State.Should().Be(RoverState.Operating);
        }

        [Fact]
        public void RunInfiniteLoopForOperatingRoverState()
        {
            var roverStateMachine = new RoverStateMachine();
            roverStateMachine.SetOperating();

            var mockCommandReader = new MockCommandReader();
            var sut = new Rover(roverStateMachine, mockCommandReader, new CommandStrategiesFactory(),
                NSubstitute.Substitute.For<ILogger>());

            sut.ExecutionTimeOf(r => sut.Operate()).Should()
                .BeGreaterThan(TimeSpan.FromSeconds(10), ">10s considered to be an infinite loop");
            sut.StateMachine.State.Should().Be(RoverState.Operating);
        }

        [Fact]
        public void StopInLess1SecForStoppedRoverState()
        {
            var roverStateMachine = new RoverStateMachine();
            roverStateMachine.SetStopped();
            var logger = NSubstitute.Substitute.For<ILogger>();
            var rover = new Rover(roverStateMachine, new ConsoleCommandReader(roverStateMachine, logger),
                new CommandStrategiesFactory(), logger);

            rover.ExecutionTimeOf(r => rover.Operate()).Should()
                .BeLessThan(TimeSpan.FromSeconds(1));
            rover.StateMachine.State.Should().Be(RoverState.Stopped);
        }
    }
}