using System.Collections.Generic;
using System.Linq;

namespace Day07
{
    public class BagFinder 
    {
        public Dictionary<string, bool?> AllowedBags;
        private readonly Bag[] _bags;
        private readonly Dictionary<string, Bag> _bagmap;

        public BagFinder(IEnumerable<Bag> bags)
        {
            _bags = bags.ToArray(); ;
            _bagmap = bags.ToDictionary(x => x.Description);
            AllowedBags = bags.ToDictionary(x => x.Description, x => (bool?)null);
        }

        public string[] FindBagsThatCouldContain(string needle)
        {
            AllowedBags[needle] = true;
            
            var newOK = new List<string>();
            do
            {
                foreach(var key in newOK)
                {
                    AllowedBags[key] = true;
                }
                newOK.Clear();

                var allowedKeys = AllowedBags.Where(x => x.Value == true).Select(x => x.Key).ToArray();
                var unknownBags = AllowedBags.Where(x => x.Value == null).Select(x => x.Key).ToArray();

                foreach (var bagId in unknownBags)
                {
                    // if this bag contains any of the allowed bags, this bag is OK as well.
                    foreach (var allowed in allowedKeys)
                    {
                        var bag = _bagmap[bagId];
                        if (bag.Rules.Any(x => x.Description == allowed))
                        {
                            newOK.Add(bagId);
                        }
                    }
                }
            } while (newOK.Count() > 0); // until nothing changes anymore.
            
            AllowedBags[needle] = false;
            
            return AllowedBags.Where(x => x.Value == true).Select(x => x.Key).ToArray();
        }

        public long CountBagsInside(string myBag)
        {
            var InsideCount = _bagmap.Keys.ToDictionary(x => x, x =>(long?)null);

            foreach (var item in _bagmap)
            {
                if (!_bagmap[item.Key].Rules.Any())
                {
                    InsideCount[item.Key] = 1;
                }
            }

            var newOK = new Dictionary<string, long>();
            do
            {
                foreach (var key in newOK)
                {
                    InsideCount[key.Key] = key.Value;
                }
                newOK.Clear();

                var countedKeys = InsideCount.Where(x => x.Value != null).Select(x => x.Key).ToArray();
                var unknownBags = InsideCount.Where(x => x.Value == null).Select(x => x.Key).ToArray();

                foreach (var bagId in unknownBags)
                {
                    // if this bag contains any of the allowed bags, this bag is OK as well.
                    foreach (var counted in countedKeys)
                    {
                        var bag = _bagmap[bagId];

                        // do we know the counts for all inner bags?
                        if (bag.Rules.All(rule => countedKeys.Contains(rule.Description)))
                        {
                            // then we can calculate bagId
                            
                            long sum = 1; // the bag itself
                            
                            foreach (var rule in bag.Rules)
                            {
                                // occurrences
                                sum += rule.Count * InsideCount[rule.Description].Value;
                            }
                            newOK[bagId] = sum;
                        }
                    }
                }
            } while (newOK.Count() > 0); // until nothing changes anymore.

            return InsideCount[myBag].Value - 1; // only count what's INSIDE
        }
    }
}
