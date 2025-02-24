using UnalColombia.Logistic.TAS.Domain.Entities;
using FluentValidation;

namespace UnalColombia.Logistic.TAS.Domain.Validators
{
    // Driver
    public class DriverValidator : AbstractValidator<Driver>
    {
        public DriverValidator()
        {
            RuleFor(x => x.DriverId).NotEmpty();
            RuleFor(x => x.LicenceNumber).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Phone).NotEmpty().MaximumLength(20);
        }
    }

}
