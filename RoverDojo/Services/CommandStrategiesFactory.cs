﻿using RoverDojo.Strategies.Contract;
using RoverDojo.Strategies.Impl;

namespace RoverDojo.Services
{
    public interface ICommandStrategiesFactory
    {
        ICommandStrategy GetCommandStrategy(string command);
    }

    public class CommandStrategiesFactory : ICommandStrategiesFactory
    {
        public ICommandStrategy GetCommandStrategy(string command)
        {
            switch (command)
            {
                case "L":
                    return new TurnLeftCommandStrategy();
                case "R":
                    return new TurnRightCommandStrategy();
                case "F":
                    return new MoveForwardCommandStrategy();
                default:
                    // TODO:
                    // Log error
                    return null;
            }
        }
    }
}