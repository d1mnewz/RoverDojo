using FluentAssertions;
using Xunit;

namespace RoverDojo.Tests
{
    public class RoverStateMachineShould
    {
        [Fact]
        public void BeValid()
        {
            var sut = new RoverStateMachine();

            sut.State.Should().Be(RoverState.Operating);
        }

        [Fact]
        public void SetOperating()
        {
            var sut = new RoverStateMachine();

            sut.SetOperating();

            sut.State.Should().Be(RoverState.Operating);
        }

        [Fact]
        public void SetStopped()
        {
            var sut = new RoverStateMachine();

            sut.SetStopped();

            sut.State.Should().Be(RoverState.Stopped);
        }
    }
}