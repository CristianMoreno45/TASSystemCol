using UnalColombia.Logistic.TAS.Domain.Entities;
using FluentValidation;

namespace UnalColombia.Logistic.TAS.Domain.Validators
{
    // Mission
    public class MissionValidator : AbstractValidator<Mission>
    {
        public MissionValidator()
        {
            RuleFor(x => x.MissionId).NotEmpty();
            RuleFor(x => x.Points).GreaterThan(0);
            RuleFor(x => x.Description).MaximumLength(500);
        }
    }

}
