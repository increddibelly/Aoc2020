using System.Collections.Generic;
using System.Linq;

namespace Day2_Password_Policy
{
    public class Policy : Dictionary<Password, PasswordRequirements>
    {
        public IEnumerable<Password> ValidPasswords => this.Where(x => x.Value.Valid(x.Key)).Select(x => x.Key);

        public static Policy Parse(string expr)
        {
            return PolicyParser.Parse(expr);
        }
    }
}
