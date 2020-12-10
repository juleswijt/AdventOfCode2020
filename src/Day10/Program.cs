using System;
using System.IO;

namespace Day10
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var input = File
                .ReadAllLines(
                    "/Users/juleswijt/Development/AdventOfCode/2020/AdventOfCode2020/src/Day10/Input/input.txt");
            
            var jolter = new Jolter(input);
            
            Console.Write("Part 1: ");
            Console.WriteLine($"The accumulated value is {jolter.CalculatePartOne()}");
            
            Console.Write("Part 2: ");
            Console.WriteLine($"The accumulated value is {jolter.CalculatePartTwo()}");
        }
    }
}