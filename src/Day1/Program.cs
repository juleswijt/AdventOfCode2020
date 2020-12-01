using System;
using System.Linq;

namespace Day1
{
    class Program
    {
        public static void Main(string[] args)
        {
            var calculator = new Calculator();

            var values = System.IO.File.ReadAllLines(
                    "/Users/juleswijt/Development/AdventOfCode/2020/AdventOfCode2020/input/Day1.txt")
                .Select(int.Parse)
                .ToArray();


            Console.Write("Part 1: ");
            Console.WriteLine(calculator.CalculatePartOne(values));

            Console.Write("Part 2: ");
            Console.WriteLine(calculator.CalculatePartTwo(values));
        }
    }
}