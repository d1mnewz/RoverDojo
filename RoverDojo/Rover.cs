using System;

namespace RoverDojo
{
    public class Rover
    {
        public RoverFacingDirection CurrentRoverFacingDirection { get; private set; }
        
        private readonly IRoverStateMachine _stateMachine;
        private const RoverFacingDirection InitialRoverFacingDirection = RoverFacingDirection.North;

        public Rover(IRoverStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            CurrentRoverFacingDirection = InitialRoverFacingDirection;
        }

        public void Operate()
        {
            var roverPositionX = 0;
            var roverPositionY = 0;

            while (_stateMachine.State is RoverState.Operating)
            {
                var command = Console.ReadLine();
                if (command != "L" && command != "R" && command != "F")
                {
                    _stateMachine.SetStopped();
                    // Log invalid command and stop app.
                }

                switch (command)
                {
                    case "L":
                        CurrentRoverFacingDirection = CurrentRoverFacingDirection == RoverFacingDirection.North
                            ? RoverFacingDirection.West
                            : (RoverFacingDirection) ((int) CurrentRoverFacingDirection - 1);
                        Console.WriteLine(
                            $"Rover is now at {roverPositionX}, {roverPositionY} - facing {CurrentRoverFacingDirection}");
                        break;
                    case "R":
                        CurrentRoverFacingDirection = CurrentRoverFacingDirection == RoverFacingDirection.West
                            ? RoverFacingDirection.North
                            : (RoverFacingDirection) ((int) CurrentRoverFacingDirection + 1);
                        Console.WriteLine(
                            $"Rover is now at {roverPositionX}, {roverPositionY} - facing {CurrentRoverFacingDirection}");
                        break;
                    case "F":
                        switch (CurrentRoverFacingDirection)
                        {
                            case RoverFacingDirection.North:
                                roverPositionX++;
                                break;
                            case RoverFacingDirection.East:
                                roverPositionY++;
                                break;
                            case RoverFacingDirection.South:
                                roverPositionX--;
                                break;
                            case RoverFacingDirection.West:
                                roverPositionY--;
                                break;
                        }

                        Console.WriteLine(
                            $"Rover is now at {roverPositionX}, {roverPositionY} - facing {InitialRoverFacingDirection}");
                        break;
                    default:
                        throw new Exception("invalid command");
                }
            }
        }
    }
}