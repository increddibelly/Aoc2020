using System;

namespace Day3_Tree_map
{
    public class Map
    {
        public const char Tree = '#';
        public const char Path = '.';

        private string[] _map;
        private readonly int _width;
        private readonly int _height;

        public Map(string source)
        {
            _map = source.Split(Environment.NewLine);
            _width = _map[0].Length;
            _height = _map.Length;
        }

        public char? this[int posX, int posY]
        {
            get
            {
                var x = posX % _width;
                if (posY >= _height) return null;
                var y = posY;

                return _map[y][x];
            }
        }
    }

    public class Toboggan
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Tuple<int, int> Vector { get; set; }
        public void Move()
        {
            X += Vector.Item1;
            Y += Vector.Item2;
        }
    }

    public class Route {
        private Map _map;

        public Route(Map map)
        {
            _map = map;
        }

        public int Check(int x, int y)
        {
            var tob = new Toboggan() { Vector = Tuple.Create(x, y) };

            // Act
            var trees = 0;
            var at = _map[tob.X, tob.Y];

            do
            {
                at = _map[tob.X, tob.Y];
                if (at == Map.Tree) trees++;
                tob.Move();
            } while (at != null);

            return trees;
        }
    }
}
