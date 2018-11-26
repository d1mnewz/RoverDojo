using RoverDojo.Services.Contract;

namespace RoverDojo.Services.Impl
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
}