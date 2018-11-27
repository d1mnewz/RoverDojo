using FluentAssertions;
using RoverDojo.Core.Data;
using RoverDojo.Strategies.Impl;
using Xunit;

namespace RoverDojo.Tests.Strategies.Impl
{
    public class TurnLeftCommandStrategyShould
    {
        [Fact]
        public void BeValid()
        {
            var strategy = new TurnLeftCommandStrategy();
        }

        [Theory]
        [InlineData(Direction.North, Direction.West)]
        [InlineData(Direction.West, Direction.South)]
        [InlineData(Direction.South, Direction.East)]
        [InlineData(Direction.East, Direction.North)]
        public void ReturnCorrectVector(Direction initialDirection, Direction expectedDirection)
        {
            var strategy = new TurnLeftCommandStrategy();
            var initialVector = new Vector(initialDirection, new Point(0, 0));

            var finalVector = strategy.Apply(initialVector);

            finalVector.Direction.Should().Be(expectedDirection);
        }
    }
}