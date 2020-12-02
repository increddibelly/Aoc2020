using Day2_Password_Policy;
using Day2_Password_Policy.Rules;
using FluentAssertions;
using NUnit.Framework;
using System.Linq;

namespace Aoc2020Tests
{
    public class Day2
    {
        [TestCase("cdef", false)]
        [TestCase("bcdef", true)]
        [TestCase("bbcdef", true)]
        [TestCase("bbbcdef", true)]
        [TestCase("bbbbcdef", false)]
        public void TestRule(string input, bool expected)
        {
            var password = new Password { Value = input };
            var min = new OccursAtLeastRule("b", 1);
            var max = new OccursAtMostRule("b", 3);

            var result = min.Valid(password) && max.Valid(password);
            
            result.Should().Be(expected);
        }

        [Test]
        public void ShouldParseExample()
        {
            // Arrange
            var input = Day2Input.Example;

            // Act
            var result = PolicyParser.Parse(input, ParseMethod.SledRental);

            // Assert
            result.Count.Should().Be(3);
            var bad = result.Where(rule => rule.Value.Invalid(rule.Key).Any()).ToArray();
            bad.Length.Should().Be(1);
            bad.First().Value.Rules[0].Token.Should().Be("b");
        }

        [Test]
        public void ShouldDoPuzzle1()
        {
            // Arrange
            var policy = PolicyParser.Parse(Day2Input.Input);

            // Act
            var result = policy.ValidPasswords.Count();

            // Assert
            result.Should().Be(483);
        }

        [TestCase("A", 1, true)]
        [TestCase("A", 2, false)]
        [TestCase("G", 1, false)]
        [TestCase("F", 6, true)]
        public void ShouldTestPositionRuleIn_ABCDEF(string token, int position, bool expected)
        {
            // Arrange
            var rule = new OccursAtPositionRule(token, position);
            var password = new Password { Value = "ABCDEF" };

            // Act
            var result = rule.Valid(password);

            // Assert
            result.Should().Be(expected);
        }

        [Test]
        public void ShouldTestAnyRule()
        {
            // Arrange
            var rule1 = new OccursAtPositionRule("X", 3);
            var rule2 = new OccursAtPositionRule("A", 1);
            var rule = new AnyRule(rule1, rule2);
            var password = new Password { Value = "ABCDEF" };

            // Act
            var result = rule.Valid(password);

            // Assert
            result.Should().Be(true);
        }

        [TestCase(2, true)]
        [TestCase(3, false)]
        [TestCase(4, true)]
        public void ShouldTestEitherRule(int position, bool expected)
        {
            // Arrange
            var rule1 = new OccursAtPositionRule("A", 1);
            var rule2 = new OccursAtPositionRule("A", position);
            var rule = new EitherRule(rule1, rule2);
            var password = new Password { Value = "ABAC" };

            // Act
            var result = rule.Valid(password);

            // Assert
            result.Should().Be(expected);
        }

        [Test]
        public void ShouldParseExample2()
        {
            // Arrange
            var input = Day2Input.Example;

            // Act
            var result = PolicyParser.Parse(input, ParseMethod.OfficialTobogganCorporate);

            // Assert
            result.Count.Should().Be(3);
            var bad = result.Where(rule => rule.Value.Invalid(rule.Key).Any()).ToArray();
            bad.Length.Should().Be(2);
        }


        [Test]
        public void ShouldDoPuzzle2()
        {
            // Arrange
            var policy = PolicyParser.Parse(Day2Input.Input, ParseMethod.OfficialTobogganCorporate);

            // Act
            var result = policy.ValidPasswords.Count();

            // Assert
            result.Should().Be(482);
        }
    }
}
