using UnalColombia.Logistic.TAS.Domain.Entities;
using FluentValidation;

namespace UnalColombia.Logistic.TAS.Domain.Validators
{
    // TypeContainer
    public class TypeContainerValidator : AbstractValidator<TypeContainer>
    {
        public TypeContainerValidator()
        {
            RuleFor(x => x.TypeContainerId).NotEmpty();
            RuleFor(x => x.Code).NotEmpty().MaximumLength(20);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(200);
        }
    }

}
