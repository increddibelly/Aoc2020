using NUnit.Framework;
using Day09;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using FluentAssertions;

namespace Aoc2020Tests
{
    public class Day09
    {
        [Test]
        public void ShouldParseExample()
        {
            // Arrange

            // Act
            var result = PreambleValidator.Parse(Input.Example, Input.ExamplePreamble);

            // Assert
            result.Preamble.Last().Should().Be(576);
        }

        [TestCase(13, true)]
        [TestCase(14, false)]
        [TestCase(15, true)]
        public void ShouldRunExample(int index, bool expected)
        {
            // Arrange
            var validator = PreambleValidator.Parse(Input.Example, Input.ExamplePreamble);

            // Act
            var result = validator.ValidateAt(index);

            // Assert
            result.Should().Be(expected);
        }

        [Test]
        public void ShouldRunExample1_2()
        {
            // Arrange
            var validator = PreambleValidator.Parse(Input.Example, Input.ExamplePreamble);

            // Act
            var result = validator.Validate(out var value);

            // Assert
            value.Should().Be(127);
        }


        [Test]
        public void ShouldRunPuzzle1()
        {
            // Arrange
            var validator = PreambleValidator.Parse(Input.Value, Input.ValuePreamble);

            // Act
            var result = validator.Validate(out var badValue);

            // Assert
            result.Should().BeFalse();
            badValue.Should().Be(21806024);
        }

        [Test]
        public void ShouldRunExample2()
        {
            // Arrange
            var validator = PreambleValidator.Parse(Input.Example, Input.ExamplePreamble);

            // Act
            var weakness = validator.FindWeakness(127);

            // Assert
            weakness.Should().Be(62);
        }

        [Test]
        public void ShouldRunPuzzle2()
        {
            // Arrange
            var validator = PreambleValidator.Parse(Input.Value, Input.ValuePreamble);

            // Act
            var weakness = validator.FindWeakness(21806024);

            // Assert
            weakness.Should().Be(2986195L);
        }
    }
}
