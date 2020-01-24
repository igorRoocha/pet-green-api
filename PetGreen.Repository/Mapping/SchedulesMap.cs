using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetGreen.Domain.Entities;

namespace PetGreen.Repository.Mapping
{
    public class SchedulesMap : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.ToTable("CDSchedules");

            builder.HasKey(c => c.ID);

            builder.Property(c => c.Day)
                   .IsRequired()
                   .HasColumnName("Day");

            builder.Property(c => c.StartHour)
                   .IsRequired()
                   .HasColumnName("StartHour");
            
            builder.Property(c => c.EndHour)
                   .IsRequired()
                   .HasColumnName("EndHour");
            
            builder.HasOne(c => c.Clinic)
                   .WithMany(c => c.Schedules)
                   .IsRequired();
        }
    }
}