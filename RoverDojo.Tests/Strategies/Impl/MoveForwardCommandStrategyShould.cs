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
        [ClassData(typeof(MoveForwardOutsideOfBoundariesTestData))]
        public void ReturnCorrectVector(Direction direction, Point initialPosition, Point expectedFinalPosition, int fieldSize)
        {
            var initialVector = new Vector(direction, initialPosition);

            var newVector = _sut.Apply(initialVector, fieldSize);

            newVector.Position.Should().BeEquivalentTo(expectedFinalPosition);
        }
    }

    public class MoveForwardOutsideOfBoundariesTestData : TheoryData<Direction, Point, Point, int>
    {
        public MoveForwardOutsideOfBoundariesTestData()
        {
            Add(Direction.North, new Point(0, 0), new Point(0, 0), 4);
            Add(Direction.West, new Point(0, 0), new Point(0, 0), 4);
            Add(Direction.South, new Point(3, 3), new Point(3, 3), 4);
            Add(Direction.East, new Point(3, 3), new Point(3, 3), 4);
        }
    }

    public class MoveForwardWithinBoundariesTestData : TheoryData<Direction, Point, Point, int>
    {
        public MoveForwardWithinBoundariesTestData()
        {
            Add(Direction.North, new Point(1, 1), new Point(0, 1), 4);
            Add(Direction.South, new Point(1, 1), new Point(2, 1), 4);
            Add(Direction.East, new Point(1, 1), new Point(1, 2), 4);
            Add(Direction.West, new Point(1, 1), new Point(1, 0), 4);
        }
    }
}