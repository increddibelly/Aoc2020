using Day08;
using Day08.Instructions;
using FluentAssertions;
using NUnit.Framework;

namespace Aoc2020Tests
{
    public class Day08
    {
        private IInstruction[] instructionSet = new IInstruction[] {
            new Acc(),
            new Jmp(),            
            new Nop()
        };


        [Test]
        public void ShouldParseExample()
        {
            // Arrange

            // Act
            var code = new ComputerProgram(Input.Example, instructionSet);

            // Assert
            code[0].Key.Name.Should().Be(new Nop().Name);
        }

        [Test]
        public void ShouldRunExample()
        {
            // Arrange
            var code = new ComputerProgram(Input.Example, instructionSet);
            var computer = new Computer(code, instructionSet);

            // Act
            var result = computer.Run();

            // Assert
            result.Should().Be(5);
        }

        [Test]
        public void ShouldRunPuzzle1()
        {
            // Arrange
            var code = new ComputerProgram(Input.Value, instructionSet);
            var computer = new Computer(code, instructionSet);

            // Act
            var result = computer.Run();

            // Assert
            result.Should().Be(1832);
        }


        [Test]
        public void ShouldRunExample2()
        {
            // Arrange
            var code = new ComputerProgram(Input.Example, instructionSet);
            var computer = new Debugger(code, instructionSet);

            // Act
            var result = computer.Debug();

            // Assert
            result.Should().Be(8);
        }


        [Test]
        public void ShouldRunPuzzle2()
        {
            // Arrange
            var code = new ComputerProgram(Input.Value, instructionSet);
            var computer = new Debugger(code, instructionSet);

            // Act
            var result = computer.Debug();

            // Assert
            result.Should().Be(662);
        }
    }
}
