using System;
using System.IO;

namespace Day16
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var input = File.ReadAllLines(
                "/Users/juleswijt/Development/AdventOfCode/2020/AdventOfCode2020/src/Day16/Input/input.txt");
            var scanner = new Scanner(input);
            
            Console.Write("Part 1: ");
            Console.WriteLine($"Sum is {scanner.CalculateErrorRate()}");
            
            Console.Write("Part 2: ");
            Console.WriteLine($"Sum is {scanner.CalculateDeparture()}");
        }
    }
}