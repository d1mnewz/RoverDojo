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
        [InlineData(Direction.North, Direction.West, 4)]
        [InlineData(Direction.West, Direction.South, 4)]
        [InlineData(Direction.South, Direction.East, 4)]
        [InlineData(Direction.East, Direction.North, 4)]
        public void ReturnCorrectVector(Direction initialDirection, Direction expectedDirection, int fieldSize)
        {
            var initialVector = new Vector(initialDirection, new Point(0, 0));

            var finalVector = _sut.Apply(initialVector, fieldSize);

            finalVector.Direction.Should().Be(expectedDirection);
        }
    }
}