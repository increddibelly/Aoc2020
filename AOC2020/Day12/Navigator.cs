using System;
using System.Linq;

namespace Day12
{
    public enum Direction : int
    {
        North = 0,
        East = 1,
        South = 2,
        West = 3,

        Front = 31,
        Right = 33,
        Left = 35
    }

    public class MoveInstruction
    {
        public Direction Direction { get; private set; } = Direction.East;
        public int Steps { get; private set; }

        public static MoveInstruction Parse(string input)
        {
            Direction direction = Direction.East;
            switch (input[0])
            {
                case 'N': direction = Direction.North; break;
                case 'E': direction = Direction.East; break;
                case 'S': direction = Direction.South; break;
                case 'W': direction = Direction.West; break;

                case 'F': direction = Direction.Front; break;
                case 'R': direction = Direction.Right; break;
                case 'L': direction = Direction.Left; break;
            }

            return new MoveInstruction
            {
                Direction = direction,
                Steps = int.Parse(input.Substring(1))
            };
        }
    }

    public class Navigator
    {
        private Direction currentDirection = Direction.East;
        private int x, y;

        private Vector Waypoint = new Vector { X = 10, Y = -1 };

        private MoveInstruction[] steps;

        public Navigator(string input)
        {
            steps = input.Split(Environment.NewLine).Select(MoveInstruction.Parse).ToArray();
        }

        private void MoveStep(Direction direction, int steps)
        {
            // move
            switch(direction)
            {
                case Direction.North: y -= steps; break;
                case Direction.East: x += steps; break;
                case Direction.South: y += steps; break;
                case Direction.West: x -= steps; break;

                case Direction.Left:  currentDirection = (Direction)((4 + (int)currentDirection - (steps / 90)) % 4); break;
                case Direction.Right: currentDirection = (Direction)((4 + (int)currentDirection + (steps / 90)) % 4); break;
                case Direction.Front: MoveStep(currentDirection, steps);  break;
            }            
        }

        public int Move()
        {
            foreach(var step in steps)
                MoveStep(step.Direction, step.Steps);
            return DistanceFrom(0, 0);
        }

        private Vector RotateVector(Vector current, Direction dir, int steps)
        {
            var output = new Vector();
            switch (dir)
            {
                case Direction.Left:
                    output.X =  current.Y;
                    output.Y = -current.X;
                    if (steps > 1) 
                        return RotateVector(output, dir, steps - 1);
                    return output;

                case Direction.Right:
                    output.X = -current.Y;
                    output.Y =  current.X;
                    if (steps > 1) 
                        return RotateVector(output, dir, steps - 1);
                    return output;
            }
            return output;
        }

        private void StepVector(Direction direction, int steps)
        {
            // move
            switch (direction)
            {
                case Direction.North: Waypoint.Y -= steps; break;
                case Direction.East:  Waypoint.X += steps; break;
                case Direction.South: Waypoint.Y += steps; break;
                case Direction.West:  Waypoint.X -= steps; break;

                case Direction.Left:  
                case Direction.Right:
                    Waypoint = RotateVector(Waypoint, direction, steps / 90); break;
                case Direction.Front:
                    x += steps * Waypoint.X;
                    y += steps * Waypoint.Y;
                    break;
            }
        }

        public int MoveVector()
        {
            foreach (var step in steps)
                StepVector(step.Direction, step.Steps);
            return DistanceFrom(0, 0);
        }

        public int DistanceFrom(int fromX = 0, int fromY = 0)
        {
            return Math.Abs(x - fromX) + Math.Abs(y - fromY);
        }
    }

    public class Vector
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
