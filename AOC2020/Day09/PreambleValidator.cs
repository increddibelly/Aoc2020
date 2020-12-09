using System;
using System.Linq;

namespace Day09
{
    public class PreambleValidator
    {
        public int PreambleLength { get; protected set; }

        public long[] Preamble { get; protected set; }

        public static PreambleValidator Parse(string input, int length)
        {
            return new PreambleValidator
            {
                PreambleLength = length,
                Preamble = input.Split(Environment.NewLine).Select(long.Parse).ToArray()
            };
        }

        public bool ValidateAt(int index)
        {
            if (index < PreambleLength) return true; // cannot be validated

            var numberToValidate = Preamble[index];

            // take a subset of the data
            var dataStart = index - PreambleLength;
            var section = Preamble.Skip(dataStart).Take(PreambleLength).ToArray();

            foreach(var number in section)
            {
                var target = numberToValidate - number;
                if (target != number && 
                    section.Contains(target))
                    return true;
            }
            return false;
        }

        public bool Validate(out long badvalue)
        {
            var index = PreambleLength;
            foreach(var number in Preamble)
            {
                if (!ValidateAt(index))
                {
                    badvalue = Preamble[index];
                    return false;
                }
                index++;
            }

            badvalue = -1;
            return true;
        }

        public long FindWeakness(long target = 21806024)
        {
            for (var startIndex = 0; startIndex < Preamble.Length; startIndex++)
            {
                long sum = 0;
                var index = startIndex;
                do
                {
                    sum += Preamble[index];
                    if (sum == target)
                    {
                        // sum the smallest and largest number in the range of startIndex..index
                        var range = index - startIndex;
                        var items = Preamble.Skip(startIndex).Take(range).ToArray();
                        var result = items.Max() + items.Min();
                        return result;
                    }
                    index++;
                } while (sum < target);
            }
            return 0;
        }
    }
}

