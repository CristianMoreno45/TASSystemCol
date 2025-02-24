using UnalColombia.Logistic.TAS.Domain.Entities;
using FluentValidation;

namespace UnalColombia.Logistic.TAS.Domain.Validators
{
    // DayOfWeekSettings
    public class DayOfWeekSettingsValidator : AbstractValidator<DayOfWeekSettings>
    {
        public DayOfWeekSettingsValidator()
        {
            RuleFor(x => x.SettingDayOfWeekId).GreaterThan(0);
            RuleFor(x => x.CalendarId).NotEmpty();
            RuleFor(x => x.DayOfWeek)
                .InclusiveBetween(0, 6)
                .WithMessage("El día de la semana debe estar entre 0 (domingo) y 6 (sábado)");
            RuleFor(x => x.StartTime)
                .LessThan(x => x.FinishTime)
                .WithMessage("La hora de inicio debe ser menor a la hora de finalización");
        }
    }

}
