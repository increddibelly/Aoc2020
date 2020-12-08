namespace Day08.Instructions
{
    public class Acc : IInstruction
    {
        public string Name => "acc";

        public long Execute(ComputeStack stack, string input)
        {
            var value = long.Parse(input);
            stack.Accumulator += value;

            return 1;
        }
    }
}
