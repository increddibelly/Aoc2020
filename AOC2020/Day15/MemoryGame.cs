using System;
using System.Collections.Generic;
using System.Linq;

namespace Day15
{
    public class MemoryGame
    {
        private Dictionary<int, List<int>> data;
        private int turn;
        private int lastNumberSpoken;
        private int previousScore;

        public MemoryGame(string input)
        {
            turn = 1;
            data = input.Split(",").Select(x => int.Parse(x))
                .ToDictionary(x => x, x => new List<int> { turn++ });
        }

        private void Add(int key, int value)
        {
            if (!data.ContainsKey(key))
            {
                data.Add(key, new List<int>());
            } 
            data[key].Add(value);
        }

        public int Run(int target = 2020)
        {
            /*
Turn 1: The 1st number spoken is a starting number, 0.
Turn 2: The 2nd number spoken is a starting number, 3.
Turn 3: The 3rd number spoken is a starting number, 6.
Turn 4: Now, consider the last number spoken, 6. Since that was the first time the number had been spoken, the 4th number spoken is 0.
Turn 5: Next, again consider the last number spoken, 0. Since it had been spoken before, the next number to speak is the difference 
        between the turn number when it was last spoken (the previous turn, 4) and the turn number of the time it was most recently 
        spoken before then (turn 1). Thus, the 5th number spoken is 4 - 1, 3.
Turn 6: The last number spoken, 3 had also been spoken before, most recently on turns 5 and 2. So, the 6th number spoken is 5 - 2, 3.
Turn 7: Since 3 was just spoken twice in a row, and the last two turns are 1 turn apart, the 7th number spoken is 1.
Turn 8: Since 1 is new, the 8th number spoken is 0.
Turn 9: 0 was last spoken on turns 8 and 4, so the 9th number spoken is the difference between them, 4.
Turn 10: 4 is new, so the 10th number spoken is 0.
            */
            var start = data.Count + 1; // start at turn 4
            lastNumberSpoken = data.Last().Key; // 6
            previousScore = 0;
            for (turn = start; turn <= target; turn++) 
            {
                // was lastNumberSpoken spoken last?
                if (data.ContainsKey(lastNumberSpoken))
                {
                    // when lastNumberSpoken spoken?
                    var lastNr = data[lastNumberSpoken];
                    var count = data[lastNumberSpoken].Count;
                    if (count > 1)
                    {
                        if (count > 1)
                        {
                            // more than once, so take the last and the before-last
                            var turnSpokenLast = lastNr[lastNr.Count - 1];
                            var turnSpokenBeforeThat = lastNr[lastNr.Count - 2];
                            previousScore = turnSpokenLast - turnSpokenBeforeThat;

                            // remember the current turn
                            Add(previousScore, turn);
                        } else
                        {
                            previousScore = 0;
                            // remember the current turn
                            Add(previousScore, turn);
                        }
                    }
                    else
                    {
                        // not enough data yet
                        previousScore = 0;
                        Add(previousScore, turn);
                    }
                } else 
                {
                    // never said before
                    Add(lastNumberSpoken, turn);
                    previousScore = 0;
                }
                lastNumberSpoken = previousScore;
            }

            return lastNumberSpoken;
        }
    }
}
