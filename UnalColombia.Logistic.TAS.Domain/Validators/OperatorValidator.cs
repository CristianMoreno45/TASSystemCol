using UnalColombia.Logistic.TAS.Domain.Entities;
using FluentValidation;

namespace UnalColombia.Logistic.TAS.Domain.Validators
{
    // Operator
    public class OperatorValidator : AbstractValidator<Operator>
    {
        public OperatorValidator()
        {
            RuleFor(x => x.OperatorId).NotEmpty();
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        }
    }

}
