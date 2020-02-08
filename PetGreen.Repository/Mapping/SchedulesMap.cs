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

            builder.HasKey(s => s.ID);

            builder.Property(s => s.Days)
                   .IsRequired()
                   .HasColumnName("Day");

            builder.Property(s => s.StartHour)
                   .IsRequired()
                   .HasColumnName("StartHour");
            
            builder.Property(s => s.EndHour)
                   .IsRequired()
                   .HasColumnName("EndHour");
            
            builder.HasOne(s => s.Clinic)
                   .WithMany(s => s.Schedules)
                   .HasForeignKey(s => s.ClinicID)
                   .IsRequired();
        }
    }
}