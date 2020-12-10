using System.Collections.Generic;
using System.Linq;

namespace Day10
{
    public class Jolter
    {
        public int[] Jolts { get; set; }
        public int[] Options { get; } = {1, 2, 3};
        public int OneJoltDifference { get; set; } = 0;
        public int ThreeJoltDifference { get; set; } = 1;

        public Jolter(string[] jolts)
        {
            Jolts = jolts.Select(int.Parse)
                .OrderBy(x => x)
                .ToArray();
        }

        public int CalculatePartOne()
        {
            var joltAmount = 0;
            while (joltAmount < Jolts.Max())
            {
                if (Jolts.Contains(joltAmount + 1))
                {
                    joltAmount++;
                    OneJoltDifference++;
                    continue;
                }

                if (Jolts.Contains(joltAmount + 3))
                {
                    joltAmount += 3;
                    ThreeJoltDifference++;
                }
            }

            return OneJoltDifference * ThreeJoltDifference;
        }

        public long CalculatePartTwo()
        {
            var arrangements = new Dictionary<long, long> {{Jolts.Max() + 3, 1}};
            foreach (var jolt in  new[] {0}.Concat(Jolts).Reverse())
            {
                arrangements.Add(jolt, Options
                    .Where(option => arrangements.ContainsKey(jolt + option))
                    .Sum(option => arrangements[jolt + option])
                );
            }

            return arrangements.Last().Value;
        }
    }
}