using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day14
{
    public abstract class Step
    {
        public static Step Parse(string raw)
        {
            var split = raw.Split("=").Select(x => x.Trim()).ToArray();
            if (split[0].Trim() == "mask")
            {
                return new Mask(split[1]);
            }

            var pattern = new Regex(@"^mem\[(.+?)\]$");
            var position = int.Parse(pattern.Replace(split[0], "$1"));

            var binary = split[1].ParseToBinary();

            return new Memory(binary, position);
        }
    }
}