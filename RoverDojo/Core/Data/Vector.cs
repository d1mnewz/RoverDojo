namespace RoverDojo.Core.Data
{
    public class Vector : ValueObject<Vector>
    {
        public Vector(Direction direction, Point position)
        {
            Direction = direction;
            Position = position;
        }

        public Direction Direction { get; }
        public Point Position { get; }
    }
}