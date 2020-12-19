namespace Day16
{
    public interface IRule
    {
        string Name { get; }
        bool IsValid(int input);
    }
}
