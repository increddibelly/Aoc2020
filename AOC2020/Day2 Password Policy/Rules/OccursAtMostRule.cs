using System;

namespace Day2_Password_Policy.Rules
{
    public class OccursAtMostRule : IRule
    {
        public string Token { get; private set; }
        public readonly int Maximum;

        public OccursAtMostRule(string token, int maxmimum)
        {
            Token = token;
            Maximum = maxmimum;
        }

        public bool Valid(Password password)
        {
            var haystack = password.Value;
            var count = haystack.Split(Token, StringSplitOptions.None).Length - 1;
            return count <= Maximum;
        }
    }
}
