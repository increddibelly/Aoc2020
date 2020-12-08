namespace Day08
{
    public interface IInstruction
    {
        string Name { get; }
        long Execute(ComputeStack stack, string input);
    }
}
