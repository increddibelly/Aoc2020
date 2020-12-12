using NUnit.Framework;
using Day11;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;

namespace Aoc2020Tests
{
    public class Day11
    {
        [Test]
        public void ShouldParseExample()
        {
            // Arrange
            // Act
            var result = SeatMap.Parse(Input.Example);

            // Assert
            result.Count(SeatMap.Occupied).Should().Be(0);
            result.Count(SeatMap.Empty).Should().Be(71);
            result.Count(SeatMap.Floor).Should().Be(29);
        }

        [Test]
        public void ShouldRunExample()
        {
            // Arrange
            var map = SeatMap.Parse(Input.Example);

            // Act
            map.Move();
            var result = map.Count(SeatMap.Occupied);

            // Assert
            result.Should().Be(37);
        }

        [Test]
        public void ShouldRunPuzzle1()
        {
            // Arrange
            var map = SeatMap.Parse(Input.Value);

            // Act
            map.Move();
            var result = map.Count(SeatMap.Occupied);

            // Assert
            result.Should().Be(2406);
        }

        [Test]
        public void ShouldRunExample2()
        {
            // Arrange
            var map = SeatMap.Parse(Input.Example);

            // Act
            map.MoveLines();
            var result = map.Count(SeatMap.Occupied);

            // Assert
            result.Should().Be(26);
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
