using System;
using System.Collections.Generic;
using System.Linq;

namespace Day10
{
    public class JoltAdapter
    {
        private int[] _adapters;

        public static JoltAdapter Parse(string input)
        {
            var ad = input.Split(Environment.NewLine).Select(int.Parse).ToList();
            ad.Add(0);
            ad.Add(ad.Max() + 3);
            
            return new JoltAdapter {
                _adapters = ad.OrderBy(x => x).ToArray()
            };
        }

        public int FindDistribution()
        {
            var steps = new Dictionary<int, int> {
                { 1,0 },
                { 3,0 }
            };

            for(var index = 1; index < _adapters.Length; index++)
            {
                var current = _adapters[index];
                var prev = _adapters[index - 1];
                var diff = current - prev;
                steps[diff]+=1;
            }
            return steps[1] * steps[3];
        }

        public long FindPermutations()
        {
            var data = _adapters.OrderByDescending(x => x).ToArray();
            var pathsBehind = new Dictionary<long, long>();
            
            pathsBehind.Add(data.Max(), 1);

            for (var index = 1; index < data.Length; index++)
            {
                var current = data[index];

                var path_options = 0L;
                for (var i = 1; i <= 3; i++)
                {
                    var neighbour = current + i;

                    if (pathsBehind.ContainsKey(neighbour))
                        path_options += pathsBehind[neighbour];
                }
                pathsBehind.Add(current, path_options);
            }

            return pathsBehind.Values.Max();
        }
    }
}
