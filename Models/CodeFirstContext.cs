using Cw11.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Cw11.Models
{
    public class CodeFirstContext : DbContext
    {
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Prescription> Prescription { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Medicament> Medicament { get; set; }
        public DbSet<PrescriptionMedicament> PrescriptionMedicament { get; set; }
        public CodeFirstContext(DbContextOptions<CodeFirstContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfiguration(new PatientEfConfiguration());
            
            modelBuilder.ApplyConfiguration(new DoctorEfConfiguration());
            
            modelBuilder.ApplyConfiguration(new PrescriptionEfConfiguration());

            modelBuilder.ApplyConfiguration(new MedicamentEfConfiguration());

            modelBuilder.ApplyConfiguration(new PrescriptionMedicamentEfConfiguration());

            // metoda Seed znajduje się w klasie SeedEfConfiguration 
            modelBuilder.Seed();
        }
    }
}