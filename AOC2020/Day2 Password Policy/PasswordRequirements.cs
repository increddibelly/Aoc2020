using System.Collections.Generic;
using System.Linq;

namespace Day2_Password_Policy
{
    public class PasswordRequirements
    {
        public readonly string Token;
        public readonly List<IRule> Rules;

        public PasswordRequirements()
        {
            Rules = new List<IRule>();
        }

        public bool Valid(Password password) => !Invalid(password).Any();
        public IEnumerable<IRule> Invalid(Password password) => 
            Rules.Where(rule => !rule.Valid(password));
    }
}
