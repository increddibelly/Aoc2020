using Day1;
using FluentAssertions;
using NUnit.Framework;

namespace Aoc2020Tests
{
    public class Day1
    {
        private Accounting _cut = new Accounting();

        [Test]
        public void Example()
        {
            // Arrange.
            var input = Day1Input.Example;

            // Act.
            var result = _cut.Find2020(input);

            // Assert.
            result.Factors.Should().Contain(299);
            result.Factors.Should().Contain(1721);
            result.Product.Should().Be(514579);
        }

        [Test]
        public void Puzzle1()
        {
            // Arrange.
            var input = Day1Input.Values;

            // Act.
            var result = _cut.Find2020(input);

            // Assert.
            result.Factors.Should().Contain(1228);
            result.Factors.Should().Contain(792);
            result.Product.Should().Be(972576L);
        }

        [Test]
        public void example_2()
        {
            // Arrange.
            var input = Day1Input.Example;

            // Act.
            var result = _cut.Find2020_3(input);

            // Assert.
            result.Factors.Should().Contain(979);
            result.Factors.Should().Contain(366);
            result.Factors.Should().Contain(675);
            result.Product.Should().Be(241861950L);
        }

        [Test]
        public void Puzzle2()
        {
            // Arrange.
            var input = Day1Input.Values;

            // Act.
            var result = _cut.Find2020_3(input);

            // Assert.
            result.Factors.Should().Contain(268);
            result.Factors.Should().Contain(722);
            result.Factors.Should().Contain(1030);
            result.Product.Should().Be(199300880L);
        }

    }
}
