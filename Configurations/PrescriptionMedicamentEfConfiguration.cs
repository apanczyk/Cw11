using Cw11.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cw11.Configurations
{
    public class PrescriptionMedicamentEfConfiguration : IEntityTypeConfiguration<PrescriptionMedicament>
    {
        public void Configure(EntityTypeBuilder<PrescriptionMedicament> builder)
        {
            builder.ToTable("Prescription_Medicament");
            builder.HasKey(e=> new
            {
                e.IdPrescription,
                e.IdMedicament
            }).HasName("Prescription_Medicament_PK");
                
            builder.Property(e => e.Dose);
            builder.Property(e => e.Details).HasMaxLength(30).IsRequired();
                
            builder.HasOne(e => e.Medicament)
                .WithMany(e=>e.PrescriptionsMedicaments)
                .HasForeignKey(e=>e.IdMedicament)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PrescriptionMedicament_Medicament");

            builder.HasOne(e => e.Prescription)
                .WithMany(e=>e.PrescriptionsMedicaments)
                .HasForeignKey(e=>e.IdPrescription)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PrescriptionMedicament_Prescription");
        }
    }
}