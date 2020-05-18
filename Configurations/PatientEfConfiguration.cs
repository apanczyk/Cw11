using Cw11.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Cw11.Configurations
{
    public class PatientEfConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(e => e.IdPatient).HasName("Patient_PK");

            builder.Property(e => e.FirstName).HasMaxLength(30).IsRequired();
            builder.Property(e => e.LastName).HasMaxLength(30).IsRequired();
            builder.Property(e => e.Birthdate).IsRequired();
        }
    }
}