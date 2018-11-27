using Microsoft.Extensions.Logging;
using RoverDojo.Core.Data;
using RoverDojo.Services;
using RoverDojo.Services.Contract;

namespace RoverDojo
{
    public class Rover
    {
        public Vector CurrentVector { get; private set; }

        public IRoverStateMachine StateMachine { get; }
        private readonly ICommandReader _commandReader;
        private readonly ICommandStrategiesFactory _commandStrategiesFactory;
        private readonly ILogger _logger;
        private const Direction InitialRoverDirection = Direction.North;
        private static readonly Point InitialRoverPosition = new Point(0, 0);

        public Rover(IRoverStateMachine stateMachine, ICommandReader commandReader,
            ICommandStrategiesFactory commandStrategiesFactory, ILogger logger)
        {
            StateMachine = stateMachine;
            _commandReader = commandReader;
            _commandStrategiesFactory = commandStrategiesFactory;
            _logger = logger;

            CurrentVector = new Vector(InitialRoverDirection, InitialRoverPosition);
        }

        public void Operate()
        {
            while (StateMachine.State is RoverState.Operating)
            {
                var command = _commandReader.ReadCommand();

                var strategy = _commandStrategiesFactory.GetCommandStrategy(command);

                CurrentVector = strategy.Apply(CurrentVector);
                _logger.LogInformation(
                    $"Rover is now at {CurrentVector.Position.X}, {CurrentVector.Position.Y} - facing {CurrentVector.Direction}");
            }
        }
    }
}