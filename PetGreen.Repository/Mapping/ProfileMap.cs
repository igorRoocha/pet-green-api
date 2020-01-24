using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetGreen.Domain.Entities;

namespace PetGreen.Repository.Mapping
{
    public class ProfileMap : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.ToTable("CDProfile");

            builder.HasKey(c => c.ID);

            builder.Property(c => c.Description)
                .IsRequired()
                .HasColumnName("Description");

            builder.HasMany(c => c.Users)
                    .WithOne(c => c.Profile);
        }
    }
}