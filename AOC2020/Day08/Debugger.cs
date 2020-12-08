using Day08.Instructions;
using System;
using ProgramLine = System.Collections.Generic.KeyValuePair<Day08.IInstruction, string>;

namespace Day08
{
    public class Debugger : Computer
    {        
        public Debugger(ComputerProgram program, params IInstruction[] instructions) 
            : base(program, instructions) {}

        public long Debug()
        {
            for (var lineToDebug = 0; lineToDebug < _program.Count; lineToDebug++)
            {
                ProgramLine originalLine;
                var debugLine = _program[lineToDebug];
                if (debugLine.Key.Name == "acc")
                {
                    // don't bother with ACC
                    continue;
                }
                else
                {
                    // clone the line
                    originalLine = new ProgramLine(debugLine.Key, debugLine.Value);
                    SwapInstruction(debugLine, lineToDebug);
                }

                var result = base.Run();

                // reset the code
                ResetLine(originalLine, lineToDebug);

                if (CompletedSuccesfully)
                {
                    return result;
                }
            }

            return -1;
        }

        private void SwapInstruction(ProgramLine line, long lineToOverwrite)
        {
            var newInstruction =
                line.Key.Name == "nop"
                    ? new Jmp()
                    : new Nop() as IInstruction;

            _program[lineToOverwrite] = new ProgramLine(newInstruction, line.Value);
        }

        private void ResetLine(ProgramLine originalLine, long lineToOverwrite)
        {
            _program[lineToOverwrite] = new ProgramLine(originalLine.Key, originalLine.Value);
        }
    }
}
