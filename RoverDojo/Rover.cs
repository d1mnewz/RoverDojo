using System;

namespace RoverDojo
{
    public class Rover
    {
        public void Operate()
        {
            var roverPositionX = 0;
            var roverPositionY = 0;
            var roverFacing = RoverFacingDirection.North;

            while (true)
            {
                var command = Console.ReadLine();
                if (command != "L" && command != "R" && command != "F")
                    throw new Exception("invalid command");

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