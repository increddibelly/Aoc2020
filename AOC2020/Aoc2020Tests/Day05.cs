using Day05;
using FluentAssertions;
using NUnit.Framework;
using System.Linq;


namespace Aoc2020Tests
{
    public class Day05
    {
        [Test]
        public void ShouldParseExamples()
        {
            // Arrange
            var input = Input.Example;

            // Act
            var passes = BoardingPassParser.ParseMany(input).ToDictionary(x => x.SeatID);

            // Assert
            passes[119].Row.Should().Be(14);
            passes[119].Column.Should().Be(7);

            passes[820].Row.Should().Be(102);
            passes[820].Column.Should().Be(4);

            passes[567].Row.Should().Be(70);
            passes[567].Column.Should().Be(7);
        }

        [Test]
        public void ShouldRunPuzzle1()
        {
            // Arrange
            var input = Input.Value;

            // Act
            var pass = BoardingPassParser.ParseMany(input).OrderByDescending(x => x.SeatID).First();

            // Assert
            pass.SeatID.Should().Be(908);
        }

        [Test]
        public void ShouldRunPuzzle2()
        {
            // Arrange
            var input = Input.Value;
            var passes = BoardingPassParser.ParseMany(input)
                .OrderBy(x => x.SeatID)
                .ToDictionary(x => x.SeatID);
            int myPassID = 0;

            // Act
            foreach (var pass in passes)
            {
                if (passes.ContainsKey(pass.Key + 1))
                {
                    continue;
                }

                myPassID = pass.Key + 1;
                break;
            }


            //foreach(var pass in passes) {
            //    // 13, 14, 15, 18, 20, 22
            //    var seatID = pass.Value.SeatID;

            //    // is the neighbouring seatId already scanned?
            //    if (!passes.ContainsKey(seatID + 1))
            //    {
            //        // does the next-neighbour exist?
            //        if (passes.ContainsKey(seatID + 2))
            //        {
            //            myPassID = seatID + 1;
            //            break;
            //        }
            //    }

            //    // look the other way too, but skip the lowest row
            //    if (passes.ContainsKey(seatID - 1) && seatID > )
            //    {
            //        // does the next-neighbour exist?
            //        if (passes.ContainsKey(seatID - 2))
            //        {
            //            myPassID = seatID - 1;
            //            break;
            //        }
            //    }
            //}

            // Assert
            myPassID.Should().Be(619);
    }

}
}
