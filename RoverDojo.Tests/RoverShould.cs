using System;
using System.Threading;
using FluentAssertions;
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
            var sut = new Rover(roverStateMachine, new ConsoleCommandReader(roverStateMachine));

            sut.CurrentRoverFacingDirection.Should().Be(RoverFacingDirection.North);
            sut.CurrentRoverPosition.Should().BeEquivalentTo(new Point(0, 0));
        }

        [Fact]
        public void RunInfiniteLoopForOperatingRoverState()
        {
            var roverStateMachine = new RoverStateMachine();
            roverStateMachine.SetOperating();

            var mockCommandReader = new MockCommandReader();
            var rover = new Rover(roverStateMachine, mockCommandReader);

            rover.ExecutionTimeOf(r => rover.Operate()).Should()
                .BeGreaterThan(TimeSpan.FromSeconds(10), ">10s considered as infinite loop");
        }

        [Fact]
        public void StopInLess1SecForStoppedRoverState()
        {
            var roverStateMachine = new RoverStateMachine();
            roverStateMachine.SetStopped();
            var rover = new Rover(roverStateMachine, new ConsoleCommandReader(roverStateMachine));

            rover.ExecutionTimeOf(r => rover.Operate()).Should()
                .BeLessThan(TimeSpan.FromSeconds(1));
        }
    }
}