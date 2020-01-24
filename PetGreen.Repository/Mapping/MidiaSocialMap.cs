using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetGreen.Domain.Entities;

namespace PetGreen.Repository.Mapping
{
    public class MidiaSocialMap : IEntityTypeConfiguration<MidiaSocial>
    {
        public void Configure(EntityTypeBuilder<MidiaSocial> builder)
        {
            builder.ToTable("CDMidiaSocial");

            builder.HasKey(c => c.ID);

            builder.Property(c => c.URL)
                   .IsRequired()
                   .HasColumnName("URL");

            builder.HasOne(c => c.Clinic)
                   .WithMany(c => c.MidiaSocial)
                   .IsRequired();
        }
    }
}