using UnalColombia.Common.Interfaces;

namespace UnalColombia.Logistic.TAS.Domain.Entities
{
    public class ISOCountry: IActivatable
    {
        public int ISOCountryId { get; set; }
        public string Name { get; set; }
        public string A2 { get; set; }
        public string A3 { get; set; }
        public string Code { get; set; }
        public bool IsActive { get; set; } = true;

        public virtual ICollection<CargoInformation>? OriginCargoInformationList { get; set; }
        public virtual ICollection<CargoInformation>? DestinationCargoInformationList { get; set; }
    }
}