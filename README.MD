# Instructions

- There is a single file called **Rover.cs** containing a very simple, but untested solution;
- You need to refactor it to a more maintainable and testable code;
- The program should be written using **test driven development**, following the red, green, refactor steps;
- Please use one or more **design patterns** when developing your solution. This is your opportunity to show your skills, use it well;
- Don't sacrifice tests to complete the solution, this will result in a fail;
- We don't mind if the test is incomplete, we are only interested in seeing your approach;
- We are looking for the solution to be well factored and to adhere to the **SOLID** principles.

# Github

- Fork the project on github.
- Commit after every refactor cycle at least.
- Don't use branches.
- Your solution should be compatible with VS 2015.
- If you want to share some thoughts with us feel free to do it on this file.
- Try to not spend more than 3 hours to finish the tech test.

-------------------------------------------------------------

# Tech Test

A rover has been developed to map out the landscape of Mars. The rover is a robot which can move on a 5x5 grid controlled by simple commands.
Write a program which controls the movement of the Mars rover.

## The application should be a console app which prompts the controller for the instruction.

    Rotate Left : L
    Rotate Right: R
    Forward: F

## The current rover position should be output in the console.

    0,0	| 0,1 | 0,2 | 0,3

    1,0 | 1,1 | 1,2 | 1,3

    2,0 | 2,1 | 2,2 | 2,3

    3,0 | 3,1 | 3,2 | 3,3

## Requirements

As a controller user I want the rover to be able to rotate left

- Given the rover is facing North, when  the river rotates Left, Then the rover is facing West.
- Given the rover is facing West, when  the river rotates Left, Then the rover is facing South.
- Given the rover is facing South, when  the river rotates Left, Then the rover is facing East.
- Given the rover is facing East, when  the river rotates Left, Then the rover is facing  North.

As a controller user I want the rover to be able to rotate right

- Given the rover is facing North, when the rover rotates right, Then the rover is facing East.
- Given the rover is facing East, when the rover rotates right, Then the rover is facing South.
- Given the rover is facing South, when the rover rotates right, Then the rover is facing West.
- Given the rover is facing West, when the rover rotates right, Then the rover is facing North.

As a controller user I want the rover to be able to move forward

- Given the Is at position 1.1 and the rover is facing North, when the rover moves forward, the rover is in position 0,1.

As a controller I want to be able to see the rover’s position once it has moved

- When the user moves the rover to (1,1), the rover’s position is displayed in the format(1,1)

As a controller I don’t want the rover to be able to move outside the confines of the grid

- Given the Rover is facing West and is at position (0,0), when the user tries to move forward, the rovers position does not change


# Code

```csharp
using System;

namespace TechTest
{
    public class Rover
    {
        public enum RoverFacing
        {
            North,
            East,
            South,
            West
        }

        public static void Main()
        {
            var roverPositionX = 0;
            var roverPositionY = 0;
            var roverFacing = RoverFacing.North;

            while (true)
            {
                var command = Console.ReadLine();
                if (command != "L" && command != "R" && command != "F")
                    throw new Exception("invalid command");

                switch (command)
                {
                    case "L":
                        roverFacing = roverFacing == RoverFacing.North ? RoverFacing.West : (RoverFacing)((int)roverFacing - 1);
                        Console.WriteLine($"Rover is now at {roverPositionX}, {roverPositionY} - facing {roverFacing}");
                        break;
                    case "R":
                        roverFacing = roverFacing == RoverFacing.West ? RoverFacing.North : (RoverFacing)((int)roverFacing + 1);
                        Console.WriteLine($"Rover is now at {roverPositionX}, {roverPositionY} - facing {roverFacing}");
                        break;
                    case "F":
                        switch (roverFacing)
                        {
                            case RoverFacing.North:
                                roverPositionX++;
                                break;
                            case RoverFacing.East:
                                roverPositionY++;
                                break;
                            case RoverFacing.South:
                                roverPositionX--;
                                break;
                            case RoverFacing.West:
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
```