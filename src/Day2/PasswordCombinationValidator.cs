using System.Linq;

namespace Day2
{
    public class PasswordCombinationValidator
    {
        public int ValidatePartOne(PasswordCombination[] combinations)
        {
            return (from combination in combinations
                let count = combination.Password.Count(f => f == combination.Character)
                where count >= combination.First && count <= combination.Second
                select combination).Count();
        }

        public int ValidatePartTwo(PasswordCombination[] combinations)
        {
            var numberOfValid = 0;
            foreach (var combination in combinations)
            {
                if (combination.Password[combination.First - 1] == combination.Character ^ 
                    combination.Password[combination.Second - 1] == combination.Character)
                {
                    continue;
                }

                numberOfValid++;
            }

            return numberOfValid;
        }
    }
}