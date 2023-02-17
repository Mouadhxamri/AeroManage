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
    public class TicketReservationConfiguration : IEntityTypeConfiguration<ReservationTicket>
    {
        public void Configure(EntityTypeBuilder<ReservationTicket> builder)
        {
           
            builder.HasKey(t => new
            {
                t.PassengerFk,t.TicketFk,t.DateReservation
            }
            );
        }
    }
}
