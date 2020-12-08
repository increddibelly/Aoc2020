using Day08.Instructions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ProgramLine = System.Collections.Generic.KeyValuePair<Day08.IInstruction, string>;

namespace Day08
{
    public class ComputerProgram : ICollection<ProgramLine>
    {
        private readonly ProgramLine[] _code;
        private readonly IInstruction[] _instructionSet;
        public ProgramLine this[long cp]
        {
            get { return _code[cp]; }
            set { _code[cp] = value; }
        }

        public ComputerProgram(string code, params IInstruction[] instructionSet)
        {
            _instructionSet = instructionSet;
            _code = Parse(code);
        }

        private ProgramLine[] Parse(string code)
        {
            return code.Split(Environment.NewLine).Select(ParseLine).ToArray();
        }

        private ProgramLine ParseLine(string line)
        {
            var operands = line.Split(" ");
            var instr = _instructionSet.Single(i => i.Name == operands[0]);
            return new ProgramLine(instr, operands[1]);
        }

        #region interface implementations
        public int Count => _code.Length;

        public bool IsReadOnly => _code.IsReadOnly;

        public void Add(ProgramLine item)
        {
            ((ICollection<ProgramLine>)_code).Add(item);
        }

        public void Clear()
        {
            ((ICollection<ProgramLine>)_code).Clear();
        }

        public bool Contains(ProgramLine item)
        {
            return ((ICollection<ProgramLine>)_code).Contains(item);
        }

        public void CopyTo(ProgramLine[] array, int arrayIndex)
        {
            ((ICollection<ProgramLine>)_code).CopyTo(array, arrayIndex);
        }

        public bool Remove(ProgramLine item)
        {
            return ((ICollection<ProgramLine>)_code).Remove(item);
        }

        public IEnumerator<ProgramLine> GetEnumerator()
        {
            return ((IEnumerable<ProgramLine>)_code).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _code.GetEnumerator();
        }
        #endregion
    }
}
