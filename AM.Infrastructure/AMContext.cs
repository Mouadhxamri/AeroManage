using AM.ApplicationCore.Domain;
using AM.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure
{
    public class AMContext:DbContext
    {
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Staff> Staffs { get; set; }

        public DbSet<Traveller> Travellers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<ReservationTicket> ReservationTickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                       Initial Catalog=AirportManagement;
                       Integrated Security=true;MultipleActiveResultSets=true");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FlightConfiguration());
            modelBuilder.ApplyConfiguration(new PlaneConfiguration());

            // 2 ème méthode // configuration du type complexe : fullName
            modelBuilder.Entity<Passenger>().OwnsOne(p => p.FullName, full =>
            {
                full.Property(f => f.FirstName).HasColumnName("PassFirstName").HasMaxLength(30);
                full.Property(f => f.LastName).HasColumnName("PassLastName").IsRequired();
            });
            //TPH


            //.HasDiscriminator<int>("IsTraveller")
            //    .HasValue<Passenger>(0)
            //    .HasValue<Traveller>(2)
            //    .HasValue<Staff>(1);

            //TPT
            modelBuilder.Entity<Staff>().ToTable("Staffs");
            modelBuilder.Entity<Traveller>().ToTable("Travellers");

            modelBuilder.ApplyConfiguration(new TicketReservationConfiguration());

        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder
             .Properties<DateTime>()
                 .HaveColumnType("date");
        }
    }
}
