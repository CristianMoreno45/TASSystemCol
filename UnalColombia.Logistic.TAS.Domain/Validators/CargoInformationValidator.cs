using UnalColombia.Logistic.TAS.Domain.Entities;
using FluentValidation;

namespace UnalColombia.Logistic.TAS.Domain.Validators
{
    // CargoInformation
    public class CargoInformationValidator : AbstractValidator<CargoInformation>
    {
        public CargoInformationValidator()
        {
            RuleFor(x => x.CargoInformationId).NotEmpty();
            RuleFor(x => x.ContainerId).NotEmpty().MaximumLength(50);
            RuleFor(x => x.LengthInFeet).GreaterThan(0);
            RuleFor(x => x.HeightInFeet).GreaterThan(0);
            RuleFor(x => x.WidthInFeet).GreaterThan(0);
            RuleFor(x => x.GrossWeightInKilos).GreaterThan(0);
            RuleFor(x => x.NetWeightInKilos).GreaterThan(0);
        }
    }

}
