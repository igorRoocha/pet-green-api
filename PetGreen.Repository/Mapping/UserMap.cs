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

            builder.HasKey(u => u.ID);

            builder.Property(u => u.Name)
                .IsRequired()
                .HasColumnName("Name");

            builder.Property(u => u.Email)
                .IsRequired()
                .HasColumnName("Email");

            builder.Property(u => u.PasswordHash)
                .IsRequired()
                .HasColumnName("PasswordHash");

            builder.Property(u => u.PasswordSalt)
                .IsRequired()
                .HasColumnName("PasswordSalt");

            builder.HasOne(u => u.Clinic)
                   .WithMany(u => u.Users)
                   .HasForeignKey(u => u.ClinicID);

            builder.HasMany(u => u.Contacts)
                    .WithOne(u => u.User)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(u => u.Profile)
                   .WithMany(u => u.Users)
                   .HasForeignKey(u => u.ProfileID)
                   .IsRequired();

            builder.Property(u => u.CreatedAt)
                .IsRequired()
                .HasColumnName("CreatedAt");

            builder.Property(u => u.UpdatedAt)
                .HasColumnName("UpdateAt");

            builder.Property(u => u.DeletedAt)
                .HasColumnName("DeletedAt");
        }
    }
}