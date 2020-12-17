using System;
using System.Collections.Generic;
using System.Linq;

namespace Day16
{
    public struct Rule
    {
        public string Name { get; }
        public IEnumerable<int> FirstRange { get; }
        public IEnumerable<int> SecondRange { get; }

        public Rule(string name, IEnumerable<int> firstRange, IEnumerable<int> secondRange)
        {
            Name = name;
            FirstRange = firstRange;
            SecondRange = secondRange;
        }

        public bool IsInRange(int number)
        {
            return FirstRange.Contains(number) || SecondRange.Contains(number);
        }

        public static Rule Parse(string raw)
        {
            var splitName = raw.Split(":");
            var name = splitName[0];

            var splitRanges = splitName[1].Split("or");

            var splitRange1 = splitRanges[0].Split("-").Select(int.Parse).ToArray();
            var range1 = Enumerable.Range(splitRange1.First(), splitRange1.Last() - splitRange1.First() + 1);

            var splitRange2 = splitRanges[1].Split("-").Select(int.Parse).ToArray();
            var range2 = Enumerable.Range(splitRange2.First(), splitRange2.Last() - splitRange2.First() + 1);

            return new Rule(name, range1, range2);
        }
    }
}