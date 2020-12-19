namespace Day16
{
    internal class BetweenRule : IRule
    {
        public string Name { get; }
        private int Min { get; }
        private int Max { get; }

        public BetweenRule(string name, int min, int max)
        {
            Name = name;
            Min = min;
            Max = max;
        }

        public bool IsValid(int input)
        {
            return input >=Min && input <= Max;
        }

        public override string ToString()
        {
            return $"{Name}: {Min}-{Max}";
        }
    }
}