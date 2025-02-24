using UnalColombia.Logistic.TAS.Domain.Entities;
using FluentValidation;

namespace UnalColombia.Logistic.TAS.Domain.Validators
{
    // SuperPower
    public class SuperPowerValidator : AbstractValidator<SuperPower>
    {
        public SuperPowerValidator()
        {
            RuleFor(x => x.SuperPowerId).NotEmpty();
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.MultiplierFactor).GreaterThan(0);
        }
    }

}
