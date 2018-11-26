namespace RoverDojo.Tests
{
    public class MockRoverStateMachine : IRoverStateMachine
    {
        public RoverState State { get; set; }
        public void SetOperating()
        {
            throw new System.NotImplementedException();
        }

        public void SetStopped()
        {
            throw new System.NotImplementedException();
        }
    }
}