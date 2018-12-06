using System;
using RoverDojo.Core.Data;
using RoverDojo.Strategies.Contract;

namespace RoverDojo.Strategies.Impl
{
    public class MoveForwardCommandStrategy : ICommandStrategy
    {
        public Vector Apply(Vector vector, int fieldSize)
        {
            var position = new Point(vector.Position.X, vector.Position.Y);
            switch (vector.Direction)
            {
                case Direction.North:
                    if (vector.Position.X > 0)
                        position = new Point(vector.Position.X - 1, vector.Position.Y);
                    break;
                case Direction.East:
                    if (vector.Position.Y < fieldSize - 1)
                        position = new Point(vector.Position.X, vector.Position.Y + 1);
                    break;
                case Direction.South:
                    if (vector.Position.X < fieldSize - 1)
                        position = new Point(vector.Position.X + 1, vector.Position.Y);
                    break;
                case Direction.West:
                    if (vector.Position.Y > 0)
                        position = new Point(vector.Position.X, vector.Position.Y - 1);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return new Vector(vector.Direction, position);
        }
    }
}