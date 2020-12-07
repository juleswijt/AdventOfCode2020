using System.Collections.Generic;
using System.Linq;

namespace Day7
{
    public class Bag
    {
        public string Color { get; set; }
        public Dictionary<Bag, int> InnerBags { get; set; } = new Dictionary<Bag, int>();

        public bool ContainsBag(string color)
        {
            return Color == color || InnerBags.Any(inner => inner.Key.ContainsBag(color));
        }

        public int CountBags()
        {
            return InnerBags.Sum(c => c.Value) +
                   InnerBags.Sum(c => c.Key.CountBags() * c.Value);
        }
    }
}