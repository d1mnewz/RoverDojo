using System;
using RoverDojo.Core.Data;
using RoverDojo.Strategies.Contract;

namespace RoverDojo.Strategies.Impl
{
    public class MoveForwardCommandStrategy : ICommandStrategy
    {
        public Vector Apply(Vector vector)
        {
            Point position;
            switch (vector.Direction)
            {
                case Direction.North:
                    position = new Point(vector.Position.X - 1, vector.Position.Y);
                    break;
                case Direction.East:
                    position = new Point(vector.Position.X, vector.Position.Y + 1);
                    break;
                case Direction.South:
                    position = new Point(vector.Position.X + 1, vector.Position.Y);
                    break;
                case Direction.West:
                    position = new Point(vector.Position.X, vector.Position.Y - 1);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return new Vector(vector.Direction, position);
        }
    }
}