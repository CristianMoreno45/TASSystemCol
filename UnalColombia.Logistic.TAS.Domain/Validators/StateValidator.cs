using UnalColombia.Logistic.TAS.Domain.Entities;
using FluentValidation;

namespace UnalColombia.Logistic.TAS.Domain.Validators
{
    // State
    public class StateValidator : AbstractValidator<State>
    {
        public StateValidator()
        {
            RuleFor(x => x.StateId).NotEmpty();
        }
    }

}
