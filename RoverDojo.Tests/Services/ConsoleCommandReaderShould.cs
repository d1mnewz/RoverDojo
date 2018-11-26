using System;
using System.IO;
using FluentAssertions;
using RoverDojo.Services.Impl;
using Xunit;

namespace RoverDojo.Tests.Services
{
    public class ConsoleCommandReaderShould
    {
        [Fact]
        public void BeValid()
        {
            var sut = new ConsoleCommandReader(new RoverStateMachine());
        }

        [Theory]
        [InlineData("L")]
        [InlineData("R")]
        [InlineData("F")]
        public void ReadCorretCommand(string expectedCommand)
        {
            var sut = new ConsoleCommandReader(new RoverStateMachine());
            using (var sr = new StringReader(string.Format(expectedCommand,
                Environment.NewLine)))
            {
                Console.SetIn(sr);
                var command = sut.ReadCommand();

                command.Should().Be(expectedCommand);
            }
        }

        [Fact]
        public void ReadIncorrectCommandAsNull()
        {
            var sut = new ConsoleCommandReader(new RoverStateMachine());
            using (var sr = new StringReader(string.Format("test",
                Environment.NewLine)))
            {
                Console.SetIn(sr);
                var command = sut.ReadCommand();

                command.Should().Be(null);
            }
        }

        [Fact]
        public void SetStateToStoppedAfterIncorrectInput()
        {
            var sut = new ConsoleCommandReader(new RoverStateMachine());
            using (var sr = new StringReader(string.Format("test",
                Environment.NewLine)))
            {
                Console.SetIn(sr);
                sut.ReadCommand();

                sut.RoverStateMachine.State.Should().Be(RoverState.Stopped);
            }
        }
    }
}