using System.Linq.Expressions;
using UnalColombia.Common.Infrastructure;

namespace UnalColombia.Logistic.TAS.Domain.Repositories
{
    public interface IAppointmentRepository : IRepositoryAsync<Entities.Appointment>
    {
        Domain.Entities.Appointment? GetAllInformationById(Guid id);
        List<Domain.Entities.Appointment>? GetAppointmentListDynamicFilter(Expression<Func<Domain.Entities.Appointment, bool>> filter);
    }
}
