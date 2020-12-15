using System;

namespace Day15
{
    public class Program
    {
        private static readonly int[] Input = {9, 19, 1, 6, 0, 5, 4};
        private static readonly int[] Test1 = {0, 3, 6};
        private static readonly int[] Test2 = {2, 1, 3};
        private static readonly int[] Test3 = {1, 2, 3};

        public static void Main(string[] args)
        {
            Console.WriteLine(Game.PlayGameWith(Test1, 2020));
            Console.WriteLine(Game.PlayGameWith(Test2, 2020));
            Console.WriteLine(Game.PlayGameWith(Test3, 2020));
            Console.WriteLine(Game.PlayGameWith(Input, 2020));
            
            Console.WriteLine(Game.PlayGameWith(Input, 30000000));
        }
    }
}