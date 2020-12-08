using System;
using System.Collections.Generic;

namespace Day8
{
    public class GameConsole
    {
        public static int GetTerminatedAccumulated(List<Instruction> instructions)
        {
            AccumulateValue(instructions, out var accumulated);

            return accumulated;
        }

        public static int GetFinishedAccumulated(List<Instruction> instructions)
        {
            var possibilities = new List<List<Instruction>>();
            foreach (var instruction in instructions)
            {
                if (instruction.Action == "acc")
                {
                    continue;
                }

                var index = instructions.FindIndex(row => row == instruction);
                var possibility = new List<Instruction>(instructions)
                {
                    [index] = new Instruction(instruction.Action == "jmp" ? "nop" : "jmp", instruction.Amount)
                };


                possibilities.Add(possibility);
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

        public static bool AccumulateValue(List<Instruction> instructions, out int accumulated)
        {
            accumulated = 0;

            var index = 0;
            var parsedIndexes = new List<int>();
            while (index < instructions.Count)
            {
                if (parsedIndexes.Contains(index))
                {
                    return false;
                }

                parsedIndexes.Add(index);

                var instruction = instructions[index];

                switch (instruction.Action)
                {
                    case "nop":
                        index++;
                        continue;
                    case "jmp":
                        if (instruction.Amount == 0)
                        {
                            return false;
                        }

                        index += instruction.Amount;
                        continue;
                    case "acc":
                        accumulated += instruction.Amount;
                        index++;
                        continue;
                }
            }

            return true;
        }
    }
}