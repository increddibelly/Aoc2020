using Day3_Tree_map;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aoc2020Tests
{
    public class Day03
    {
        [Test]
        public void ShouldParseMap()
        {
            // Arrange
            var input = Input.Example;

            // Act
            var result = new Map(input);

            // Assert
            result[0, 0].Should().Be('.');
            result[14, 0].Should().Be('#');
            result[3, 11].Should().Be(null);
        }

        [Test]
        public void ShouldTraverseMap()
        {
            // Arrange
            var map = new Map(Input.Example);
            var tob = new Toboggan() { Vector = Tuple.Create(3, 1) };

            // Act
            var trees = 0;
            var at = map[tob.X, tob.Y];

            do
            {
                at = map[tob.X, tob.Y];
                if (at == Map.Tree) trees++;
                tob.Move();
            } while (at != null);

            // Assert
            trees.Should().Be(7);
        }

        [Test]
        public void ShouldRunPuzzle1()
        {
            // Arrange
            var map = new Map(Input.Value);
            var tob = new Toboggan() { Vector = Tuple.Create(3, 1) };

            // Act
            var trees = 0;
            var at = map[tob.X, tob.Y];

            do
            {
                at = map[tob.X, tob.Y];
                if (at == Map.Tree) trees++;
                tob.Move();
            } while (at != null);

            // Assert
            trees.Should().Be(232);
        }

        [Test]
        public void ShouldAlsoRunPuzzle1()
        {
            // Arrange
            var map = new Map(Input.Value);
            var route = new Route(map);

            // Act
            var trees = route.Check(3, 1);

            // Assert
            trees.Should().Be(232);
        }

        [Test]
        public void ShouldRunPuzzle2Example()
        {
            // Arrange
            var map = new Map(Input.Example);
            var route = new Route(map);
            var vectors = new[]
            {
                Tuple.Create(1, 1),
                Tuple.Create(3, 1),
                Tuple.Create(5, 1),
                Tuple.Create(7, 1),
                Tuple.Create(1, 2)
            };

            // Act;
            var result = vectors.Select(v => route.Check(v.Item1, v.Item2)).ToList();

            var count = 1;
            foreach(var r in result)
            {
                count *= r;
            }
            count.Should().Be(336);
        }

        [Test]
        public void ShouldRunPuzzle2()
        {
            // Arrange
            var map = new Map(Input.Value);
            var route = new Route(map);
            var vectors = new[]
            {
                Tuple.Create(1, 1),
                Tuple.Create(3, 1),
                Tuple.Create(5, 1),
                Tuple.Create(7, 1),
                Tuple.Create(1, 2)
            };

            // Act;
            var result = vectors.Select(v => route.Check(v.Item1, v.Item2)).ToList();

            long count = 1;
            foreach (var r in result)
            {
                count *= r;
            }
            count.Should().Be(3952291680L);
        }
    }
}
