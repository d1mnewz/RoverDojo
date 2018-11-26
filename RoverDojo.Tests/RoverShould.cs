using System;
using FluentAssertions;
using Xunit;

namespace RoverDojo.Tests
{
    public class RoverShould
    {
        [Fact]
        public void BeValid()
        {
            var sut = new Rover(new MockRoverStateMachine());

            sut.CurrentRoverFacingDirection.Should().Be(RoverFacingDirection.North);
            sut.CurrentRoverPosition.Should().BeEquivalentTo(new Point(0, 0));
        }


        [Fact]
        public void RunInfiniteLoopForOperatingRoverState()
        {
            var mockRoverStateMachine = new MockRoverStateMachine { State = RoverState.Operating };
            var rover = new Rover(mockRoverStateMachine);

            rover.ExecutionTimeOf(r => rover.Operate()).Should()
                .BeGreaterThan(TimeSpan.FromSeconds(10), ">10s considered as infinite loop");
        }

        [Fact]
        public void StopInLess1SecForStoppedRoverState()
        {
            var mockRoverStateMachine = new MockRoverStateMachine { State = RoverState.Stopped };
            var rover = new Rover(mockRoverStateMachine);

            rover.ExecutionTimeOf(r => rover.Operate()).Should()
                .BeLessThan(TimeSpan.FromSeconds(1));
        }
    }
}