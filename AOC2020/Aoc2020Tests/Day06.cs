using Day06;
using FluentAssertions;
using NUnit.Framework;
using System.Linq;


namespace Aoc2020Tests
{
    public class Day06
    {
        [Test]
        public void ShouldParseExamples()
        {
            // Arrange.
            var input = Input.GetInputGroups(Input.Example);

            // Act
            var groups = input.Select(Parser.ParseGroup).ToArray();

            // Assert
            groups.Length.Should().Be(5);
            var groupB = groups.OrderBy(g => g.Count()).First();
            
            var b = groupB.Forms.Single().Answers;
            b.Length.Should().Be(1);
            b.Should().Contain('b');
        }

        [Test]
        public void ShouldRunExample()
        {
            // Arrange
            var input = Input.GetInputGroups(Input.Example);
            var groups = input.Select(Parser.ParseGroup).ToArray();

            // Act
            var totalCount = groups.Sum(g => g.Distinct().Count());

            // Assert
            totalCount.Should().Be(11);
        }

        [Test]
        public void ShouldRunPuzzle()
        {
            // Arrange
            var input = Input.GetInputGroups(Input.Value);
            var groups = input.Select(Parser.ParseGroup).ToArray();

            // Act
            var totalCount = groups.Sum(g => g.Distinct().Count());

            // Assert
            totalCount.Should().Be(6911);
        }

        [Test]
        public void ShouldRunExample2()
        {

            // Arrange
            var input = Input.GetInputGroups(Input.Example);
            var groups = input.Select(Parser.ParseGroup).ToArray();

            // Act
            var totalCount = groups.Sum(g => g.All().Count());

            // Assert
            totalCount.Should().Be(6);
        }

        [Test]
        public void ShouldRunPuzzle2()
        {

            // Arrange
            var input = Input.GetInputGroups(Input.Value);
            var groups = input.Select(Parser.ParseGroup).ToArray();

            // Act
            var totalCount = groups.Sum(g => g.All().Count());

            // Assert
            totalCount.Should().Be(3473);
        }
    }
}
