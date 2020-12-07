using System;
using System.Collections.Generic;
using System.Linq;

namespace Day7
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var input = System.IO.File
                .ReadAllLines("/Users/juleswijt/Development/AdventOfCode/2020/AdventOfCode2020/input/Day7.txt");

            var bags = LuggageProcessor.ProcessBags(input);

            Console.Write("Part 1: ");
            Console.WriteLine(
                $"There are {bags.Count(b => b.ContainsBag("shinygold")) - 1} bags that can contain the shiny gold bag");

            Console.Write("Part 2: ");
            Console.WriteLine($"There are {bags.First(b => b.Color == "shinygold").CountBags()} bags required");
        }
    }
}