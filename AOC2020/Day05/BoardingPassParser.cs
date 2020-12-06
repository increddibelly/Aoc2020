using System;
using System.Linq;

namespace Day05
{
    public class BoardingPassParser
    {
        public static BoardingPass Parse(string input)
        {
            var rowData = input.Substring(0, 7);
            var columnData = input.Substring(7, 3);

            var row = BinaryAdapter(rowData, "F", "B");
            var column = BinaryAdapter(columnData, "L", "R");

            return new BoardingPass
            {
                Row = row,
                Column = column
            };
        }

        public static BoardingPass[] ParseMany(string input)
        {
            return input.Split(Environment.NewLine).Select(Parse).ToArray();
        }

        private static int BinaryAdapter(string input, string zero, string one) {
            var binaryData = input.Replace(zero, "0").Replace(one, "1");
            var data = Convert.ToInt32(binaryData, 2);
            return data;
        }
    }
}
