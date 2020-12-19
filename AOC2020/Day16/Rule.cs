using System;
using System.Linq;

namespace Day16
{
    public class Rule
    {
        public static IRule Parse(string input)
        {
            // departure location: 39-715 or 734-949
            var items = input.Split(": ");
            var name = items[0];
            var conditions = items[1].Split(" or ");
            if (conditions.Length > 1)
            {
                var rules = conditions.Select(con =>
                {
                    var numbers = con.Split("-").Select(x => int.Parse(x)).ToArray();
                    return new BetweenRule(name, numbers[0], numbers[1]);
                }).ToArray();

                return new OrRule(rules);
            }
            else return null;
        }
    }
}
