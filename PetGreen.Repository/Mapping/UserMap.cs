using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetGreen.Domain.Entities;

namespace PetGreen.Repository.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("CDUser");

            builder.HasKey(c => c.ID);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnName("Name");

            builder.Property(c => c.Email)
                .IsRequired()
                .HasColumnName("Email");

            builder.Property(c => c.PasswordHash)
                .IsRequired()
                .HasColumnName("PasswordHash");

            builder.Property(c => c.PasswordSalt)
                .IsRequired()
                .HasColumnName("PasswordSalt");
            
            builder.HasOne(x => x.Clinic)
                    .WithMany(x => x.Users);

            builder.HasOne(x => x.Profile)
                   .WithMany(x => x.Users)
                   .IsRequired();

            builder.Property(c => c.CreatedAt)
                .IsRequired()
                .HasColumnName("CreatedAt");

            builder.Property(c => c.UpdatedAt)
                .HasColumnName("UpdateAt");

            builder.Property(c => c.DeletedAt)
                .HasColumnName("DeletedAt");
        }
    }
}