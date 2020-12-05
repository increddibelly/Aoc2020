using Day_04_passports;
using FluentAssertions;
using NUnit.Framework;
using System.Linq;

namespace Aoc2020Tests
{
    public class Day04
    {

        [Test]
        public void ShouldParsePassport()
        {
            // Arrange
            var source = Input.Example;

            // Act
            var results = PassportParser.ParseMany(source);

            // Assert
            results.Length.Should().Be(4);
            var second = results.Single(x => x[PassportPropertyType.hgt] == null);
            second[PassportPropertyType.byr].Value.Should().Be("1929");
        }

        [Test]
        public void ShouldValidate()
        {
            // Arrange
            var passports = PassportParser.ParseMany(Input.Example);
            var validator = new PassportValidator();

            // Act
            var invalid = passports.Where(passport => !validator.Validate(passport)).ToArray();

            // Assert
            invalid.Length.Should().Be(2);
            invalid.Single(p => p[PassportPropertyType.hgt] == null)[PassportPropertyType.byr].Value.Should().Be("1929");
        }

        [Test]
        public void ShouldRunPuzzle()
        {
            // Arrange
            var passports = PassportParser.ParseMany(Input.Value);
            var validator = new PassportValidator();

            // Act
            var validPassports = passports.Where(passport => validator.Validate(passport)).ToArray();

            // Assert
            validPassports.Length.Should().Be(245);
        }

        [Test]
        public void ShouldRunPuzzle2()
        {
            // Arrange
            var passports = PassportParser.ParseMany(Input.Value);
            var validator = new PassportValidator();

            // Act
            var validPassports = passports.Where(passport => validator.Validate(passport, true)).ToArray();

            // Assert
            validPassports.Length.Should().Be(133);
        }
    }
}
