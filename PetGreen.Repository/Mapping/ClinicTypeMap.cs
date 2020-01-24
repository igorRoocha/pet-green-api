using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetGreen.Domain.Entities;

namespace PetGreen.Repository.Mapping
{
    public class ClinicTypeMap : IEntityTypeConfiguration<ClinicType>
    {
        public void Configure(EntityTypeBuilder<ClinicType> builder)
        {
            builder.ToTable("CDClinicType");

            builder.HasKey(c => c.ID);

            builder.Property(c => c.Description)
                   .IsRequired()
                   .HasColumnName("Description");
                
            builder.HasMany(c => c.Clinics)
                   .WithOne(c => c.ClinicType);

        }
    }
}