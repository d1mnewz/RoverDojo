using System;
using Microsoft.Extensions.Logging;
using RoverDojo.Services.Contract;

namespace RoverDojo.Services.Impl
{
    public class ConsoleCommandReader : ICommandReader
    {
        public readonly IRoverStateMachine RoverStateMachine;
        private readonly ILogger _logger;

        public ConsoleCommandReader(IRoverStateMachine roverStateMachine, ILogger logger)
        {
            RoverStateMachine = roverStateMachine;
            _logger = logger;
        }

        public string ReadCommand()
        {
            var command = Console.ReadLine();
            if (command != "L" && command != "R" && command != "F")
            {
                RoverStateMachine.SetStopped();
                _logger.LogError("Invalid command");
                return null;
            }

            return command;
        }
    }
}