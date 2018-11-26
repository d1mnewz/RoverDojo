using System;
using System.Threading.Tasks;
using RoverDojo.Services.Contract;

namespace RoverDojo.Tests.Test.Mocks
{
    public class MockCommandReader : ICommandReader
    {
        public string ReadCommand()
        {
            Task.Delay(TimeSpan.FromSeconds(11)).Wait();
            throw new Exception("Fail");
        }
    }
}