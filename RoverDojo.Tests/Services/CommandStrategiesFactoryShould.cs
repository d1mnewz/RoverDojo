using System;
using FluentAssertions;
using RoverDojo.Services;
using RoverDojo.Strategies.Impl;
using Xunit;

namespace RoverDojo.Tests.Services
{
    public class CommandStrategiesFactoryShould
    {
        private CommandStrategiesFactory _sut;

        [Fact]
        public void BeValid()
        {
            _sut = new CommandStrategiesFactory();
        }

        [Theory]
        [InlineData("L", typeof(TurnLeftCommandStrategy))]
        [InlineData("R", typeof(TurnRightCommandStrategy))]
        [InlineData("F", typeof(MoveForwardCommandStrategy))]
        public void GetCorrectCommandStrategy(string command, Type expectedType)
        {
            _sut = new CommandStrategiesFactory();

            var strategy = _sut.GetCommandStrategy(command);

            strategy.GetType().Should().Be(expectedType);
        }
    }
}