namespace Day2_Password_Policy.Rules
{
    public class OccursAtPositionRule : IRule
    {
        public string Token { get; private set; }
        public readonly int Position;

        public OccursAtPositionRule(string token, int position)
        {
            Token = token;
            Position = position-1;
        }

        public bool Valid(Password password)
        {
            var haystack = password.Value.Substring(Position);
            return haystack.StartsWith(Token);
        }
    }
}
