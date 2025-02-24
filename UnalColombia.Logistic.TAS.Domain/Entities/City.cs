using UnalColombia.Common.Interfaces;

namespace UnalColombia.Logistic.TAS.Domain.Entities
{
    public class City : IActivatable
    {
        public int CityId { get; set; }
        public int StateId { get; set; }
        public string Name { get; set; }
        public string? Code1 { get; set; }
        public string? Code2 { get; set; }
        public string? Code3 { get; set; }
        public bool IsActive { get; set; }

        public virtual State State { get; set; }
        public virtual ICollection<Terminal> Terminals { get; set; }
    }
}
