using UnalColombia.Logistic.TAS.Domain.Entities;
using FluentValidation;

namespace UnalColombia.Logistic.TAS.Domain.Validators
{
    // Wallet
    public class WalletValidator : AbstractValidator<Wallet>
    {
        public WalletValidator()
        {
            RuleFor(x => x.WalletId).NotEmpty();
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        }
    }

}
