using UnalColombia.Common.Infrastructure;
using UnalColombia.Logistic.TAS.Domain.Entities;

namespace UnalColombia.Logistic.TAS.Domain.Repositories
{
    public interface IMissionAppointmentRepository : IRepositoryAsync<Entities.MissionAppointmet>
    {
        IEnumerable<MissionAppointmet> GetMissionAppointmetByIdWalletInfo(Guid appointmentId);
    }
}
