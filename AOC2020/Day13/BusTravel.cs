using System;
using System.Collections.Generic;
using System.Linq;

namespace Day13
{
    public class BusTravel
    {
        private Dictionary<int, int[]> BusTimes;
        private int CurrentTime;

        public BusTravel(string input)
        {
            var parts = input.Split(Environment.NewLine);
            CurrentTime = int.Parse(parts[0]);
            var busKeys = parts[1].Replace("x,", "").Split(",").Select(time => int.Parse(time)).OrderBy(x => x).ToArray();
            BusTimes = busKeys.ToDictionary(x => x, x => AllTimesInHour(x));
        }

        public int InitialWait()
        {
            var minutes = CurrentTime % 100;
            var nextBus = FindBusNear(minutes);

            return nextBus.Key * (nextBus.Value - minutes);
        }

        public KeyValuePair<int, int> FindBusNear(int time)
        {
            var times = BusTimes.ToDictionary(
                    bus => bus.Key,
                    bus => {
                        var candidates = bus.Value.Where(b => b >= time);
                        return candidates.Any() ? candidates.Min() : -1;
                    })
                .Where(x => x.Value > -1)
                .OrderBy(x => x.Value);
            return times.First(x => x.Value > time);
        }

        public int[] AllTimesInHour(int id)
        {
            var items = new List<int>();
            for(var time = id; time < 60; time++)
            {
                if (time % id == 0)
                    items.Add(time);
            }
            return items.ToArray();
        }
    }
}
