using UnalColombia.Logistic.TAS.Domain.Entities;
using FluentValidation;

namespace UnalColombia.Logistic.TAS.Domain.Validators
{
    // SuperPowerUser
    public class SuperPowerUserValidator : AbstractValidator<SuperPowerUser>
    {
        public SuperPowerUserValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.SuperPowerId).NotEmpty();
            RuleFor(x => x.EndDate)
                .NotEmpty()
                .GreaterThan(x => x.CreatedDate)
                .WithMessage("La fecha de finalización debe ser mayor a la fecha de creación");
        }
    }

}
