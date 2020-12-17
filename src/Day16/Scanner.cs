using System;
using System.Collections.Generic;
using System.Linq;

namespace Day16
{
    public class Scanner
    {
        public Ticket MyTicket { get; }
        public Ticket[] Tickets { get; }
        public Rule[] Rules { get; }

        public Dictionary<long, Rule> FilteredRules { get; set; } = new Dictionary<long, Rule>();

        public Scanner(string[] input)
        {
            var split = string.Join("\n", input).Split("\n\n");

            Rules = split[0].Split("\n").Select(Rule.Parse).ToArray();
            MyTicket = split[1].Split("\n").Skip(1).Select(Ticket.Parse).First();
            Tickets = split[2].Split("\n").Skip(1).Select(Ticket.Parse).ToArray();
        }

        public long CalculateErrorRate()
        {
            var errorRate = 0;

            foreach (var ticket in Tickets)
            {
                foreach (var number in ticket.Values)
                {
                    if (!Rules.Any(x => x.IsInRange(number)))
                    {
                        errorRate += number;
                    }
                }
            }

            return errorRate;
        }

        public long CalculateDeparture()
        {
            var remainingTickets = new List<Ticket>();
            foreach (var ticket in Tickets)
            {
                var valid = true;
                foreach (var number in ticket.Values)
                {
                    if (Rules.Any(x => x.IsInRange(number)))
                    {
                        continue;
                    }

                    valid = false;
                }

                if (valid)
                {
                    remainingTickets.Add(ticket);
                }
            }


            var ruleOrder = new Dictionary<Rule, List<int>>();
            foreach (var ticket in remainingTickets)
            {
                var ticketOrder = Rules.ToDictionary(rule => rule, rule => new List<int>());
                for (var index = 0; index < ticket.Values.Length; index++)
                {
                    var number = ticket.Values[index];

                    foreach (var rule in Rules.Where(x => x.IsInRange(number)))
                    {
                        ticketOrder[rule].Add(index);
                    }
                }

                if (ruleOrder.Count == 0)
                {
                    ruleOrder = ticketOrder;
                    continue;
                }

                foreach (var (rule, indexes) in ruleOrder.ToArray())
                {
                    var ticketIndex = ticketOrder[rule];
                    ruleOrder[rule] = indexes.Intersect(ticketIndex).ToList();
                }
            }

            FilterRules(ruleOrder);
            
            return FilteredRules
                .Where(x => x.Value.Name.StartsWith("departure"))
                .Select(x=> x.Key)
                .Aggregate(1L, (current, key) => current * MyTicket.Values[key]);
        }

        private void FilterRules(Dictionary<Rule, List<int>> ruleOrders)
        {
            foreach (var rule in Rules)
            {
                if (ruleOrders[rule].Count == 1)
                {
                    var index = ruleOrders[rule].First();
                    FilteredRules.Add(index, rule);
                    foreach (var ruleOrder in ruleOrders)
                    {
                        ruleOrder.Value.Remove(index);
                    }
                }
            }

            if (FilteredRules.Count != ruleOrders.Count)
            {
                FilterRules(ruleOrders);
            }
        }
    }
}