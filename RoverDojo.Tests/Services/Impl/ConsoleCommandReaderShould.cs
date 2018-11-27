using System;
using System.IO;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;
using RoverDojo.Core.Data;
using RoverDojo.Services.Impl;
using Xunit;

namespace RoverDojo.Tests.Services.Impl
{
    public class ConsoleCommandReaderShould
    {
        private ConsoleCommandReader _sut;

        public ConsoleCommandReaderShould()
        {
            _sut = new ConsoleCommandReader(new RoverStateMachine(), Substitute.For<ILogger>());
        }

        [Theory]
        [InlineData("L")]
        [InlineData("R")]
        [InlineData("F")]
        public void ReadCorretCommand(string expectedCommand)
        {
            using (var sr = new StringReader(string.Format(expectedCommand,
                Environment.NewLine)))
            {
                Console.SetIn(sr);
                var command = _sut.ReadCommand();

                command.Should().Be(expectedCommand);
            }
        }

        [Fact]
        public void ReadIncorrectCommandAsNull()
        {
            using (var sr = new StringReader(string.Format("test",
                Environment.NewLine)))
            {
                Console.SetIn(sr);
                var command = _sut.ReadCommand();

                command.Should().Be(null);
            }
        }

        [Fact]
        public void SetStateToStoppedAfterIncorrectInput()
        {
            using (var sr = new StringReader(string.Format("test",
                Environment.NewLine)))
            {
                Console.SetIn(sr);
                _sut.ReadCommand();

                _sut.RoverStateMachine.State.Should().Be(RoverState.Stopped);
            }
        }
    }
}