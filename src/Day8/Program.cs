using System;
using System.Linq;

namespace Day8
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var input = System.IO.File
                .ReadAllLines(
                    "/Users/juleswijt/Development/AdventOfCode/2020/AdventOfCode2020/src/Day8/Input/input.txt")
                .Select(Instruction.Parse)
                .ToList();

            Console.Write("Part 1: ");
            Console.WriteLine($"The accumulated value is {GameConsole.GetTerminatedAccumulated(input)}");

            Console.Write("Part 2: ");
            Console.WriteLine($"The accumulated value is {GameConsole.GetFinishedAccumulated(input)}");
        }
    }
}