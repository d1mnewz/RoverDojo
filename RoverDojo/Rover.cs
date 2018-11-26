using System;

namespace RoverDojo
{
    public class Rover
    {
        private readonly IRoverStateMachine _stateMachine;

        public Rover(IRoverStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Operate()
        {
            var roverPositionX = 0;
            var roverPositionY = 0;
            var roverFacing = RoverFacingDirection.North;

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
                        roverFacing = roverFacing == RoverFacingDirection.North
                            ? RoverFacingDirection.West
                            : (RoverFacingDirection) ((int) roverFacing - 1);
                        Console.WriteLine($"Rover is now at {roverPositionX}, {roverPositionY} - facing {roverFacing}");
                        break;
                    case "R":
                        roverFacing = roverFacing == RoverFacingDirection.West
                            ? RoverFacingDirection.North
                            : (RoverFacingDirection) ((int) roverFacing + 1);
                        Console.WriteLine($"Rover is now at {roverPositionX}, {roverPositionY} - facing {roverFacing}");
                        break;
                    case "F":
                        switch (roverFacing)
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

                        Console.WriteLine($"Rover is now at {roverPositionX}, {roverPositionY} - facing {roverFacing}");
                        break;
                    default:
                        throw new Exception("invalid command");
                }
            }
        }
    }
}