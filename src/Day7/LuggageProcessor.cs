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
                var bagColor = sentence[0] + sentence[1];

                var bag = bags.FirstOrDefault(x => x.Color == bagColor);
                if (bag == null)
                {
                    bag = new Bag {Color = bagColor};
                    bags.Add(bag);
                }

                var index = 4;
                while (index < sentence.Length)
                {
                    if (sentence[index].Contains("no"))
                    {
                        break;
                    }

                    var innerBagColor = sentence[index + 1] + sentence[index + 2];
                    var innerBag = bags.FirstOrDefault(x => x.Color == innerBagColor);
                    if (innerBag == null)
                    {
                        innerBag = new Bag {Color = innerBagColor};
                        bags.Add(innerBag);
                    }

                    bag.InnerBags.Add(innerBag, int.Parse(sentence[index]));

                    index += 4;
                }
            }

            return bags;
        }
    }
}