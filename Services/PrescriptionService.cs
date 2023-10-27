using MediPortal_Prescriptions.Data;
using MediPortal_Prescriptions.Models;
using MediPortal_Prescriptions.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace MediPortal_Prescriptions.Services
{
    public class PrescriptionService : IPrescriptionInterface
    {
        private readonly ApplicationDbContext _context;

        public PrescriptionService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<string> AddPrescription(Prescription prescription)
        {
            await _context.Prescriptions.AddAsync(prescription);
            await _context.SaveChangesAsync();
            return "Prescription was Added";
        }

        public async Task<string> DeletePrescription(Prescription prescription)
        {
            _context.Prescriptions.Remove(prescription);

            await _context.SaveChangesAsync();
            return "prescription was Deleted";
        }

        public async Task<string> EditPrescription(Prescription prescription)
        {
            _context.Prescriptions.Update(prescription);
            await _context.SaveChangesAsync();
            return "prescription was updated";
        }

        public async Task<List<Prescription>> GetPrescriptions()
        {
           return await _context.Prescriptions.ToListAsync();
        }
    }
}
