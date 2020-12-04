using System;
using System.Linq;

namespace Day4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var values = System.IO.File
                .ReadAllLines("/Users/juleswijt/Development/AdventOfCode/2020/AdventOfCode2020/input/Day4.txt");

            var scanner = new Scanner();
            var passports = scanner.Scan(values);

            var simpleValidator = new PassportSimpleValidator();
            Console.Write("Part 1: ");
            Console.WriteLine(
                $"Number of valid passports: {passports.Count(x => simpleValidator.Validate(x).IsValid)}");
            
            var validator = new PassportValidator();
            Console.Write("Part 2: ");
            Console.WriteLine(
                $"Number of valid passports: {passports.Count(x => validator.Validate(x).IsValid)}");
        }
    }
}