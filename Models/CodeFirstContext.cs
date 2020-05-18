using Microsoft.EntityFrameworkCore;

namespace Cw11.Models
{
    public class CodeFirstContext : DbContext
    {
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Prescription> Prescription { get; set; }
        public CodeFirstContext(DbContextOptions<CodeFirstContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.IdPatient).HasName("Patient_PK");
                
                entity.Property(e => e.FirstName).HasMaxLength(30).IsRequired();
                entity.Property(e => e.LastName).HasMaxLength(30).IsRequired();
                entity.Property(e => e.Birthdate).IsRequired();
            });
            
            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.IdDoctor).HasName("Doctor_PK");
                
                entity.Property(e => e.FirstName).HasMaxLength(30).IsRequired();
                entity.Property(e => e.LastName).HasMaxLength(30).IsRequired();
                entity.Property(e => e.Email).IsRequired();
            });

            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.HasKey(e=>e.IdPrescription).HasName("Prescription_PK");
                
                entity.Property(e => e.Date).IsRequired();
                entity.Property(e => e.DueDate).IsRequired();
                
                entity.HasOne(e => e.Patient)
                    .WithMany(e=>e.Prescriptions)
                    .HasForeignKey(e=>e.IdPatient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Prescription_Patient");

                entity.HasOne(e => e.Doctor)
                    .WithMany(e=>e.Prescriptions)
                    .HasForeignKey(e=>e.IdDoctor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Prescription_Doctor");
            });
            
            
            modelBuilder.Entity<Medicament>(entity =>
            {
                entity.HasKey(e => e.IdMedicament).HasName("Medicament_PK");
                
                entity.Property(e => e.Name).HasMaxLength(30).IsRequired();
                entity.Property(e => e.Type).HasMaxLength(30).IsRequired();
                entity.Property(e => e.Description).HasMaxLength(30).IsRequired();
            });
            
            modelBuilder.Entity<PrescriptionMedicament>(entity =>
            {
                entity.ToTable("Prescription_Medicament");
                entity.HasKey(e=> new
                {
                    e.IdPrescription,
                    e.IdMedicament
                }).HasName("Prescription_Medicament_PK");
                
                entity.Property(e => e.Dose);
                entity.Property(e => e.Details).HasMaxLength(30).IsRequired();
                
                entity.HasOne(e => e.Medicament)
                    .WithMany(e=>e.PrescriptionsMedicaments)
                    .HasForeignKey(e=>e.IdMedicament)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PrescriptionMedicament_Medicament");

                entity.HasOne(e => e.Prescription)
                    .WithMany(e=>e.PrescriptionsMedicaments)
                    .HasForeignKey(e=>e.IdPrescription)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PrescriptionMedicament_Prescription");
            });

        }
    }
}