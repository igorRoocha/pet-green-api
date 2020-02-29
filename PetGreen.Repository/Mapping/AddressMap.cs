using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetGreen.Domain.Entities;

namespace PetGreen.Repository.Mapping
{
    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("CDAddress");

            builder.HasKey(a => a.ID);

            builder.Property(a => a.Cep)
                  .IsRequired()
                  .HasColumnName("Cep");

            builder.Property(a => a.Number)
                   .IsRequired()
                   .HasColumnName("Number");

            builder.Property(a => a.Street)
                   .IsRequired()
                   .HasColumnName("Street");

            builder.Property(a => a.Neighborhood)
                   .IsRequired()
                   .HasColumnName("Neighborhood");

            builder.Property(a => a.Complement)
                   .HasColumnName("Complement");

            builder.Property(a => a.CreatedAt)
                   .IsRequired()
                   .HasColumnName("CreatedAt");

            builder.Property(a => a.UpdatedAt)
                   .HasColumnName("UpdatedAt");

            builder.HasOne(a => a.City)
                   .WithMany(c => c.Addresses)
                   .IsRequired();

            builder.HasOne(c => c.Clinic)
                   .WithOne(a => a.Address)
                   .HasForeignKey<Clinic>(c => c.AddressID)
                   .IsRequired();
        }
    }
}
