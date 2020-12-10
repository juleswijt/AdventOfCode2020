using System.Collections.Generic;
using System.Linq;

namespace Day10
{
    public class Jolter
    {
        public int[] Jolts { get; set; }

        public Jolter(string[] jolts)
        {
            Jolts = jolts.Select(int.Parse).ToArray();
        }

        public int CalculatePartOne()
        {
            var oneJoltDifference = 0;
            var threeJoltDifference = 0;

            var order = new List<int>();

            var joltAmount = 0;
            while (order.Count < Jolts.Length)
            {
                if (Jolts.Contains(joltAmount + 1))
                {
                    joltAmount++;
                    order.Add(joltAmount);
                    oneJoltDifference++;
                    continue;
                }

                if (Jolts.Contains(joltAmount + 3))
                {
                    joltAmount += 3;
                    order.Add(joltAmount);
                    threeJoltDifference++;
                }
            }

            return oneJoltDifference * (threeJoltDifference + 1);
        }

        public long CalculatePartTwo()
        {
            var routes = new Dictionary<long, long> {{Jolts.Max() + 3, 1}};

            var jolts = new[] {0}.Concat(Jolts);
            foreach (var jolt in jolts.OrderBy(x => x).Reverse())
            {
                long combinations = 0;
                if (routes.ContainsKey(jolt + 1))
                {
                    combinations += routes[jolt + 1];
                }

                if (routes.ContainsKey(jolt + 2))
                {
                    combinations += routes[jolt + 2];
                }

                if (routes.ContainsKey(jolt + 3))
                {
                    combinations += routes[jolt + 3];
                }

                routes.Add(jolt, combinations);
            }

            return routes.Last().Value;
        }
    }
}