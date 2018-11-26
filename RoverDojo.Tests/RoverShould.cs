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
            var rover = new Rover();

            rover.ExecutionTimeOf(r => rover.Operate()).Should().BeGreaterThan(TimeSpan.FromSeconds(10), ">10s considered as infinite loop");
        }
    }
}