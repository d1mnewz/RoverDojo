using FluentAssertions;
using RoverDojo.Core.Data;
using RoverDojo.Strategies.Impl;
using Xunit;

namespace RoverDojo.Tests.Strategies.Impl
{
    public class TurnLeftCommandStrategyShould
    {
        private readonly TurnLeftCommandStrategy _sut;

        public TurnLeftCommandStrategyShould()
        {
            _sut = new TurnLeftCommandStrategy();
        }

        [Theory]
        [InlineData(Direction.North, Direction.West)]
        [InlineData(Direction.West, Direction.South)]
        [InlineData(Direction.South, Direction.East)]
        [InlineData(Direction.East, Direction.North)]
        public void ReturnCorrectVector(Direction initialDirection, Direction expectedDirection)
        {
            var initialVector = new Vector(initialDirection, new Point(0, 0));

            var finalVector = _sut.Apply(initialVector);

            finalVector.Direction.Should().Be(expectedDirection);
        }
    }
}