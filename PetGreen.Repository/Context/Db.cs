using Microsoft.EntityFrameworkCore;
using PetGreen.Domain.Entities;
using PetGreen.Repository.Mapping;

namespace PetGreen.Repository.Context
{
    public class Db : DbContext
    {
        public Db(DbContextOptions<Db> options)
                : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Clinic>(new ClinicMap().Configure);
            modelBuilder.Entity<ClinicType>(new ClinicTypeMap().Configure);
            modelBuilder.Entity<Contact>(new ContactMap().Configure);
            modelBuilder.Entity<MidiaSocial>(new MidiaSocialMap().Configure);
            modelBuilder.Entity<Profile>(new ProfileMap().Configure);
            modelBuilder.Entity<Schedule>(new SchedulesMap().Configure);
            modelBuilder.Entity<User>(new UserMap().Configure);
        }

        public DbSet<Clinic> Clinic { get; set; }

        public DbSet<ClinicType> ClinicType { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<MidiaSocial> MidiaSocial { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<User> User { get; set; }
    }
}