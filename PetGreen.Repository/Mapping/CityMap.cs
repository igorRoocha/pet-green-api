using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetGreen.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetGreen.Repository.Mapping
{
    public class CityMap : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("CDCity");

            builder.HasKey(c => c.ID);

            builder.Property(c => c.Name)
                  .IsRequired()
                  .HasColumnName("Name");

            builder.Property(c => c.IBGE)
                   .IsRequired()
                   .HasColumnName("IBGE");

            builder.HasOne(c => c.State)
                   .WithMany(c => c.Cities)
                   .HasForeignKey(c => c.StateID)
                   .IsRequired();

            builder.Property(c => c.CreatedAt)
                   .IsRequired()
                   .HasColumnName("CreatedAt");

            builder.Property(c => c.UpdatedAt)
                   .HasColumnName("UpdatedAt");

        }
    }
}
