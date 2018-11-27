using FluentAssertions;
using RoverDojo.Core.Data;
using RoverDojo.Services.Impl;
using Xunit;

namespace RoverDojo.Tests.Services.Impl
{
    public class RoverStateMachineShould
    {
        private readonly RoverStateMachine _sut;

        public RoverStateMachineShould()
        {
            _sut = new RoverStateMachine();
        }

        [Fact]
        public void BeValid()
        {
            _sut.State.Should().Be(RoverState.Operating);
        }

        [Fact]
        public void SetOperating()
        {
            _sut.SetOperating();

            _sut.State.Should().Be(RoverState.Operating);
        }

        [Fact]
        public void SetStopped()
        {
            _sut.SetStopped();

            _sut.State.Should().Be(RoverState.Stopped);
        }
    }
}