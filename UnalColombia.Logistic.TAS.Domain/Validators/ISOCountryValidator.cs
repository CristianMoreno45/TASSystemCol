using UnalColombia.Logistic.TAS.Domain.Entities;
using FluentValidation;

namespace UnalColombia.Logistic.TAS.Domain.Validators
{
    // ISOCountry
    public class ISOCountryValidator : AbstractValidator<ISOCountry>
    {
        public ISOCountryValidator()
        {
            RuleFor(x => x.ISOCountryId).GreaterThan(0);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.A2).NotEmpty().MaximumLength(2);
            RuleFor(x => x.A3).NotEmpty().MaximumLength(3);
            RuleFor(x => x.Code).NotEmpty().MaximumLength(10);
        }
    }

}
