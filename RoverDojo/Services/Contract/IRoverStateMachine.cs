using RoverDojo.Core.Data;

namespace RoverDojo.Services.Contract
{
    public interface IRoverStateMachine
    {
        RoverState State { get; }
        void SetOperating();
        void SetStopped();
    }
}