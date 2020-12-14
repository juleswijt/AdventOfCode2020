using System;
using System.Collections.Generic;
using System.Linq;

namespace Day14
{
    public class Emulator
    {
        public Step[] Steps { get; }

        public Emulator(string[] input)
        {
            Steps = input.Select(Step.Parse).ToArray();
        }

        public long SumPartOne()
        {
            var mask = "";
            var memory = new Dictionary<int, long>();
            foreach (var step in Steps)
            {
                if (step.GetType() == typeof(Mask))
                {
                    mask = ((Mask) step).Value;
                    continue;
                }

                var memoryStep = (Memory) step;
                var value = ApplyMaskOnValue(memoryStep, mask);
                if (memory.ContainsKey(memoryStep.Position))
                {
                    memory[memoryStep.Position] = value;
                    continue;
                }

                memory.Add(memoryStep.Position, value);
            }

            return memory.Sum(x => x.Value);
        }

        public long SumPartTwo()
        {
            var mask = "";
            var memory = new Dictionary<long, long>();
            foreach (var step in Steps)
            {
                if (step.GetType() == typeof(Mask))
                {
                    mask = ((Mask) step).Value;
                    continue;
                }

                var memoryStep = (Memory) step;
                var address = ApplyMaskOnAddress(memoryStep, mask);
                
                var possibleAddresses = new List<string> {address};
                for (var index = 0; index < address.Length; index++)
                {
                    if (address[index] == 'X')
                    {
                        foreach (var possibleAddress in possibleAddresses.ToArray())
                        {
                            var addressWithZero = possibleAddress.ToCharArray();
                            addressWithZero[index] = '0';
                            possibleAddresses.Add(new string(addressWithZero));

                            var addressWithOne = possibleAddress.ToCharArray();
                            addressWithOne[index] = '1';
                            possibleAddresses.Add(new string(addressWithOne));
                        }
                    }
                }

                foreach (var possibleAddress in possibleAddresses.Where(x => !x.Contains('X')).Distinct())
                {
                    var position = Convert.ToInt64(possibleAddress, 2);
                    memory[position] = Convert.ToInt64(memoryStep.Binary, 2);
                }
                        
            }

            return memory.Sum(x => x.Value);
        }

        private static long ApplyMaskOnValue(Memory step, string mask)
        {
            var binaryChars = step.Binary.ToCharArray();
            for (var index = 0; index < mask.ToCharArray().Length; index++)
            {
                if (mask[index] == 'X')
                {
                    continue;
                }

                binaryChars[index] = mask[index];
            }

            return Convert.ToInt64(new string(binaryChars), 2);
        }

        private static string ApplyMaskOnAddress(Memory step, string mask)
        {
            var binaryChars = step.Position.ParseToBinary().ToCharArray();
            for (var index = 0; index < mask.ToCharArray().Length; index++)
            {
                if (mask[index] == 'X' || mask[index] == '1')
                {
                    binaryChars[index] = mask[index];
                }
            }

            return new string(binaryChars);
        }
    }
}