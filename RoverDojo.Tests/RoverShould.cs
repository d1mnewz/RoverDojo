using System;
using FluentAssertions;
using Xunit;

namespace RoverDojo.Tests
{
    public class RoverShould
    {
        [Fact]
        public void ExecuteMain()
        {
            var mockRoverStateMachine = new MockRoverStateMachine();
            mockRoverStateMachine.State = RoverState.Operating;
            var rover = new Rover(mockRoverStateMachine);

            rover.ExecutionTimeOf(r => rover.Operate()).Should()
                .BeGreaterThan(TimeSpan.FromSeconds(10), ">10s considered as infinite loop");
        }
    }
}