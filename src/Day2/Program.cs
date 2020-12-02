using System;
using System.Linq;

namespace Day2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var validator = new PasswordCombinationValidator();
            var values = System.IO.File
                .ReadAllLines("/Users/juleswijt/Development/AdventOfCode/2020/AdventOfCode2020/input/Day2.txt")
                .Select(x => new PasswordCombination(x))
                .ToArray();

            Console.Write("Part 1: ");
            Console.WriteLine(validator.ValidatePartOne(values));
            
            Console.Write("Part 2: ");
            Console.WriteLine(validator.ValidatePartTwo(values));
        }
    }
}