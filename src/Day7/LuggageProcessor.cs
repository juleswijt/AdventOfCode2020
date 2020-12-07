using System.Collections.Generic;
using System.Linq;

namespace Day7
{
    public class LuggageProcessor
    {
        public static List<Bag> ProcessBags(string[] rawBags)
        {
            var bags = new List<Bag>();
            foreach (var rawBag in rawBags)
            {
                var sentence = rawBag.Split(" ");
                var bag = new Bag {Color = sentence[0] + sentence[1]};

                var index = 4;
                while (index < sentence.Length)
                {
                    if (sentence[index].Contains("no"))
                    {
                        break;
                    }

                    bag.InnerBags.Add(sentence[index + 1] + sentence[index + 2], int.Parse(sentence[index]));

                    index += 4;
                }

                bags.Add(bag);
            }

            return bags;
        }

        public static int ProcessPartOne(string[] rawBags)
        {
            var bags = ProcessBags(rawBags);
            var neededBags = Calculate(bags, "shinygold", new List<string>());

            return neededBags.Distinct().Count();
        }

        public static List<string> Calculate(List<Bag> bags, string bagColor, List<string> neededBags)
        {
            foreach (var bag in bags.Where(b => b.InnerBags.Keys.Contains(bagColor)))
            {
                neededBags.Add(bag.Color);
                neededBags = Calculate(bags, bag.Color, neededBags);
            }

            return neededBags;
        }

        public static int ProcessPartTwo(string[] rawBags)
        {
            var bags = ProcessBags(rawBags).ToArray();
            var shinyBag = bags.First(b => b.Color == "shinygold");

            return CalculatePartTwo(bags, shinyBag) - 1;
        }

        public static int CalculatePartTwo(Bag[] bags, Bag bag)
        {
            var total = 1;
            if (bag.InnerBags.Count > 0)
            {
                foreach (var (color, count) in bag.InnerBags)
                {
                    total += count * CalculatePartTwo(bags, bags.First(x => x.Color == color));
                }
            }

            return total;
        }
    }
}