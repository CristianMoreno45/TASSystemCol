namespace UnalColombia.Logistic.TAS.Domain.Entities
{
    public class MissionAppointmet 
    {
        public int MissionId { get; set; }
        public Guid AppointmentId { get; set; }

        public virtual Mission Mission { get; set; }    
        public virtual Appointment Appointment { get; set; }
    }
}