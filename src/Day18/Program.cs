using System;
using System.IO;
using System.Linq;

namespace Day18
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var input = File.ReadAllLines(
                    "/Users/juleswijt/Development/AdventOfCode/2020/AdventOfCode2020/src/Day18/Input/input.txt")
                .Select(x => Expression.Parse(x)).ToArray();

            Console.Write("Part 1: ");
            Console.WriteLine($"Sum is {input.Sum(x => x.ProcessSum())}");
            
            Console.Write("Part 2: ");
            Console.WriteLine($"Sum is {input.Sum(x => x.ProcessAdvancedSum())}");
        }
    }
}