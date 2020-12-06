using System.Linq;

namespace Day6
{
    public class QuestionCounter
    {
        public string[] Answers { get; }

        public QuestionCounter(string[] answers)
        {
            Answers = string
                .Join("\n", answers)
                .Split("\n\n");
        }

        public int SumTotalAnsweredYes()
        {
            var answers = Answers.Select(x => x.Replace("\n", ""));

            return answers.Sum(answer => answer.Distinct().Count());
        }

        public int SumTotalAnsweredYesInGroup()
        {
            var total = 0;
            foreach (var answer in Answers)
            {
                var singleAnswers = answer.Split("\n");
                var validChars = singleAnswers[0].ToCharArray();
                total += singleAnswers
                    .Aggregate(
                        validChars,
                        (current, single) => single.ToCharArray().Intersect(current).ToArray()
                    ).Length;
            }

            return total;
        }
    }
}