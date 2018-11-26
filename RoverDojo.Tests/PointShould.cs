using FluentAssertions;
using Xunit;

namespace RoverDojo.Tests
{
    public class PointShould
    {
        [Fact]
        public void BeValid()
        {
            var sut = new Point(0, 0);

            sut.Y.Should().Be(0);
            sut.X.Should().Be(0);
        }
    }
}