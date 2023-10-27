using System.ComponentModel.DataAnnotations;

namespace MediPortal_Prescriptions.Models.Dtos
{
    public class PrescriptionRequestDto
    {
        [Required]
        public Guid AppointmentId { get; set; }
        [Required]
        public string Diagnosis { get; set; } = string.Empty;

        [Required]
        public string Medication { get; set; } = string.Empty;

        public double? Charges { get; set; }
    }
}
