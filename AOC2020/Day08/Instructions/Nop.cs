namespace Day08.Instructions
{
    public class Nop : IInstruction
    {
        public string Name => "nop";

        public long Execute(ComputeStack stack, string input)
        {
            return 1;
        }
    }
}
