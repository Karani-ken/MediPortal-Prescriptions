using MediPortal_Prescriptions.Models;

namespace MediPortal_Prescriptions.Services.IServices
{
    public interface IPrescriptionInterface
    {
        Task<string> AddPrescription(Prescription prescription);

        Task<string> EditPrescription(Prescription prescription);
        Task<string> DeletePrescription(Prescription prescription);

        Task<List<Prescription>> GetPrescriptions();


    }
}
