using UnalColombia.Common.Infrastructure;

namespace UnalColombia.Logistic.TAS.Domain.Repositories
{
    public interface IProviderRepository : IRepositoryAsync<Entities.Provider>
    {
        IEnumerable<Entities.Provider> GetProvidersWithUserInformation();
    }
}
