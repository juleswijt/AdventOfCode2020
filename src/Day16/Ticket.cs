using System.Linq;

namespace Day16
{
    public struct Ticket
    {
        public int[] Values { get; }

        public Ticket(int[] values)
        {
            Values = values;
        }

        public static Ticket Parse(string raw)
        {
            return new Ticket(raw.Split(",").Select(int.Parse).ToArray());
        }
    }
}