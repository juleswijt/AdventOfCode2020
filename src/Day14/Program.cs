using System;
using System.IO;

namespace Day14
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var input = File
                .ReadAllLines(
                    "/Users/juleswijt/Development/AdventOfCode/2020/AdventOfCode2020/src/Day14/Input/input.txt");
            
            var emulator = new Emulator(input);
            
            Console.Write("Part 1: ");
            Console.WriteLine($"Sum is {emulator.SumPartOne()}");
            
            Console.Write("Part 2: ");
            Console.WriteLine($"Sum is {emulator.SumPartTwo()}");
        }
    }
}