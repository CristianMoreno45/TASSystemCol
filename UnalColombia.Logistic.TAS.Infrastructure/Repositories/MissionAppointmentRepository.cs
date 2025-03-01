using Microsoft.EntityFrameworkCore;
using UnalColombia.Common.Infrastructure;
using UnalColombia.Logistic.TAS.Domain.Entities;
using UnalColombia.Logistic.TAS.Domain.Repositories;
using UnalColombia.Logistic.TAS.Infrastructure.Persistence;

namespace UnalColombia.Logistic.TAS.Infrastructure.Repositories
{
    public class MissionAppointmentRepository : BaseRepository<Domain.Entities.MissionAppointmet, TASDbContext>, IMissionAppointmentRepository
    {
        public MissionAppointmentRepository(TASDbContext context) : base(context)
        {
        }
        public IEnumerable<MissionAppointmet> GetMissionAppointmetByIdWalletInfo(Guid appointmentId)
        {
            return _model
                .Where(x => x.AppointmentId == appointmentId)
                .Include(x=> x.Mission)
                .Include(x=> x.Appointment)
                .ThenInclude(x => x.Driver)
                .ThenInclude(x => x.User)
                .ThenInclude(x=> x.WalledByUsers)
                ;
        }
    }
}
