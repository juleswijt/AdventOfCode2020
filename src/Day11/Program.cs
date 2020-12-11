using System;
using System.IO;

namespace Day11
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var input = File
                .ReadAllLines(
                    "/Users/juleswijt/Development/AdventOfCode/2020/AdventOfCode2020/src/Day11/Input/input.txt");
            
            var calculator = new Calculator(input);
            
            Console.Write("Part 1: ");
            Console.WriteLine($"There are {calculator.CalculatePartOne()} occupied seats");
            
            Console.Write("Part 2: ");
            Console.WriteLine($"There are {calculator.CalculatePartTwo()} occupied seats");
        }
    }
}