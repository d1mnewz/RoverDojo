using System;
using RoverDojo.Core.Data;
using RoverDojo.Services;
using RoverDojo.Services.Contract;

namespace RoverDojo
{
    public class Rover
    {
        public Vector CurrentVector { get; private set; }

        private readonly IRoverStateMachine _stateMachine;
        private readonly ICommandReader _commandReader;
        private const Direction InitialRoverDirection = Direction.North;
        private static readonly Point InitialRoverPosition = new Point(0, 0);
        private readonly CommandStrategiesFactory _handlecommandStrategiesFactory;

        public Rover(IRoverStateMachine stateMachine, ICommandReader commandReader,
            CommandStrategiesFactory handlecommandStrategiesFactory)
        {
            _stateMachine = stateMachine;
            _commandReader = commandReader;
            _handlecommandStrategiesFactory = handlecommandStrategiesFactory;

            CurrentVector = new Vector(InitialRoverDirection, InitialRoverPosition);
        }

        public void Operate()
        {
            while (_stateMachine.State is RoverState.Operating)
            {
                var command = _commandReader.ReadCommand();

                var strategy = _handlecommandStrategiesFactory.GetCommandStrategy(command);

                CurrentVector = strategy.Apply(CurrentVector);

                // TODO: use logger instead
                Console.WriteLine(
                    $"Rover is now at {CurrentVector.Position.X}, {CurrentVector.Position.Y} - facing {CurrentVector.Direction}");
            }
        }
    }
}