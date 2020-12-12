using System;

namespace Day12
{
    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int CalculateManhattanProduct()
        {
            return Math.Abs(X) + Math.Abs(Y);
        }
    }
}