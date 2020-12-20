using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day17
{
    public class Space : IEnumerable<Point>
    {
        private List<Point> _points = new List<Point>();

        public Point this[int x, int y, int z]
        {
            get
            {
                var point = _points.SingleOrDefault(p => p.X == x && p.Y == y && p.Z == z);
                if (point == null)
                {
                    point = new Point(x, y, z);
                }
                return point;
            }
            set
            {
                var point = _points.SingleOrDefault(p => p.X == x && p.Y == y && p.Z == z);
                if (point != null)
                {
                    point.Copy(value);
                }
                else
                {
                    _points.Add(value);
                }
            }
        }

        public void Set(int x, int y, int z, bool value)
        {
            this[x, y, z] = new Point(x, y, z) { Active = value };
        }

        public void Enable(int x, int y, int z) => Set(x, y, z, true);
        public void Disable(int x, int y, int z) => Set(x, y, z, false);

        public Point[] Surrounding(Point point)
        {
            return Surrounding(point.X, point.Y, point.Z);
        }

        public Point[] Surrounding(int x, int y, int z)
        {
            return this.Where(p =>
                p.X >= x - 1 && p.X <= x + 1 &&
                p.Y >= y - 1 && p.Y <= y + 1 &&
                p.Z >= z - 1 && p.Z <= z + 1 &&
                !(p.X == x && p.Y == y && p.Z == z) // except self;
            ).ToArray();
        }

        public int ActiveNear(int x, int y, int z)
        {
            var at = Surrounding(x, y, z).Where(p => p.Active).ToArray();
            return at.Count();
        }

        public string Print(int z)
        {
            var items =
                this.Where(p => p.Z == z).ToArray();

            var sb = new StringBuilder();

            for (var y = items.Min(p => p.Y) + 1; y < items.Max(p => p.Y); y++)
            {
                for (var x = items.Min(p => p.X) + 1; x < items.Max(p => p.X); x++)
                {
                    sb.Append((items.SingleOrDefault(p => p.X == x && p.Y == y)?.Active ?? false) ? "#" : ".");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        // Implementing IEnumerable allows for lots of Syntactic sugar looping over all points in space.
        #region IEnumerable
        public IEnumerator<Point> GetEnumerator()
        {
            return ((IEnumerable<Point>)_points).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_points).GetEnumerator();
        }
        #endregion
    }
}
