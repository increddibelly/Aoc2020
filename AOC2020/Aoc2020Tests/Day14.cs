using NUnit.Framework;
using Day14;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;

namespace Aoc2020Tests
{
    public class Day14
    {
        [Test]
        public void ShouldParseExample()
        {
            // Arrange
            var input = Input.Example.Split(Environment.NewLine);

            // Act
            var mask = new Mask(input[0]);
            mask.Verbose = true;
            var result = mask.Apply(11);

            // Assert
            result.Should().Be(73);
        }

        [Test]
        public void ShouldRunExample()
        {
            // Arrange
            var input = Input.Example.Split(Environment.NewLine);
            var runner = new BitMasker(input);

            // Act
            var reuslt = runner.Run();

            // Assert
            reuslt.Should().Be(165);
        }

        [Test]
        public void ShouldRunPuzzle1()
        {
            // Arrange
            var input = Input.Value.Split(Environment.NewLine);
            var runner = new BitMasker(input);

            // Act
            var reuslt = runner.Run();

            // Assert
            reuslt.Should().Be(6513443633260);
        }


        [Test]
        public void ShouldRunExample2()
        {
            // Arrange


            // Act


            // Assert

        }


        [Test]
        public void ShouldRunPuzzle2()
        {
            // Arrange


            // Act


            // Assert

        }
    }
}
