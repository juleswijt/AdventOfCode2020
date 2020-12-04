using System;
using System.Collections.Generic;
using System.Linq;

namespace Day4
{
    public class Scanner
    {
        public Passport[] Scan(string[] input)
        {
            var rawPassports = string
                .Join("\n", input)
                .Split("\n\n");

            var passports = new List<Passport>();
            foreach (var rawPassport in rawPassports)
            {
                var passport = new Passport();
                foreach (var field in rawPassport.Split(new[] {" ", "\n"}, StringSplitOptions.None))
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