using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetGreen.Domain.Entities;

namespace PetGreen.Repository.Mapping
{
    public class StateMap : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.ToTable("CDState");

            builder.HasKey(s => s.ID);

            builder.Property(s => s.Name)
                  .IsRequired()
                  .HasColumnName("Name");

            builder.Property(s => s.UF)
                   .IsRequired()
                   .HasColumnName("UF");

            builder.Property(s => s.CreatedAt)
                   .IsRequired()
                   .HasColumnName("CreatedAt");

            builder.Property(s => s.UpdatedAt)
                   .HasColumnName("UpdatedAt");
        }
    }
}
