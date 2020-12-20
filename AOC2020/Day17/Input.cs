using System;
using System.Collections.Generic;
using System.Text;

namespace Day17
{
    public static class Input
    {
        public static string Example = @".#.
..#
###";
        public static string Value = @"#.#####.
#..##...
.##..#..
#.##.###
.#.#.#..
#.##..#.
#####..#
..#.#.##";

        public static Space Parse(string input)
        {
            var space = new Space();
            var plane = input.Split(Environment.NewLine);
            var z = 0;

            for (var y = 0; y < plane.Length; y++)
            {
                for (var x = 0; x < plane[0].Length; x++)
                {
                    var point = plane[y][x];
                    space.Set(x, y, z, point == '#');
                }
            }
            return space;
        }
    }
}
