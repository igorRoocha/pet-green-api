using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetGreen.Domain.Entities;

namespace PetGreen.Repository.Mapping
{
    public class ContactMap: IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("CDContact");

            builder.HasKey(c => c.ID);

            builder.Property(c => c.Number)
                   .IsRequired()
                   .HasColumnName("Number");

            builder.HasOne(c => c.User)
                   .WithMany(c => c.Contacts);
                
            builder.HasOne(c => c.Clinic)
                   .WithMany(c => c.Contacts);
        }
    }
}