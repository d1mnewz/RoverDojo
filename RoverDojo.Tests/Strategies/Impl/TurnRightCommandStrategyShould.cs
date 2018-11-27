using FluentAssertions;
using RoverDojo.Core.Data;
using RoverDojo.Strategies.Impl;
using Xunit;

namespace RoverDojo.Tests.Strategies.Impl
{
    public class TurnRightCommandStrategyShould
    {
        private readonly TurnRightCommandStrategy _sut;

        public TurnRightCommandStrategyShould()
        {
            _sut = new TurnRightCommandStrategy();
        }

        [Theory]
        [InlineData(Direction.North, Direction.East)]
        [InlineData(Direction.East, Direction.South)]
        [InlineData(Direction.South, Direction.West)]
        [InlineData(Direction.West, Direction.North)]
        public void ReturnCorrectVector(Direction initialDirection, Direction expectedDirection)
        {
            var initialVector = new Vector(initialDirection, new Point(0, 0));

            var finalVector = _sut.Apply(initialVector);

            finalVector.Direction.Should().Be(expectedDirection);
        }
    }
}