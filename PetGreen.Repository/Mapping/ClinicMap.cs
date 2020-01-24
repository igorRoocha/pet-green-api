using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetGreen.Domain.Entities;

namespace PetGreen.Repository.Mapping
{
    public class ClinicMap : IEntityTypeConfiguration<Clinic>
    {
        public void Configure(EntityTypeBuilder<Clinic> builder)
        {
            builder.ToTable("CDClinic");

            builder.HasKey(c => c.ID);

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasColumnName("Name");

            builder.Property(c => c.TaxId)
                   .IsRequired()
                   .HasColumnName("TaxId");

            builder.Property(c => c.Email)
                   .IsRequired()
                   .HasColumnName("Email");

            builder.Property(c => c.Logo)
                   .HasColumnName("Logo");

            builder.Property(c => c.Site)
                   .HasColumnName("Site");

            builder.Property(c => c.Facebook)
                   .HasColumnName("Facebook");

            builder.HasMany(c => c.Users)
                   .WithOne(c => c.Clinic);

            builder.HasMany(c => c.MidiaSocial)
                   .WithOne(c => c.Clinic);

            builder.HasMany(c => c.Schedules)
                   .WithOne(c => c.Clinic)
                   .IsRequired();

            builder.Property(c => c.CreatedAt)
                   .IsRequired()
                   .HasColumnName("CreatedAt");

            builder.Property(c => c.UpdatedAt)
                   .HasColumnName("UpdatedAt");

            builder.Property(c => c.DeletedAt)
                   .HasColumnName("DeletedAt");
        }
    }
}