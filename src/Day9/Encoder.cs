using System;
using System.Collections.Generic;
using System.Linq;

namespace Day9
{
    public class Encoder
    {
        public static long Part1(long[] numbers, int preamble = 25)
        {
            for (var index = preamble; index < numbers.Length; index++)
            {
                var checks = numbers.Skip(index - preamble).Take(preamble).ToArray();
                var value = numbers[index];

                var combinations = new List<(long, long, long)>();
                foreach (var check in checks)
                {
                    combinations.AddRange(from crossCheck in checks
                        where check + crossCheck == value
                        select (check, crossCheck, check + crossCheck));
                }

                if (!combinations.Any())
                {
                    return value;
                }
            }

            throw new Exception();
        }

        public static long Part2(long[] numbers, int preamble = 25)
        {
            var invalidNumber = Part1(numbers, preamble);

            var filtered = numbers.Where(x => x < invalidNumber).ToArray();
            for (var index = 0; index < filtered.Length; index++)
            {
                var calculated = new List<long> {filtered[index]};
                foreach (var number in filtered.Skip(index + 1))
                {
                    calculated.Add(number);
                    if (calculated.Sum() == invalidNumber)
                    {
                        return calculated.Max() + calculated.Min();
                    }

                    if (calculated.Sum() > invalidNumber)
                    {
                        break;
                    }
                }
            }
            
            throw new Exception();
        }
    }
}