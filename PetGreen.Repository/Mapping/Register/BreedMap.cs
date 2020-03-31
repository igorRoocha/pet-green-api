using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetGreen.Domain.Entities.Register;

namespace PetGreen.Repository.Mapping.Register
{
    public class BreedMap : IEntityTypeConfiguration<Breed>
    {
        public void Configure(EntityTypeBuilder<Breed> builder)
        {
            builder.ToTable("CDBreed");

            builder.HasKey(b => b.ID);

            builder.Property(b => b.Name)
                  .IsRequired()
                  .HasColumnName("Name");

            builder.Property(b => b.CreatedAt)
                   .IsRequired()
                   .HasColumnName("CreatedAt");

            builder.Property(b => b.UpdatedAt)
                   .HasColumnName("UpdatedAt");

            builder.HasOne(b => b.Specie)
                   .WithMany(b => b.Breeds)
                   .HasForeignKey(b => b.SpecieID)
                   .OnDelete(DeleteBehavior.Restrict)
                   .IsRequired();
        }
    }
}
