namespace RoverDojo
{
    public class Program
    {
        public static void Main()
        {
            var rover = new Rover(new RoverStateMachine());
            rover.Operate();
        }
    }
}