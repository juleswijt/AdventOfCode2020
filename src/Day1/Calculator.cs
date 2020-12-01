using System.Linq;

namespace Day1
{
    public class Calculator
    {
        public int CalculatePartOne(int[] input)
        {
            return (from a in input
                    from b in input
                    where a + b == 2020
                    select a * b)
                .FirstOrDefault();
        }

        public int CalculatePartTwo(int[] input)
        {
            return (from a in input
                    from b in input
                    from c in input
                    where a + b + c == 2020
                    select a * b * c)
                .FirstOrDefault();
        }
    }
}