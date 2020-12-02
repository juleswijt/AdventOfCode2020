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
                var password = combination.Password;

                var hasCharacterOnFirstValue = password[combination.First - 1] == combination.Character;
                var hasCharacterOnSecondValue = password[combination.Second - 1] == combination.Character;

                if ((hasCharacterOnFirstValue && hasCharacterOnSecondValue) ||
                    (!hasCharacterOnFirstValue && !hasCharacterOnSecondValue))
                {
                    continue;
                }

                numberOfValid++;
            }

            return numberOfValid;
        }
    }
}