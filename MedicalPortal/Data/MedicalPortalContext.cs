using MedicalPortal.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MedicalPortal.Data
{
    public class MedicalPortalContext : IdentityDbContext
    {
        public MedicalPortalContext(DbContextOptions<MedicalPortalContext> options)
            : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<MedicalService> MedicalServices { get; set; }
    }
}