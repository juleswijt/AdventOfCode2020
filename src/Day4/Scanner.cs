using System.Collections.Generic;
using System.Linq;

namespace Day4
{
    public class Scanner
    {
        public Passport[] Scan(string[] input)
        {
            var currentIndex = 0;
            var rawPassportInfos = new List<string>();
            foreach (var line in input)
            {
                if (string.IsNullOrEmpty(line))
                {
                    currentIndex++;
                    continue;
                }

                if (null == rawPassportInfos.ElementAtOrDefault(currentIndex))
                {
                    rawPassportInfos.Insert(currentIndex, "");
                }

                rawPassportInfos[currentIndex] += " " + line;
            }

            var passports = new List<Passport>();
            foreach (var rawPassport in rawPassportInfos)
            {
                var passport = new Passport();
                foreach (var field in rawPassport.Trim().Split(" "))
                {
                    var splitField = field.Split(":");
                    typeof(Passport)
                        .GetProperty(splitField[0])
                        ?.SetValue(passport, splitField[1]);
                }

                passports.Add(passport);
            }

            return passports.ToArray();
        }
    }
}