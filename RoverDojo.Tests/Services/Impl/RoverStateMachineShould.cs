using FluentAssertions;
using RoverDojo.Core.Data;
using RoverDojo.Services.Impl;
using Xunit;

namespace RoverDojo.Tests.Services.Impl
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