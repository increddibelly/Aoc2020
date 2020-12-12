using NUnit.Framework;
using Day12;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;

namespace Aoc2020Tests
{
    public class Day12
    {
        [Test]
        public void ShouldParseExample()
        {
            // Arrange

            // Act
            var nav = new Navigator(Input.Example);
            var distance = nav.Move();

            // Assert
            distance.Should().Be(25);
        }

        [Test]
        public void ShouldRunPuzzle1()
        {
            // Arrange

            // Act
            var nav = new Navigator(Input.Value);
            var distance = nav.Move();

            // Assert
            distance.Should().Be(904);
        }


        [Test]
        public void ShouldRunExample2()
        {
            var nav = new Navigator(Input.Example);
            var distance = nav.MoveVector();

            // Assert
            distance.Should().Be(286);
        }


        [Test]
        public void ShouldRunPuzzle2()
        {
            // Arrange
            var nav = new Navigator(Input.Value);
            var distance = nav.MoveVector();

            // Assert
            distance.Should().Be(18747);
        }
    }
}
