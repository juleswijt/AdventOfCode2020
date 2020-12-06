using System;
using System.Linq;

namespace Day6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var values = System.IO.File
                .ReadAllLines("/Users/juleswijt/Development/AdventOfCode/2020/AdventOfCode2020/input/Day6.txt");

            var counter = new QuestionCounter(values);

            Console.Write("Part 1: ");
            Console.WriteLine($"The sum of answered questions: {counter.SumTotalAnsweredYes()}");
            
            Console.Write("Part 2: ");
            Console.WriteLine($"The sum of answered questions in group: {counter.SumTotalAnsweredYesInGroup()}");
        }
    }
}