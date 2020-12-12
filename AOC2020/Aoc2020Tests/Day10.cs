using NUnit.Framework;
using Day10;
using FluentAssertions;

namespace Aoc2020Tests
{
    public class Day10
    {
        [Test]
        public void ShouldParseExample()
        {
            // Arrange
            

            // Act


            // Assert


        }

        [Test]
        public void ShouldRunExample()
        {
            // Arrange
            var jolter = JoltAdapter.Parse(Input.Example);

            // Act
            var dist = jolter.FindDistribution();

            // Assert
            dist.Should().Be(35);
        }

        [Test]
        public void ShouldRunPuzzle1()
        {

            // Arrange
            var jolter = JoltAdapter.Parse(Input.Value);

            // Act
            var dist = jolter.FindDistribution();

            // Assert
            dist.Should().Be(1690);
        }


        [Test]
        public void ShouldRunP2Example()
        {
            // Arrange
            var jolter = JoltAdapter.Parse(Input.Example);

            // Act
            var dist = jolter.FindPermutations();

            // Assert
            dist.Should().Be(8);
        }

        [Test]
        public void ShouldRunP2Example2()
        {
            // Arrange
            var jolter = JoltAdapter.Parse(Input.Example2);

            // Act
            var dist = jolter.FindPermutations();

            // Assert
            dist.Should().Be(19208);
        }


        [Test]
        public void ShouldRunPuzzle2()
        {
            // Arrange
            var jolter = JoltAdapter.Parse(Input.Value);

            // Act
            var dist = jolter.FindPermutations();

            // Assert
            dist.Should().Be(5289227976704L);
        }
    }
}
