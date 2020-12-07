using System;

namespace Day7
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var input = System.IO.File
                .ReadAllLines("/Users/juleswijt/Development/AdventOfCode/2020/AdventOfCode2020/input/Day7.txt");
            
            Console.Write("Part 1: ");
            Console.WriteLine(
                $"There are {LuggageProcessor.ProcessPartOne(input)} bags that can contain the shiny gold bag");

            Console.Write("Part 2: ");
            Console.WriteLine($"There are {LuggageProcessor.ProcessPartTwo(input)} bags required");
        }
    }
}