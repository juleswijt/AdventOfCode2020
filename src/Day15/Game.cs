using System;
using System.Collections.Generic;
using System.Linq;

namespace Day15
{
    public class Game
    {
        public static long PlayGameWith(int[] input, int requestNumber)
        {
            var memory = new Dictionary<long, long>();
            for (var index = 0; index < input.Length; index++)
            {
                memory[input[index]] = index + 1;
            }
            
            var iteration = input.Length + 1;
            var previous = 0L;
            while (iteration <= requestNumber)
            {
                var newPrevious = 0L;
                if (memory.ContainsKey(previous))
                {
                    newPrevious = iteration - memory[previous];
                }
            
                memory[previous] = iteration;
                previous = newPrevious;
                
                iteration++;
            }
            
            return memory.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
        }
    }
}