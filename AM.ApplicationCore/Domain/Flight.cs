using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Flight
    {

        public int FlightId { get; set; }
        public string AirlineLogo { get; set; }
        [NotMapped]
      
        public DateTime FlightDate { get; set; }
        public int EstimatedDuration { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }

        public int PlaneFK { get; set; }
     
        
        public virtual IList<Passenger> Passengers { get; set; }

        [ForeignKey("PlaneFK")]
        public virtual Plane Plane { get; set; }



    }
}
