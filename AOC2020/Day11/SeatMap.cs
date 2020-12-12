using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Day11
{
    public class SeatMap
    {
        public const char Empty = 'L';
        public const char Occupied = '#';
        public const char Floor = '.';

        private StringBuilder[] _seats;

        public int Width => _seats[0].Length;
        public int Height => _seats.Length;

        public int Count(char counting) => _seats.Sum(y => y.Count(counting));

        public char this[int x, int y]
        {
            get
            {
                return _seats[y][x];
            }
            set
            {
                _seats[y][x] = value;
            }
        }

        private char OperateOnArea(int xToCheck, int yToCheck, bool lines = false)
        {
            var couldFill = true;
            var shouldMove = false;
            var adjacentOccupiedCount = 0;

            var vectors = new Dictionary<Direction, Vector> {
                { Direction.North, new Vector { X = 0, Y = -1 } },
                { Direction.NorthEast, new Vector { X = 1, Y = -1 } },
                { Direction.East, new Vector { X = 1, Y = 0 } },
                { Direction.SouthEast, new Vector { X = 1, Y = 1 } },
                { Direction.South, new Vector { X = 0, Y = 1 } },
                { Direction.SouthWest, new Vector { X = -1, Y = 1 } },
                { Direction.West, new Vector { X = -1, Y = 0 } },
                { Direction.NorthWest, new Vector { X = -1, Y = -1 } },
            };

            var actual = this[xToCheck, yToCheck];
            if (actual == SeatMap.Floor)
            {
                // floor tiles never move or get sat on.
                couldFill = false;
                shouldMove = false;
            }
            else
            {
                if (actual == SeatMap.Empty)
                {
                    couldFill = true;
                }

                if (lines)
                {
                    var seatsSeen = new Dictionary<Direction, char>();
                    var outOfBounds = new Dictionary<Direction, bool>();

                    var factor = 1;
                    do
                    {
                        foreach (var vec in vectors)
                        {
                            if (seatsSeen.ContainsKey(vec.Key))
                                continue;

                            var vector = vec.Value;
                            var myX = xToCheck + factor * vector.X;
                            var myY = yToCheck + factor * vector.Y;
                            if ((myX < 0 || myX >= Width) ||
                                (myY < 0 || myY >= Height))
                            {
                                // out of bounds, so apparently no reason to block this direction
                                seatsSeen.Add(vec.Key, Floor); 
                                continue;
                            }

                            var current = this[myX, myY];
                            if (current == SeatMap.Floor)
                            {
                                continue;
                            }
                            else
                            {
                                seatsSeen.Add(vec.Key, current);
                            }
                        }

                        factor++;
                    } while (seatsSeen.Count() < 8);
                    if (seatsSeen.Count(x => x.Value == Occupied) >= 5)
                    {
                        shouldMove = true;
                        couldFill = false;
                    } else
                    {
                        if (this[xToCheck, yToCheck] == Empty)
                        {
                            shouldMove = false;
                            couldFill = true;
                            adjacentOccupiedCount = 0; // hack
                        };
                    }
                }
                else
                {
                    CheckArea(xToCheck, yToCheck, (current, x, y) =>
                    {
                        if (current == SeatMap.Occupied)
                            adjacentOccupiedCount++;
                    }, false);
                    if (adjacentOccupiedCount >= 4)
                    {
                        shouldMove = true; // too busy around here
                        couldFill = false;
                    }
                }
            }            

            if (couldFill && adjacentOccupiedCount == 0)
            {
                return SeatMap.Occupied;
            }

            if (shouldMove)
            {
                return SeatMap.Empty;
            }

            // no change
            return actual;
        }

        private Direction FindDirection(int fromX, int fromY, int x, int y)
        {
            if (x == fromX && y < fromY) return Direction.North;
            if (x == fromX && y > fromY) return Direction.South;
            if (x < fromX && y == fromY) return Direction.West;
            if (x > fromX && y == fromY) return Direction.East;
            if (x < fromX && y < fromY) return Direction.NorthWest;
            if (x > fromX && y < fromY) return Direction.NorthWest;
            if (x < fromX && y > fromY) return Direction.SouthWest;
            if (x > fromX && y > fromY) return Direction.SouthEast;
            return Direction.Unknown;
        }

        private void CheckLines(int xToCheck, int yToCheck, Action<char> operation, bool checkCenter = false)
        {
            // check around point in increasing circles or until map edge
            var occupiedSeatsSeen = new Dictionary<Direction, bool>();
            var outsideBounds = false;
            var offset = 1;
            do
            {
                CheckArea(xToCheck, yToCheck, (current, x, y) =>
                {
                    var deltaX = Math.Abs(x - xToCheck);
                    var deltaY = Convert.ToDecimal(Math.Abs(y - yToCheck));

                    if (deltaX == 0 || deltaY == 0 || deltaX / deltaY == 1)
                    {
                        if (current == SeatMap.Occupied)
                        {
                            var direction = FindDirection(xToCheck, yToCheck, x, y);
                            if (!occupiedSeatsSeen.ContainsKey(direction))
                            {
                                occupiedSeatsSeen.Add(direction, true);
                            }
                        }
                    }
                }, false, offset++);

                outsideBounds =
                    (xToCheck - offset < 0 && xToCheck + offset >= Width) ||
                    (yToCheck - offset < 0 && yToCheck + offset >= Height);

            } while (occupiedSeatsSeen.Count() >= 5 || outsideBounds);
        }

        private void CheckArea(int xToCheck, int yToCheck, Action<char, int, int> operation, bool checkCenter = true, int offset = 1)
        {
            for (var x = xToCheck - offset; x <= xToCheck + offset; x++)
            {
                for (var y = yToCheck - offset; y <= yToCheck + offset; y++)
                {
                    if (x < 0 || x >= Width ||
                        y < 0 || y >= Height)
                        continue;

                    if (!checkCenter && x == xToCheck && y == yToCheck)
                        continue;

                    var current = this[x, y];

                    operation(current, x, y);
                }
            }
        }

        public static SeatMap Parse(string input)
        {
            return new SeatMap
            {
                _seats = input.Split(Environment.NewLine).Select(x => new StringBuilder(x)).ToArray()
            };
        }

        public int Step()
        {
            var changes = 0;

            var newSeats = new List<StringBuilder>();

            for (var y = 0; y < Height; y++)
            {
                var newRow = new StringBuilder(_seats[y].ToString());
                for (var x = 0; x < Width; x++)
                {
                    var actual = this[x, y];
                    var future = OperateOnArea(x, y);
                    if (future != actual)
                        changes++;
                    newRow[x] = future;
                }
                newSeats.Add(newRow);
            }
            _seats = newSeats.ToArray();
            return changes;
        }

        public int Move()
        {
            var changed = 0;
            do
            {
                changed = Step();
            } while (changed > 0);
            return Count(SeatMap.Occupied);
        }

        public int StepLinear()
        {
            var changes = 0;

            var newSeats = new List<StringBuilder>();

            for (var y = 0; y < Height; y++)
            {
                var newRow = new StringBuilder(_seats[y].ToString());
                for (var x = 0; x < Width; x++)
                {
                    var actual = this[x, y];
                    var future = OperateOnArea(x, y, true);
                    if (future != actual)
                        changes++;
                    newRow[x] = future;
                }
                newSeats.Add(newRow);
            }
            _seats = newSeats.ToArray();
            return changes;
        }

        public int MoveLines()
        {
            var changed = 0;
            do
            {
                changed = StepLinear();
                foreach (var x in _seats) 
                    Debug.WriteLine(x);

                Debug.WriteLine("--");
            } while (changed > 0);
            return Count(SeatMap.Occupied);
        }

    }

    public static class ExtensionsToStringBuilder
    {
        public static int Count(this StringBuilder builder, char counting)
        {
            char[] buffer = new char[builder.Length];
            builder.CopyTo(0, buffer, 0, builder.Length);
            return buffer.Count(x => x == counting);
        }
    }

    public enum Direction : byte
    {
        Unknown = 0,
        North = 1,
        NorthEast = 2,
        East = 3,
        SouthEast = 4,
        South = 5,
        SouthWest = 6,
        West = 7,
        NorthWest = 8
    }
    public class Vector
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
