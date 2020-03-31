using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetGreen.Domain.Entities.Register;

namespace PetGreen.Repository.Mapping.Register
{
    public class CatererMap : IEntityTypeConfiguration<Caterer>
    {
        public void Configure(EntityTypeBuilder<Caterer> builder)
        {
            builder.ToTable("CDCaterer");

            builder.HasKey(c => c.ID);

            builder.Property(c => c.Name)
                  .IsRequired()
                  .HasColumnName("Name");

            builder.Property(c => c.TaxId)
                   .IsRequired()
                   .HasColumnName("TaxId");

            builder.Property(c => c.SocialReason)
                   .IsRequired()
                   .HasColumnName("SocialReason");

            builder.Property(c => c.StateRegistration)
                   .HasColumnName("StateRegistration");

            builder.Property(c => c.Logo)
                   .HasColumnName("Logo");

            builder.Property(c => c.Email)
                   .IsRequired()
                   .HasColumnName("Email");

            builder.HasOne(c => c.Clinic)
                   .WithMany(c => c.Caterers)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict)
                   .HasForeignKey(c => c.ClinicID);

            builder.HasMany(c => c.Contacts)
                   .WithOne(c => c.Caterer)
                   .HasForeignKey(c => c.CatererID)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.Address)
                   .WithOne(c => c.Caterer)
                   .HasForeignKey(c => c.CatererID)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(c => c.CreatedAt)
                   .IsRequired()
                   .HasColumnName("CreatedAt");

            builder.Property(c => c.UpdatedAt)
                   .HasColumnName("UpdatedAt");
        }
    }
}
