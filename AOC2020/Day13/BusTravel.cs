using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Day13
{
    public class BusTravel
    {
        private long[] BusTimes;
        public long CurrentTime { get; }

        public BusTravel(string input)
        {
            var parts = input.Split(Environment.NewLine);
            CurrentTime = long.Parse(parts[0]);
            BusTimes = parts[1].Replace("x", "0").Replace(" ","").Split(",").Select(time => long.Parse(time)).ToArray();
        }

        public long InitialWait(long timestamp)
        {
            var nextBuses = EarliestDeparturesAfter(timestamp);
            var nextBus = nextBuses.OrderBy(x => x.Value).First();
            return nextBus.Key * (nextBus.Value - timestamp);
        }

        public bool DoesBusDepartAtTimestamp(long timestamp, long busId)
        {
            return busId == 0 || timestamp % busId == 0;
        }

        public long EarliestDeparture(long timestamp, long busId)
        {
            var t = timestamp;
            do
            {
                var mod = t % busId;
                if (mod == 0) return t;
                t+=busId-mod;
            } while (true);
        }

        public long BrutalFindSequentialDepartures(long seed = 1)
        {
            var first = BusTimes[0];
            var last = BusTimes.Last();
            long timestamp = 1 + EarliestDeparture(seed + 1, first);
            long attempts = 0;
            do
            {
                // to have some measure of progress
                if (attempts++ % 100000000 == 0)
                    Debug.WriteLine($"attempts: {attempts - 1} @ timestamp {timestamp - 1}");

                // the first option is always valid so we skip that option and skip that timestamp
                var t = timestamp;
                foreach (var busId in BusTimes.Skip(1))
                {
                    if (!DoesBusDepartAtTimestamp(t++, busId))
                    {
                        break;
                    }
                    if (busId == last)
                        return timestamp - 1; // we skipped the first, but the first is the answer
                }

                timestamp = 1 + EarliestDeparture(timestamp + 1, first); // find the first valid option
            } while (true);
        }
        public long FindSequentialDepartures(long seed = 1)
        {
            var firstBus = BusTimes[0];
            var lastBus = BusTimes.Last();
            long timestamp = 1 + EarliestDeparture(seed + 1, firstBus);
            long attempts = 0;

            var targets = new List<int>();

            for (var i = 0; i<BusTimes.Length; i++)
            {

            }


            do
            {
                // to have some measure of progress
                if (attempts++ % 1000000 == 0)
                    Debug.WriteLine($"attempts: {attempts - 1} @ timestamp {timestamp - 1}");

                // the first option is always valid so we skip that option and skip that timestamp
                var t = timestamp;
                foreach (var busId in BusTimes.Skip(1))
                {
                    if (busId == 0)
                    {
                        // zeroes are fine.
                        t++;
                    }

                    if (!DoesBusDepartAtTimestamp(t++, busId))
                    {
                        break;
                    }

                    if (busId == lastBus)
                        return timestamp - 1; // we skipped the first, but the first is the answer
                }

                timestamp = 1 + EarliestDeparture(timestamp + 1, firstBus); // find the first valid option
            } while (true);
        }

        public Dictionary<long, long> EarliestDeparturesAfter(long timestamp)
        {
            return BusTimes.Where(bus => bus != 0).ToDictionary(bus => bus, bus => EarliestDeparture(timestamp, bus));
        }
    }
}
