using UnalColombia.Common.Infrastructure;
using UnalColombia.Logistic.TAS.Domain.Repositories;
using UnalColombia.Logistic.TAS.Infrastructure.Persistence;

namespace UnalColombia.Logistic.TAS.Infrastructure.Repositories
{
    public class AppointmentStateRepository : BaseRepository<Domain.Entities.AppointmentState, TASDbContext>, IAppointmentStateRepository
    {
        public AppointmentStateRepository(TASDbContext context) : base(context)
        {
        }
    }
}
