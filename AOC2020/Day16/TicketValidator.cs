using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day16
{
    public class TicketValidator
    {
        /* class: 1-3 or 5-7
        row: 6-11 or 33-44
        seat: 13-40 or 45-50

        your ticket:
        7,1,14

        nearby tickets:
        7,3,47
        40,4,50
        55,2,20
        38,6,12
        */

        private readonly IRule[] _rules;
        private readonly Ticket[] _tickets;
        private Ticket MyTicket;

        public long ErrorScanningRate { get; protected set; }

        public TicketValidator(string input)
        {
            var groups = input.Split(Environment.NewLine + Environment.NewLine);

            var rules = groups[0].Split(Environment.NewLine);
            _rules = rules.Select(x => Rule.Parse(x)).ToArray();

            var ticket = groups[1].Split(Environment.NewLine)[1];
            MyTicket = new Ticket(ticket);

            var tickets = groups[2].Split(Environment.NewLine).Skip(1);
            _tickets = tickets.Select(x => new Ticket(x)).ToArray();
        }

        public ICollection<Ticket> Validate()
        {
            var invalidCodes = new List<int>();
            var validTickets = new List<Ticket>();
            foreach (var ticket in _tickets)
            {
                var allValid = true;
                foreach (var code in ticket.Codes) 
                {
                    var anyValid = false;
                    foreach (var rule in _rules)
                    {
                        if (rule.IsValid(code))
                        {
                            anyValid = true;
                            break;
                        }
                    }

                    if (!anyValid)
                    {
                        allValid = false;
                        invalidCodes.Add(code);
                    }
                }
                if (allValid)
                {
                    validTickets.Add(ticket);
                }
            }
            ErrorScanningRate = invalidCodes.Sum();

            return validTickets;
        }

        public Dictionary<IRule, int> FieldOrder(IEnumerable<Ticket> validTickets)
        {
            var codescount = _tickets[0].Codes.Length;
            var output = new List<string>();
            var map = _rules.ToDictionary(x => x, x => -1);

            while (map.Any(x => x.Value == -1))
            {
                // foreach field on the ticket
                for (var index = 0; index < codescount; index++)
                {
                    // we already mapped this position to a rule
                    if (map.Any(x => x.Value == index))
                        continue;
                    
                    // check which rule is valid
                    foreach (var rule in _rules)
                    {
                        // we already mapped this rule to a position
                        if (map[rule] >= 0)
                            continue;
                        
                        // for all tickets, validate the same position against the rule
                        foreach (var ticket in _tickets)
                        {
                            if (!rule.IsValid(ticket.Codes[index]))
                            {
                                // this rule is suitable not for this position.
                                break;
                            }
                        }

                        // ok, this rule is valid for this position
                        map[rule] = index;
                        break;
                    }
                }
            }

            return map;
        }

        public long GetDepartureHash(Dictionary<IRule, int> fieldOrder)
        {
            // 223,139,211,131,113,197,151,193,127,53,89,167,227,79,163,199,191,83,137,149
            var result = 1L;
            foreach(var field in fieldOrder)
            {
                if (field.Key.Name.StartsWith("departure"))
                {
                    var value = MyTicket.Codes[field.Value];
                    result = result * value;
                }
            }
            return result;
        }
    }
}
