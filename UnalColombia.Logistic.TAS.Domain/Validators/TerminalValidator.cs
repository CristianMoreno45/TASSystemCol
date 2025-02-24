using UnalColombia.Logistic.TAS.Domain.Entities;
using FluentValidation;

namespace UnalColombia.Logistic.TAS.Domain.Validators
{
    // Terminal
    public class TerminalValidator : AbstractValidator<Terminal>
    {
        public TerminalValidator()
        {
            RuleFor(x => x.TerminalId).NotEmpty();
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        }
    }

}
