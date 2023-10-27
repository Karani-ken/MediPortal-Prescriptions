using MediPortal_Prescriptions.Models;
using Microsoft.EntityFrameworkCore;

namespace MediPortal_Prescriptions.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) { }

        public DbSet<Prescription> Prescriptions { get; set; }

    }
}
