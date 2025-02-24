using UnalColombia.Common.Interfaces;

namespace UnalColombia.Logistic.TAS.Domain.Entities
{
    public class CargoInformation : IActivatable
    {
        public Guid CargoInformationId { get; set; }
        public Guid AppointmentId { get; set; }
        public string ContainerId { get; set; }
        public decimal LengthInFeet { get; set; }
        public decimal HeightInFeet { get; set; }
        public decimal WidthInFeet { get; set; }
        public decimal GrossWeightInKilos { get; set; }
        public decimal NetWeightInKilos { get; set; }
        public int TypeContainerId { get; set; }
        public int GeographicalLocationOriginISOCountryId { get; set; }
        public int GeographicalLocationDestinationISOCountryId { get; set; }
        public bool IsLoaded { get; set; }
        public string TypeCargo { get; set; }
        public string TractorTrailerRegistrationNumber { get; set; }
        public bool IsOversizedLoad { get; set; }
        public string IMOCode { get; set; }
        public decimal RequiredCelciusTemperature { get; set; }
        public string? Notes { get; set; }
        public bool IsActive { get; set; }

        public virtual TypeContainer TypeContainer { get; set; }
        public virtual ISOCountry GeographicalLocationOrigin { get; set; }
        public virtual ISOCountry GeographicalLocationDestination { get; set; }
        public virtual Appointment Appointment { get; set; }

    }
}