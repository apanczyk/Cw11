using Cw11.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Cw11.Configurations
{
    public class DoctorEfConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(e => e.IdDoctor).HasName("Doctor_PK");

            builder.Property(e => e.FirstName).HasMaxLength(30).IsRequired();
            builder.Property(e => e.LastName).HasMaxLength(30).IsRequired();
            builder.Property(e => e.Email).IsRequired();
        }
    }
}