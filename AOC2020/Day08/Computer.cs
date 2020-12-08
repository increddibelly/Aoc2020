using System;
using System.Collections.Generic;
using System.Linq;

namespace Day08
{
    public class Computer
    {
        public bool CompletedSuccesfully { get; protected set; }

        protected readonly IInstruction[] _instructionSet;
        protected readonly ComputerProgram _program;
        protected Dictionary<long, bool> _visitedInstructions;
        protected ComputeStack _stack;

        // alias
        protected long cp => _stack.CodePointer;

        public Computer(ComputerProgram program, params IInstruction[] instructionSet)
        {
            _program = program;
            _instructionSet = instructionSet;
        }

        private bool _completed => cp == _program.Count;

        private void Reset() 
        {
            _visitedInstructions = new Dictionary<long, bool>();
            _visitedInstructions[0] = true;
            _stack = new ComputeStack();
        }

        public long Run()
        {
            Reset();
            do
            {
                var line = _program[cp];
                
                var instruction = _instructionSet.Single(x => x.Name == line.Key.Name);

                var offset = instruction.Execute(_stack, line.Value);

                _stack.CodePointer += offset;

                if (_visitedInstructions.ContainsKey(cp))
                {
                    // next instruction would start an infinite loop; break;
                    CompletedSuccesfully = false;
                    return _stack.Accumulator;
                }
                else
                {
                    _visitedInstructions[cp] = true;
                }
            } while (!_completed);
            
            CompletedSuccesfully = _completed;
            
            return _stack.Accumulator;
        }

    }
}
