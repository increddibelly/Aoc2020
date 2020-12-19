using System.Linq;

namespace Day16
{
    public class OrRule : IRule
    {
        private readonly IRule[] _rules;

        public OrRule(params IRule[] rules)
        {
            _rules = rules;
        }

        public string Name => string.Join(" or ", _rules.Select(rule => rule.Name));

        public bool IsValid(int input)
        {
            return _rules.Any(x => x.IsValid(input));
        }

        public override string ToString()
        {
            return $"Either one of {(string.Join(" or ", _rules.Select(x => x.ToString())))}";
        }
    }
}
