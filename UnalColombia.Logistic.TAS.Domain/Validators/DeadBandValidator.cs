using UnalColombia.Logistic.TAS.Domain.Entities;
using FluentValidation;

namespace UnalColombia.Logistic.TAS.Domain.Validators
{
    // DeadBand
    public class DeadBandValidator : AbstractValidator<DeadBand>
    {
        public DeadBandValidator()
        {
            RuleFor(x => x.DeadBandId).GreaterThan(0);
            RuleFor(x => x.CalendarId).NotEmpty();
            RuleFor(x => x.Reason).NotEmpty().MaximumLength(200);
            RuleFor(x => x.StartTime)
                .LessThan(x => x.FinishTime)
                .WithMessage("La hora de inicio debe ser menor a la hora de finalización");
            RuleFor(x => x.RecurrentPattern).MaximumLength(100);
        }
    }

}
