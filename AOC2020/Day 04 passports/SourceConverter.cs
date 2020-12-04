using System;
using System.Linq;

namespace Day_04_passports
{
    public static class SourceConverter
    {
        public static string[] Parse(string source)
        {
            var output = source.Split(Environment.NewLine + Environment.NewLine);
            output = output.Select(line => line.Replace(Environment.NewLine, " ")).ToArray();
            output = output.Select(line => line.Replace("  ", " ")).ToArray();
            return output;
        }
    }
}
