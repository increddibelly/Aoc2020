namespace Day08.Instructions
{
    public class Jmp : IInstruction
    {
        public string Name => "jmp";

        public long Execute(ComputeStack stack, string input)
        {
            return long.Parse(input);
        }
    }
}
