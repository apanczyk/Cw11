using Cw11.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cw11.Configurations
{
    public class PrescriptionEfConfiguration : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.HasKey(e=>e.IdPrescription).HasName("Prescription_PK");
                
            builder.Property(e => e.Date).IsRequired();
            builder.Property(e => e.DueDate).IsRequired();
                
            builder.HasOne(e => e.Patient)
                .WithMany(e=>e.Prescriptions)
                .HasForeignKey(e=>e.IdPatient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Prescription_Patient");

            builder.HasOne(e => e.Doctor)
                .WithMany(e=>e.Prescriptions)
                .HasForeignKey(e=>e.IdDoctor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Prescription_Doctor");
        }
    }
}