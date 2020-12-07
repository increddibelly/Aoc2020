namespace Day07
{
    public class BagRule
    {
        public string Description { get; set; }
        public int Count { get; set; }
        public static BagRule Parse(string input)
        {
            if (input == "no other")
                return null;

            var terms = input.Split(" ");
            var count = int.Parse(terms[0]);
            var decor = terms[1];
            var color = terms[2];

            return new BagRule { Count = count, Description = $"{decor} {color}" };
        }
    }
}
