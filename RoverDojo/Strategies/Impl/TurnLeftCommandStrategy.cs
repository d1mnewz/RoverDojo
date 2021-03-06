﻿using System;
using RoverDojo.Core.Data;
using RoverDojo.Strategies.Contract;

namespace RoverDojo.Strategies.Impl
{
    public class TurnLeftCommandStrategy : ICommandStrategy
    {
        public Vector Apply(Vector vector, int fieldSize)
        {
            Direction direction;
            switch (vector.Direction)
            {
                case Direction.North:
                    direction = Direction.West;
                    break;
                case Direction.East:
                    direction = Direction.North;
                    break;
                case Direction.South:
                    direction = Direction.East;
                    break;
                case Direction.West:
                    direction = Direction.South;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return new Vector(direction, new Point(vector.Position.X, vector.Position.Y));
        }
    }
}