using UnalColombia.Logistic.TAS.Domain.Entities;
using FluentValidation;

namespace UnalColombia.Logistic.TAS.Domain.Validators
{
    // IdentificationType
    public class IdentificationTypeValidator : AbstractValidator<IdentificationType>
    {
        public IdentificationTypeValidator()
        {
            RuleFor(x => x.IdentificationTypeId).GreaterThan(0);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Code1).MaximumLength(20);
            RuleFor(x => x.Code2).MaximumLength(20);
            RuleFor(x => x.Code3).MaximumLength(20);
        }
    }

}
