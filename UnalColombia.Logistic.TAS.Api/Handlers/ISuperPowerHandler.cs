using UnalColombia.Logistic.TAS.Domain.Entities;

namespace UnalColombia.Logistic.TAS.Api.Handlers
{
    public interface ISuperPowerHandler
    {
        Task<SuperPower> GetSuperPowerById(Guid superPowerId);
    }
}