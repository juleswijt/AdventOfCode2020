using FluentValidation;

namespace Day4
{
    public class PassportSimpleValidator : AbstractValidator<Passport>
    {
        public PassportSimpleValidator()
        {
            RuleFor(x => x.byr).NotNull();
            RuleFor(x => x.iyr).NotNull();
            RuleFor(x => x.eyr).NotNull();
            RuleFor(x => x.hgt).NotNull();
            RuleFor(x => x.hcl).NotNull();
            RuleFor(x => x.ecl).NotNull();
            RuleFor(x => x.pid).NotNull();
        }
    }
}