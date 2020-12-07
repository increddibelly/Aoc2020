using Day07;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Linq;

namespace Aoc2020Tests
{
    public class Day07
    {

        public static string Example = @"light red bags contain 1 bright white bag, 2 muted yellow bags.
dark orange bags contain 3 bright white bags, 4 muted yellow bags.
bright white bags contain 1 shiny gold bag.
muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.
shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.
dark olive bags contain 3 faded blue bags, 4 dotted black bags.
vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.
faded blue bags contain no other bags.
dotted black bags contain no other bags.";

        [Test]
        public void ShouldParseExample()
        {
            // Arrange.
            var input = Input.Example;

            // Act.
            var bags = input.Split(Environment.NewLine).Select(line => Bag.Parse(line)).ToArray();

            // Assert.
            bags.Length.Should().Be(9);
            bags.Where(x => x.Rules.Any(b => b.Description == "shiny gold")).Count().Should().Be(2);
        }

        [Test]
        public void ShouldRunExample()
        {
            // Arrange.
            var input = Input.Example;
            var bags = input.Split(Environment.NewLine).Select(line => Bag.Parse(line)).ToArray();
            var finder = new BagFinder(bags);

            // Act.
            var result = finder.FindBagsThatCouldContain("shiny gold");

            // Assert.
            result.Length.Should().Be(4);
            result.Should().Contain("bright white");
            result.Should().Contain("light red");
            result.Should().Contain("dark orange");
            result.Should().Contain("muted yellow");
        }

        [Test]
        public void ShouldRunPuzzle()
        {
            // Arrange.
            var input = Input.Value;
            var bags = input.Split(Environment.NewLine).Select(line => Bag.Parse(line)).ToArray();
            var finder = new BagFinder(bags);

            // Act.
            var result = finder.FindBagsThatCouldContain("shiny gold");

            // Assert.
            result.Length.Should().Be(115);
        }

        [Test]
        public void ShouldRunExamle2()
        {
            // Arrange.
            var input = Input.Example;
            var bags = input.Split(Environment.NewLine).Select(line => Bag.Parse(line)).ToArray();
            var finder = new BagFinder(bags);

            // Act.
            var result = finder.CountBagsInside("shiny gold");

            // Assert.
            result.Should().Be(32);
        }

        [Test]
        public void ShouldRunExample3()
        {
            // Arrange.
            var input = Input.Example2;
            var bags = input.Split(Environment.NewLine).Select(line => Bag.Parse(line)).ToArray();
            var finder = new BagFinder(bags);

            // Act.
            var result = finder.CountBagsInside("shiny gold");

            // Assert.
            result.Should().Be(126);
        }


        [Test]
        public void ShouldRunPuzzle2()
        {
            // Arrange.
            var input = Input.Value;
            var bags = input.Split(Environment.NewLine).Select(line => Bag.Parse(line)).ToArray();
            var finder = new BagFinder(bags);

            // Act.
            var result = finder.CountBagsInside("shiny gold");

            // Assert.
            result.Should().Be(1250);
        }
    }
}
