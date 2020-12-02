using System;

namespace Day2_Password_Policy.Rules
{
    public class OccursAtLeastRule : IRule
    {
        public string Token { get; private set; }
        public readonly int Minimum;

        public OccursAtLeastRule(string token, int minimum)
        {
            Token = token;
            Minimum = minimum;
        }

        public bool Valid(Password password)
        {
            var haystack = password.Value;
            var count = haystack.Split(Token, StringSplitOptions.None).Length - 1;
            return count >= Minimum;
        }
    }
}
