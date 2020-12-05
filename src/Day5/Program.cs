using System;
using System.Linq;

namespace Day5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var values = System.IO.File
                .ReadAllLines("/Users/juleswijt/Development/AdventOfCode/2020/AdventOfCode2020/input/Day5.txt");

            var reader = new PassReader();
            var passes = reader.ScanIds(values);

            Console.Write("Part 1: ");
            Console.WriteLine(
                $"Number highest seat id is: {passes.Max()}");

            Console.Write("Part 1: ");
            Console.WriteLine(
                $"I'm seated at: {reader.GetMySeat(values)}");
        }
    }
}