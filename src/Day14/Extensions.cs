using System;

namespace Day14
{
    public static class Extensions
    {
        public static string ParseToBinary(this string number)
        {
            return ParseToBinary(int.Parse(number));
        }

        public static string ParseToBinary(this int number)
        {
            var binary = Convert.ToString(number, 2);
            var loop = 36 - binary.Length;
            for (var i = 0; i < loop; i++)
            {
                binary = "0" + binary;
            }

            return binary;
        }
    }
}