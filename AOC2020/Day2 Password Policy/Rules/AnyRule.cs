using System.Collections.Generic;
using System.Linq;

namespace Day2_Password_Policy.Rules
{
    public class AnyRule : IRule
    {
        // not used in this rule
        public string Token { get; private set; }

        private readonly ICollection<IRule> _rules;

        public AnyRule(params IRule[] rules)
        {
            _rules = rules;
        }

        public bool Valid(Password password)
        {
            return _rules.Any(rule => rule.Valid(password));
        }
    }
}
