using UnalColombia.Logistic.TAS.Domain.Entities;
using FluentValidation;

namespace UnalColombia.Logistic.TAS.Domain.Validators
{
    // Provider
    public class ProviderValidator : AbstractValidator<Provider>
    {
        public ProviderValidator()
        {
            RuleFor(x => x.ProviderId).NotEmpty();
            RuleFor(x => x.FiscalNumber).NotEmpty().MaximumLength(50);
            RuleFor(x => x.ContactPhone).NotEmpty().MaximumLength(20);
        }
    }

}
