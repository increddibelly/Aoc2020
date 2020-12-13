using NUnit.Framework;
using Day13;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;

namespace Aoc2020Tests
{
    public class Day13
    {

        [Test]
        public void ShouldRunExample()
        {
            // Arrange
            var bus = new BusTravel(Input.Example);

            // Act
            var result = bus.InitialWait(bus.CurrentTime);

            // Assert
            result.Should().Be(295);
        }

        [Test]
        public void ShouldRunPuzzle1()
        {

            // Arrange
            var bus = new BusTravel(Input.Value);

            // Act
            var result = bus.InitialWait(bus.CurrentTime);

            // Assert
            result.Should().Be(5946);
        }

        [TestCase(null, 1068781)]
        [TestCase("0\r\n17, x, 13, 19", 3417)]
        [TestCase("0\r\n67, 7, 59, 61 ", 754018)]
        [TestCase("0\r\n67, x, 7, 59, 61", 779210)]
        [TestCase("0\r\n67, 7, x, 59, 61", 1261476)]
        [TestCase("0\r\n1789, 37, 47, 1889", 1202161486)]
        public void ShouldRunExample2(string input, long expected )
        {
            // Arrange
            var bus = new BusTravel(input ?? Input.Example);

            // Act
            var result = bus.FindSequentialDepartures();

            // Assert
            result.Should().Be(expected);
        }


        [Test]
        public void ShouldRunPuzzle2()
        {
            // Arrange
            var bus = new BusTravel(Input.Value);

            // Act
            var result = bus.FindSequentialDepartures(100000000000000);

            // Assert
            result.Should().Be(1068781);
        }
    }
}
