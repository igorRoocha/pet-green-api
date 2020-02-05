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

            modelBuilder.Entity<Address>(new AddressMap().Configure);
            modelBuilder.Entity<City>(new CityMap().Configure);
            modelBuilder.Entity<Clinic>(new ClinicMap().Configure);
            modelBuilder.Entity<Contact>(new ContactMap().Configure);
            modelBuilder.Entity<Profile>(new ProfileMap().Configure);
            modelBuilder.Entity<Schedule>(new SchedulesMap().Configure);
            modelBuilder.Entity<State>(new StateMap().Configure);
            modelBuilder.Entity<User>(new UserMap().Configure);
        }

        public DbSet<Address> Address { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Clinic> Clinic { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<User> User { get; set; }
    }
}