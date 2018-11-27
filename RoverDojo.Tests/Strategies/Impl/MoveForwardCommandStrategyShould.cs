using FluentAssertions;
using RoverDojo.Core.Data;
using RoverDojo.Strategies.Impl;
using Xunit;

namespace RoverDojo.Tests.Strategies.Impl
{
    public class MoveForwardCommandStrategyShould
    {
        private readonly MoveForwardCommandStrategy _sut;

        public MoveForwardCommandStrategyShould()
        {
            _sut = new MoveForwardCommandStrategy();
        }

        [Theory]
        [ClassData(typeof(MoveForwardWithinBoundariesTestData))]
        public void ReturnCorrectVector(Direction direction, Point initialPosition, Point expectedFinalPosition)
        {
            var initialVector = new Vector(direction, initialPosition);

            var newVector = _sut.Apply(initialVector);

            newVector.Position.Should().BeEquivalentTo(expectedFinalPosition);
        }
    }

    public class MoveForwardWithinBoundariesTestData : TheoryData<Direction, Point, Point>
    {
        public MoveForwardWithinBoundariesTestData()
        {
            Add(Direction.North, new Point(1, 1), new Point(0, 1));
            Add(Direction.South, new Point(1, 1), new Point(2, 1));
            Add(Direction.East, new Point(1, 1), new Point(1, 2));
            Add(Direction.West, new Point(1, 1), new Point(1, 0));
        }
    }
}