using UnalColombia.Logistic.TAS.Domain.Entities;
using FluentValidation;

namespace UnalColombia.Logistic.TAS.Domain.Validators
{
    // MissionAppointmet
    public class MissionAppointmetValidator : AbstractValidator<MissionAppointmet>
    {
        public MissionAppointmetValidator()
        {
            RuleFor(x => x.MissionId).NotEmpty();
            RuleFor(x => x.AppointmentId).NotEmpty();
        }
    }

}
