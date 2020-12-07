using System.Collections.Generic;
using System.Linq;

namespace Day7
{
    public class Bag
    {
        public string Color { get; set; }
        public Dictionary<string, int> InnerBags { get; } = new Dictionary<string, int>();
    }
}