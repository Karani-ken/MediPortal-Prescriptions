namespace MediPortal_Prescriptions.Models.Dtos
{
    public class PrescriptionDto
    {
         public Guid PrescriptionId { get; set; }

        public Guid AppointmentId { get; set; }
        public string Diagnosis { get; set; } = string.Empty;

        public string Medication { get; set; } = string.Empty;

        public double Charges { get; set; }
    }
}
