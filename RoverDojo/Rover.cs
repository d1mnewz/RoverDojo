using System;
using RoverDojo.Services.Contract;

namespace RoverDojo
{
    public class Rover
    {
        public RoverFacingDirection CurrentRoverFacingDirection { get; private set; }
        public Point CurrentRoverPosition { get; private set; }

        private readonly IRoverStateMachine _stateMachine;
        private readonly ICommandReader _commandReader;
        private const RoverFacingDirection InitialRoverDirection = RoverFacingDirection.North;
        private static readonly Point InitialRoverPosition = new Point(0, 0);

        public Rover(IRoverStateMachine stateMachine, ICommandReader commandReader)
        {
            _stateMachine = stateMachine;
            _commandReader = commandReader;

            CurrentRoverFacingDirection = InitialRoverDirection;
            CurrentRoverPosition = InitialRoverPosition;
        }

        public void Operate()
        {
            while (_stateMachine.State is RoverState.Operating)
            {
                var command = _commandReader.ReadCommand();

                switch (command)
                {
                    case "L":
                        CurrentRoverFacingDirection = CurrentRoverFacingDirection == RoverFacingDirection.North
                            ? RoverFacingDirection.West
                            : (RoverFacingDirection) ((int) CurrentRoverFacingDirection - 1);
                        Console.WriteLine(
                            $"Rover is now at {CurrentRoverPosition.X}, {CurrentRoverPosition.Y} - facing {CurrentRoverFacingDirection}");
                        break;
                    case "R":
                        CurrentRoverFacingDirection = CurrentRoverFacingDirection == RoverFacingDirection.West
                            ? RoverFacingDirection.North
                            : (RoverFacingDirection) ((int) CurrentRoverFacingDirection + 1);
                        Console.WriteLine(
                            $"Rover is now at {CurrentRoverPosition.X}, {CurrentRoverPosition.Y} - facing {CurrentRoverFacingDirection}");
                        break;
                    case "F":
                        switch (CurrentRoverFacingDirection)
                        {
                            case RoverFacingDirection.North:
                                CurrentRoverPosition.X++;
                                break;
                            case RoverFacingDirection.East:
                                CurrentRoverPosition.Y++;
                                break;
                            case RoverFacingDirection.South:
                                CurrentRoverPosition.X--;
                                break;
                            case RoverFacingDirection.West:
                                CurrentRoverPosition.Y--;
                                break;
                        }

                        Console.WriteLine(
                            $"Rover is now at {CurrentRoverPosition.X}, {CurrentRoverPosition.Y} - facing {InitialRoverDirection}");
                        break;
                    default:
                        throw new Exception("invalid command");
                }
            }
        }
    }
}