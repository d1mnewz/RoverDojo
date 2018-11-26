namespace RoverDojo
{
    public class RoverStateMachine : IRoverStateMachine
    {
        public RoverStateMachine()
        {
            State = RoverState.Operating;
        }

        public RoverState State { get; private set; }

        public void SetOperating()
        {
            State = RoverState.Operating;
        }

        public void SetStopped()
        {
            State = RoverState.Stopped;
        }
    }

    public interface IRoverStateMachine
    {
        RoverState State { get; }
        void SetOperating();
        void SetStopped();
    }
}