using UnalColombia.Logistic.TAS.Domain.Entities;
using FluentValidation;

namespace UnalColombia.Logistic.TAS.Domain.Validators
{
    // WalletUser
    public class WalletUserValidator : AbstractValidator<WalletUser>
    {
        public WalletUserValidator()
        {
            RuleFor(x => x.WalletId).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.Balance).GreaterThanOrEqualTo(0)
                .WithMessage("El saldo no puede ser negativo");
        }
    }

}
