using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RoverDojo.Services;
using RoverDojo.Services.Impl;
using Serilog;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace RoverDojo
{
    public class Program
    {
        public static void Main()
        {
            var logger = CreateLogger();
            var roverStateMachine = new RoverStateMachine();
            var rover = new Rover(roverStateMachine, new ConsoleCommandReader(roverStateMachine, logger),
                new CommandStrategiesFactory(), logger);
            
            rover.Operate();
        }

        private static ILogger CreateLogger()
        {
            var logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();

            var loggerFactory = new LoggerFactory().AddSerilog(logger);

            var provider = new ServiceCollection()
                .AddOptions()
                .AddSingleton(loggerFactory)
                .BuildServiceProvider();

            return provider.GetService<ILoggerFactory>().CreateLogger(typeof(Program));
        }
    }
}