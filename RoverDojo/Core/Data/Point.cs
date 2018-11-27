namespace RoverDojo.Core.Data
{
    public class Point : ValueObject<Point>
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }
    }
}