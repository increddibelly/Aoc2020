using System.Collections.Generic;
using System.Linq;

namespace Day2_Password_Policy.Rules
{
    public class EitherRule : IRule
    {
        // not used in this rule
        public string Token => _rules?.FirstOrDefault().Token;

        private readonly ICollection<IRule> _rules;

        public EitherRule(params IRule[] rules)
        {
            _rules = rules;
        }

        public bool Valid(Password password)
        {
            var v1 = _rules.First().Valid(password);
            var v2 = _rules.Last().Valid(password);

            var valid = _rules.Where(x => x.Valid(password)).ToArray();
            return valid.Length == 1;
        }
    }
}
