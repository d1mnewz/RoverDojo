using FluentAssertions;
using RoverDojo.Core.Data;
using Xunit;

namespace RoverDojo.Tests.Core.Data
{
    public class VectorShould
    {
        [Fact]
        public void BeValid()
        {
            var direction = Direction.East;
            var position = new Point(0, 0);
            
            var sut = new Vector(direction, position);

            sut.Position.Should().BeEquivalentTo(position);
            sut.Direction.Should().BeEquivalentTo(direction);
        }
    }
}