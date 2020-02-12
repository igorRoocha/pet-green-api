using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetGreen.Domain.Entities.Register;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetGreen.Repository.Mapping.Register
{
    public class SpecieMap : IEntityTypeConfiguration<Specie>
    {
        public void Configure(EntityTypeBuilder<Specie> builder)
        {
            builder.ToTable("CDSpecie");

            builder.HasKey(s => s.ID);

            builder.Property(s => s.Name)
                  .IsRequired()
                  .HasColumnName("Name");

            builder.Property(s => s.CreatedAt)
                   .IsRequired()
                   .HasColumnName("CreatedAt");

            builder.Property(s => s.UpdatedAt)
                   .HasColumnName("UpdatedAt");
        }
    }
}
