using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight :Service<Flight>, IServiceFlight
    {

        public List<Flight> Flights = new List<Flight>();

        //Delegates
        public Action<Plane> FlightDetailsDel;
        public Func<string, double> DurationAverageDel;

        public ServiceFlight(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            //DurationAverageDel = DurationAverage;
            DurationAverageDel = dest =>
            {
                return (from f in Flights
                        where f.Destination.Equals(dest)
                        select f.EstimatedDuration).Average();
            };
            // FlightDetailsDel = ShowFlightDetails;
            FlightDetailsDel = p =>
            {
                var req = from f in Flights
                          where f.Plane == p
                          select new { f.FlightDate, f.Destination };
                foreach (var v in req)
                    Console.WriteLine("Flight Date; " + v.FlightDate + " Flight destination: " + v.Destination);
            };
        }

      
        public List<DateTime> GetFlightDates(string destination)
        {
            List<DateTime> ls = new List<DateTime>();
            //With for structure
            //for (int j = 0; j < Flights.Count; j++)
            //    if (Flights[j].Destination.Equals(destination))
            //        ls.Add(Flights[j].FlightDate);

            //With foreach structure
            //foreach(Flight f in Flights)
            //    if (f.Destination.Equals(destination))
            //        ls.Add(f.FlightDate);
            //return ls;

            //with LINQ language
            var query = from f in Flights
                      where
                      f.Destination.Equals(destination)
                      select f.FlightDate;
            return query.ToList();

            //with Lambda expressions
            // IEnumerable<DateTime> reqLambda = Flights.Where(f => f.Destination.Equals(destination)).Select(f => f.FlightDate);
        }

        public void GetFlights(string filterType, string filterValue)
        {
            switch (filterType)
            {
                case "Destination":
                    foreach (Flight f in Flights)
                    {
                        if (f.Destination.Equals(filterValue))
                            Console.WriteLine(f);
                    }
                    break;
                case "FlightDate":
                    foreach (Flight f in Flights)
                    {
                        if (f.FlightDate == DateTime.Parse(filterValue))

                            Console.WriteLine(f);

                    }
                    break;
                case "EffectiveArrival":
                    foreach (Flight f in Flights)
                    {
                        if (f.EffectiveArrival == DateTime.Parse(filterValue))
                            Console.WriteLine(f);
                    }
                    break;
            }

        }

        public void ShowFlightDetails(Plane plane)
        {
            var req = from f in Flights
                      where f.Plane == plane
                      select new { f.FlightDate, f.Destination };
            //  var reqLambda = Flights.Where(f => f.Plane == plane).Select(p => new { f.FlightDate, f.Destination });
            foreach (var v in req)
                Console.WriteLine("Flight Date; " + v.FlightDate + " Flight destination: " + v.Destination);
        }

        public int ProgrammedFlightNumber(DateTime startDate)
        {
            var req = from f in Flights
                      where (f.FlightDate).CompareTo(startDate) > 0 && (f.FlightDate - startDate).TotalDays < 7
                      select f;
            // var reqLambda = Flights.Where(f => DateTime.Compare(f.FlightDate, startDate) > 0 && (f.FlightDate - startDate).TotalDays < 7);
            return req.Count();

        }

        public double DurationAverage(string destination)
        {
            return (from f in Flights
                    where f.Destination.Equals(destination)
                    select f.EstimatedDuration).Average();
            // return Flights.Where(f=>f.Destination.Equals(destination)).Select(f=> f.EstimatedDuration).Average();
        }

        public IEnumerable<Flight> OrderedDurationFlights()
        {
            //var req = from f in Flights
            //          orderby f.EstimatedDuration descending
            //          select f;
            
            //return req;

            //lambda expression

            return Flights.OrderByDescending(f => f.EstimatedDuration);

        }
        public IEnumerable<Traveller> SeniorTravellers(Flight f)
        {

            var oldTravellers = from p in f.Passengers.OfType<Traveller>()
                                orderby p.BirthDate
                                select p;

            var reqLambda = f.Passengers.OfType<Traveller>().OrderBy(p => p.BirthDate).Take(3);


            return oldTravellers.Take(3);
            //if we want to skip 3
            //return oldTravellers.Skip(3);

        }

        public IGrouping<string, IEnumerable<Flight>> DestinationGroupedFlights()
        {
            var req = from f in Flights
                      group f by f.Destination;

            //  var reqLambda = Flights.GroupBy(f => f.Destination);

            foreach (var g in req)
            {
                Console.WriteLine("Destination: " + g.Key);
                foreach (var f in g)
                    Console.WriteLine("Décollage: " + f.FlightDate);

            }
            return (IGrouping<string, IEnumerable<Flight>>)req;
        }

        //pour tester la méthode DestinationGroupedFlights
        public void diplay()
        {
            var result =
                (from f in Flights
                 group f by f.Destination);

            foreach (var destination in result)
            {
                Console.WriteLine(" destination =  " + destination.Key); // key = city
                foreach (var flight in destination)
                {
                    Console.WriteLine("Flights Details" + flight.FlightDate);

                }
            }

        }

    }
}
