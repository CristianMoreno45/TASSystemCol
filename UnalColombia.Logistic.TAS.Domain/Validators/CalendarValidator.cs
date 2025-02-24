using UnalColombia.Logistic.TAS.Domain.Entities;
using FluentValidation;

namespace UnalColombia.Logistic.TAS.Domain.Validators
{
    // Calendar
    public class CalendarValidator : AbstractValidator<Calendar>
    {
        public CalendarValidator()
        {
            RuleFor(x => x.CalendarId).NotEmpty();
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Description).MaximumLength(500);
        }
    }

}
