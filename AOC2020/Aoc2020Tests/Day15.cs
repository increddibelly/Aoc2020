using NUnit.Framework;
using Day15;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;

namespace Aoc2020Tests
{
    public class Day15
    {
        [Test]
        public void ShouldParseExample()
        {
            // Arrange
            var input = Input.Example;

            // Act
            var game = new MemoryGame(input);

            // Assert
            game.Run(10).Should().Be(0);
        }

        [TestCase("1, 3, 2", 1)]
        [TestCase("2, 1, 3", 10)]
        [TestCase("1, 2, 3", 27)]
        [TestCase("2, 3, 1", 78)]
        [TestCase("3, 2, 1", 438)]
        [TestCase("3, 1, 2", 1836)]
        public void ShouldRunExample(string input, int expected)
        {
            // Arrange
            var game = new MemoryGame(input);

            // Act
            var result = game.Run(2020);

            // Assert
            result.Should().Be(expected);
        }

        [Test]
        public void ShouldRunPuzzle1()
        {
            // Arrange
            var game = new MemoryGame(Input.Value);

            // Act
            var result = game.Run(2020);

            // Assert
            result.Should().Be(1238);
        }


        [Test]
        public void ShouldRunExample2()
        {
            // Arrange
            var game = new MemoryGame(Input.Example);

            // Act
            var result = game.Run(30000000);

            // Assert
            result.Should().Be(175594);
        }


        [Test]
        public void ShouldRunPuzzle2()
        {
            // Arrange
            var game = new MemoryGame(Input.Value);

            // Act
            var result = game.Run(30000000);

            // Assert
            result.Should().Be(3745954);
        }
    }
}
