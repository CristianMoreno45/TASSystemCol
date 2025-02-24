using UnalColombia.Logistic.TAS.Domain.Entities;
using FluentValidation;

namespace UnalColombia.Logistic.TAS.Domain.Validators
{
    // HistoryAppointment
    public class HistoryAppointmentValidator : AbstractValidator<HistoryAppointment>
    {
        public HistoryAppointmentValidator()
        {
            RuleFor(x => x.HistoryAppointmentId).NotEmpty();
            RuleFor(x => x.AppointmentId).NotEmpty();
            RuleFor(x => x.Title).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Description).MaximumLength(500);
            RuleFor(x => x.StartTime)
                .LessThan(x => x.FinishTime)
                .WithMessage("La hora de inicio debe ser menor a la hora de finalización");
        }
    }

}
