namespace RoverDojo
{
    public class RoverStateMachine : IRoverStateMachine
    {
        public RoverState State { get; private set; }

        public void SetOperating()
        {
            State = RoverState.Operating;
        }
    }

    public interface IRoverStateMachine
    {
        RoverState State { get; }
    }
}