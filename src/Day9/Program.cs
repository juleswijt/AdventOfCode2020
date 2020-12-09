using System;
using System.IO;
using System.Linq;

namespace Day9
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var input = File
                .ReadAllLines("/Users/juleswijt/Development/AdventOfCode/2020/AdventOfCode2020/src/Day9/Input/input.txt")
                .Select(long.Parse)
                .ToArray();

            Console.Write("Part 1: ");
            Console.WriteLine($"The accumulated value is {Encoder.Part1(input, 25)}");
            
            Console.Write("Part 2: ");
            Console.WriteLine($"The accumulated value is {Encoder.Part2(input, 25)}");
        }
    }
}