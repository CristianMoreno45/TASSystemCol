using System.Globalization;
using UnalColombia.Common.Infrastructure;
using UnalColombia.Logistic.TAS.Domain.Repositories;
using UnalColombia.Logistic.TAS.Infrastructure.Persistence;

namespace UnalColombia.Logistic.TAS.Infrastructure.Repositories
{
    public class CalendarRepository : BaseRepository<Domain.Entities.Calendar, TASDbContext>, ICalendarRepository
    {
        public CalendarRepository(TASDbContext context) : base(context)
        {
        }
    }
}
