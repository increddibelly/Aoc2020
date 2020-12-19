using System.Linq;

namespace Day16
{
    public class Ticket
    {
        public readonly int[] Codes;
        public Ticket(string input)
        {
            Codes = input.Split(",").Select(x => int.Parse(x)).ToArray();
        }

        public override string ToString()
        {
            return string.Join(", ", Codes);
        }
    }
}
