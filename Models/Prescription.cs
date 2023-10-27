using System.ComponentModel.DataAnnotations;

namespace MediPortal_Prescriptions.Models
{
    public class Prescription
    {
        [Key]
        public Guid PrescriptionId { get; set; }

        public Guid AppointmentId { get; set; }
        public string Diagnosis { get; set; } = string.Empty;

        public string Medication { get; set; } = string.Empty;

        public double Charges { get; set; }
    }
}
