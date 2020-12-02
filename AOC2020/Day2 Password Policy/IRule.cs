namespace Day2_Password_Policy
{
    public interface IRule
    {
        string Token { get; }
        bool Valid(Password password);
    }
}
