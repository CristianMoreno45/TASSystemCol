using UnalColombia.Logistic.TAS.Domain.Entities;
using FluentValidation;

namespace UnalColombia.Logistic.TAS.Domain.Validators
{
    // HistoryPoint
    public class HistoryPointValidator : AbstractValidator<HistoryPoint>
    {
        public HistoryPointValidator()
        {
            RuleFor(x => x.PointHistoryId).NotEmpty();
            RuleFor(x => x.Description).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Points).GreaterThan(0);
        }
    }

}
