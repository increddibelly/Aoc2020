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
            var result = bus.InitialWait();

            // Assert
            result.Should().Be(295);
        }

        [Test]
        public void ShouldRunPuzzle1()
        {

            // Arrange
            var bus = new BusTravel(Input.Value);

            // Act
            var result = bus.InitialWait();

            // Assert
            result.Should().Be(295);
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
