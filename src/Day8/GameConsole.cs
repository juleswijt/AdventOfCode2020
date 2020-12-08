using System;
using System.Collections.Generic;

namespace Day8
{
    public class GameConsole
    {
        public static int GetTerminatedAccumulated(string[] input)
        {
            AccumulateValue(input, out var accumulated);

            return accumulated;
        }

        public static int GetFinishedAccumulated(string[] input)
        {
            var possibilities = new List<string[]> {input};
            foreach (var value in input)
            {
                var index = Array.FindIndex(input, row => row == value);
                if (value.Contains("jmp") || value.Contains("nop"))
                {
                    var possibility = new string[input.Length];
                    input.CopyTo(possibility, 0);

                    if (value.Contains("jmp"))
                    {
                        possibility[index] = possibility[index].Replace("jmp", "nop");
                    }

                    if (value.Contains("nop"))
                    {
                        possibility[index] = possibility[index].Replace("nop", "jmp");
                    }

                    possibilities.Add(possibility);
                }
            }

            foreach (var possibility in possibilities)
            {
                if (AccumulateValue(possibility, out var accumulated))
                {
                    return accumulated;
                }
            }

            return 0;
        }

        public static bool AccumulateValue(string[] input, out int accumulated)
        {
            var parsedIndexes = new List<int>();
            accumulated = 0;
            var index = 0;
            while (index < input.Length)
            {
                if (parsedIndexes.Contains(index))
                {
                    return false;
                }

                parsedIndexes.Add(index);

                var split = input[index].Split(" ");
                var action = split[0];
                var amount = int.Parse(split[1].Replace("+", ""));

                switch (action)
                {
                    case "nop":
                        index++;
                        continue;
                    case "jmp":
                        if (amount == 0)
                        {
                            return false;
                        }

                        index += amount;
                        continue;
                    case "acc":
                        accumulated += amount;
                        index++;
                        continue;
                }
            }

            return true;
        }
    }
}