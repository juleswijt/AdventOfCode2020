using System.Linq;
using System.Text.RegularExpressions;
using FluentValidation;

namespace Day4
{
    public class PassportValidator : AbstractValidator<Passport>
    {
        public PassportValidator()
        {
            RuleFor(x => x.byr)
                .Must(x => x != null && int.Parse(x) > 1919 && int.Parse(x) < 2003);

            RuleFor(x => x.iyr)
                .Must(x => x != null && int.Parse(x) > 2009 && int.Parse(x) < 2021);

            RuleFor(x => x.eyr)
                .Must(x => x != null && int.Parse(x) > 2019 && int.Parse(x) < 2031);

            RuleFor(x => x.hgt).Must(x =>
            {
                if (x == null)
                {
                    return false;
                }

                var height = int.Parse(new string(x.Where(char.IsDigit).ToArray()));
                var unit = new string(x.Where(c => !char.IsDigit(c)).ToArray());

                return unit == "cm"
                    ? height > 149 && height < 194
                    : height > 58 && height < 77;
            });

            RuleFor(x => x.ecl).Must(x =>
            {
                return new[] {"amb", "blu", "brn", "gry", "grn", "hzl", "oth"}.Contains(x);
            });

            RuleFor(x => x.hcl).Matches(new Regex("^#[a-zA-Z0-9]{6}$"));
            RuleFor(x => x.pid).Matches(new Regex("^[0-9]{9}$"));
        }
    }
}