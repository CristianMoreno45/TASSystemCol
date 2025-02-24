using UnalColombia.Common.Interfaces;

namespace UnalColombia.Logistic.TAS.Domain.Entities
{
    public class Category : IActivatable
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int RankingNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
