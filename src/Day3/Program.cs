using System;
using System.Collections.Generic;
using System.Linq;

namespace Day3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var navigator = new Navigator();
            var values = System.IO.File
                .ReadAllLines("/Users/juleswijt/Development/AdventOfCode/2020/AdventOfCode2020/input/Day3.txt")
                .Select(val => val.Select(character => character == '#' ? 1 : 0).ToArray())
                .ToArray();

            Console.Write("Part 1: ");
            Console.WriteLine($"Number of trees is: {navigator.CountTrees(values, 3, 1)}");

            Console.Write("Part 2: ");
            Console.WriteLine($"Product of trees is: {navigator.CountTreesForCombinations(values)}");
        }
    }
}