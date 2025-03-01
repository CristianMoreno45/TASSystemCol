using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnalColombia.Logistic.TAS.Shared.Requests.Appointment
{
    public class ReserveAppointmentRequest
    {
        public Guid UserId { get; set; }
        public int TerminalId { get; set; }
        public int LocationId { get; set; }
        public Guid ProviderId { get; set; }
        public Guid DriverId { get; set; }
        public Guid CalendarId { get; set; }
        public string? Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }

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
        public decimal? RequiredCelciusTemperature { get; set; }
        public string? Notes { get; set; }


    }
}
