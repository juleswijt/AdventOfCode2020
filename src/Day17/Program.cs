﻿using System;

namespace Day17
{
    public class Program
    {
        public const string Test = ".#.\n..#\n###";
        public const string Input = ".###.#.#\n####.#.#\n#.....#.\n####....\n#...##.#\n########\n..#####.\n######.#";

        public static void Main(string[] args)
        {
            var computer = new Computer(Input);
            
            Console.Write("Part 1: ");
            Console.WriteLine($"Number of active cubes is {computer.CountNumberOfD3Cubes()}");
            
            Console.Write("Part 2: ");
            Console.WriteLine($"Number of active cubes is {computer.CountNumberOfD4Cubes()}");
        }
    }
}