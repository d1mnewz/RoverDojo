using System;
using FluentAssertions;
using RoverDojo.Services;
using RoverDojo.Strategies.Impl;
using Xunit;

namespace RoverDojo.Tests.Services
{
    public class CommandStrategiesFactoryShould
    {
        [Fact]
        public void BeValid()
        {
            var sut = new CommandStrategiesFactory();
        }

        [Theory]
        [InlineData("L", typeof(TurnLeftCommandStrategy))]
        [InlineData("R", typeof(TurnRightCommandStrategy))]
        [InlineData("F", typeof(MoveForwardCommandStrategy))]
        public void GetCorrectCommandStrategy(string command, Type expectedType)
        {
            var sut = new CommandStrategiesFactory();

            var strategy = sut.GetCommandStrategy(command);

            strategy.GetType().Should().Be(expectedType);
        }
    }
}