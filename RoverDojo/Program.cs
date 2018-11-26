using RoverDojo.Services.Impl;

namespace RoverDojo
{
    public class Program
    {
        public static void Main()
        {
            var roverStateMachine = new RoverStateMachine();
            var rover = new Rover(roverStateMachine, new ConsoleCommandReader(roverStateMachine));
            rover.Operate();
        }
    }
}