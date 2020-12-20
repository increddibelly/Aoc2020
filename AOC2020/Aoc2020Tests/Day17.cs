using NUnit.Framework;
using Day17;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using System.Linq;

namespace Aoc2020Tests
{
    public class Day17
    {
        [Test]
        public void ShouldParseExample()
        {
            // Act
            var space = Input.Parse(Input.Example);

            // Assert
            space.Surrounding(1, 1, 0).Count(x => x.Active).Should().Be(5);
        }

        [Test]
        public void ShouldRunExample()
        {
            // Arrange
            var runner = new SpaceRunner();
            var space = Input.Parse(Input.Example);

            // Act
            space = runner.Step(space);
            var map1 = space.Print(0);

            var step1 = space.ActiveNear(1, 1, 0);
            space = runner.Step(space);
            var step2 = space.ActiveNear(1, 1, 0);
            space = runner.Step(space);
            var step3 = space.ActiveNear(1, 1, 0);
            space = runner.Step(space);
            space = runner.Step(space);
            space = runner.Step(space);
            var step6 = space.Count(x => x.Active);

            // Assert
            map1.Should().Be(@"#.#
.##
.#.");
            step1.Should().Be(4);
            step2.Should().Be(10);
            step3.Should().Be(0);
            step6.Should().Be(112);
        }

        [Test]
        public void ShouldRunPuzzle1()
        {
            // Arrange


            // Act


            // Assert

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
