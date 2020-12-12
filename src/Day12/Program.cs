using System;
using System.IO;

namespace Day12
{
    
    public class Program
    {
        public static void Main(string[] args)
        {
            var input = File
                .ReadAllLines(
                    "/Users/juleswijt/Development/AdventOfCode/2020/AdventOfCode2020/src/Day12/Input/input.txt");
            
            var navigator = new Navigator(input);
            
            Console.Write("Part 1: ");
            Console.WriteLine($"Manhattan product is {navigator.GetManhattanDistancePartOne()}");
            
            Console.Write("Part 2: ");
            Console.WriteLine($"Manhattan product is {navigator.GetManhattanDistancePartTwo()}");
        }
    }
}