using FluentAssertions;
using RoverDojo.Core.Data;
using RoverDojo.Strategies.Impl;
using Xunit;

namespace RoverDojo.Tests.Strategies.Impl
{
    public class TurnRightCommandStrategyShould
    {
        [Fact]
        public void BeValid()
        {
            var strategy = new TurnRightCommandStrategy();
        }

        [Theory]
        [InlineData(Direction.North, Direction.East)]
        [InlineData(Direction.East, Direction.South)]
        [InlineData(Direction.South, Direction.West)]
        [InlineData(Direction.West, Direction.North)]
        public void ReturnCorrectVector(Direction initialDirection, Direction expectedDirection)
        {
            var strategy = new TurnRightCommandStrategy();
            var initialVector = new Vector(initialDirection, new Point(0, 0));

            var finalVector = strategy.Apply(initialVector);

            finalVector.Direction.Should().Be(expectedDirection);
        }
    }
}