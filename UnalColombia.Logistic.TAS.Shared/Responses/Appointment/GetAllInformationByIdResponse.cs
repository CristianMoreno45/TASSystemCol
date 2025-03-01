namespace UnalColombia.Logistic.TAS.Shared.Responses.Appointment
{
    public class GetAllInformationByIdResponse
    {
        public Guid AppointmentId { get; set; }
        public string AppointmentState { get; set; }
        public string Terminal { get; set; }
        public string Location { get; set; }
        public string DriverName { get; set; }
        public string DriverPhone { get; set; }
        public string UserEmail { get; set; }
        public string ProviderName { get; set; }
        public string ProviderPhone { get; set; }
        public string CalendaName { get; set; }
        public string? Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public DateTime createdDate { get; set; }
        public Guid createdUserId { get; set; }
        public Guid cargoInformationId { get; set; }
        public string ContainerId { get; set; }
        public decimal LengthInFeet { get; set; }
        public decimal HeightInFeet { get; set; }
        public decimal WidthInFeet { get; set; }
        public decimal GrossWeightInKilos { get; set; }
        public decimal NetWeightInKilos { get; set; }
        public string TypeContainer { get; set; }
        public string GeographicalLocationOriginISOCountry { get; set; }
        public string GeographicalLocationDestinationISOCountry { get; set; }
        public bool IsLoaded { get; set; }
        public string TractorTrailerRegistrationNumber { get; set; }
        public bool IsOversizedLoad { get; set; }
        public string IMOCode { get; set; }
        public decimal RequiredCelciusTemperature { get; set; }
        public string? Notes { get; set; }
        public bool IsActive { get; set; }
    }
}
