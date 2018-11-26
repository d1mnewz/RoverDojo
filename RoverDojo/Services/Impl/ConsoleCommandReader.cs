using System;
using RoverDojo.Services.Contract;

namespace RoverDojo.Services.Impl
{
    public class ConsoleCommandReader : ICommandReader
    {
        public readonly IRoverStateMachine RoverStateMachine;

        public ConsoleCommandReader(IRoverStateMachine roverStateMachine)
        {
            RoverStateMachine = roverStateMachine;
        }

        public string ReadCommand()
        {
            var command = Console.ReadLine();
            if (command != "L" && command != "R" && command != "F")
            {
                RoverStateMachine.SetStopped();
                return null;
                // Log invalid command.
            }

            return command;
        }
    }
}