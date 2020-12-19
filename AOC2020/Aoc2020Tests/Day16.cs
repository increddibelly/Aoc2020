using NUnit.Framework;
using Day16;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using System.Linq;

namespace Aoc2020Tests
{
    public class Day16
    {
        [Test]
        public void ShouldRunExample()
        {
            // Arrange
            var tv = new TicketValidator(Input.Example);

            // Act
            var baddies = tv.Validate();

            // Assert
            tv.ErrorScanningRate.Should().Be(71);
        }

        [Test]
        public void ShouldRunPuzzle1()
        {
            // Arrange
            var tv = new TicketValidator(Input.Value);

            // Act
            var baddies = tv.Validate();

            // Assert
            tv.ErrorScanningRate.Should().Be(21956);
        }

        [Test]
        public void ShouldRunExample2()
        {
            // Arrange
            var tv = new TicketValidator(Input.Example);
            var goodies = tv.Validate();

            // Act
            var map = tv.FieldOrder(goodies);

            // Assert
            map.First().Key.Name.Should().Be("class or class");
            map.First().Value.Should().Be(0);
            map.Last().Value.Should().Be(2);
        }


        [Test]
        public void ShouldRunPuzzle2()
        {
            // Arrange
            var tv = new TicketValidator(Input.Value);
            var goodies = tv.Validate();

            // Act
            var map = tv.FieldOrder(goodies);
            var hash = tv.GetDepartureHash(map);

            // Assert
            hash.Should().Be(19072959382097);
        }
    }
}
