using System.Linq;

namespace Day07
{
    public class Bag
    {
        public string Decor { get; set; }
        public string Color { get; set; }
        public string Description => $"{Decor} {Color}";
        public BagRule[] Rules { get; set; }

        public Bag(string decor, string color)
        {
            Decor = decor;
            Color = color;
        }

        public static Bag Parse(string input)
        {
            var rule = input
                .Replace(" bags", "").Replace(" bag", "").Replace(".", "")
                .Split(" contain ");

            // outer bag
            var terms = rule[0].Split(" ");
            var decor = terms[0];
            var color = terms[1];

            var bag = new Bag(decor, color);

            // inner bags
            var innerBags = rule[1].Split(", ");
            bag.Rules = innerBags.Select(BagRule.Parse).Where(x => x != null).ToArray();

            return bag;
        }
    }
}
