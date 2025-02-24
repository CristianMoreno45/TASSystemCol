using UnalColombia.Logistic.TAS.Domain.Entities;
using FluentValidation;

namespace UnalColombia.Logistic.TAS.Domain.Validators
{
    // TerminalOperator
    public class TerminalOperatorValidator : AbstractValidator<TerminalOperator>
    {
        public TerminalOperatorValidator()
        {
            RuleFor(x => x.TerminalOperatorId).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
        }
    }

}
