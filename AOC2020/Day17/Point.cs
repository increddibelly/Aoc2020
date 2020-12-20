using System;
using System.Text;

namespace Day17
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public bool Active = false;

        public Point(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        internal void Copy(Point value)
        {
            Active = value.Active;
        }
    }
}
