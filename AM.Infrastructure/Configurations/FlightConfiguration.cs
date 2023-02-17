using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.Configurations
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {

            // configuration de * * association, renommer la table d'association
            builder.HasMany(f => f.Passengers)
            .WithMany(p => p.Flights)
            .UsingEntity(j => j.ToTable("ReservationFlight"));

            //configuration de one to many 
            builder.HasOne(f => f.Plane)
              .WithMany(p => p.Flights)
              // 2 eme methode 
            //  .HasForeignKey(f => f.PlaneFK)
              .OnDelete(DeleteBehavior.Cascade); //The values of foreign key properties in dependent entities are set to null when the related principal is deleted
        }




    }
}
