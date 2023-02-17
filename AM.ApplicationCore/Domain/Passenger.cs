using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {

        [Key]
        [StringLength(7)]
        public string PassportNumber { get; set; }
        public FullName FullName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date of birth")]
        public DateTime BirthDate { get; set; }

        [RegularExpression(@"^[0-9]{8}$", ErrorMessage = "Invalid Phone Number!")]
        [Range(0, 8)]
        public int? TelNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public string? EmailAddress { get; set; }
        public virtual IList<Flight> Flights { get; set; }
        public virtual IList<ReservationTicket> ReservationTickets { get; set; }
        //public override string ToString()
        //{
        //    return "FirstName: " + FirstName + " LastName: " + LastName + " date of Birth: " + BirthDate;
        //}

        //poly par signature 
        //public bool CheckProfile (string firstName , string lastName)
        //{
        //    return FirstName==firstName && LastName==lastName;  

        //}

        //public bool CheckProfile(string firstName , string lastName,string email)
        //{
        //    return FirstName == firstName && LastName == lastName && EmailAddress == email;    
        //}

        //public bool login(string firstName, string lastName, string email = null)
        //{
        //   if(email != null)
        //    return FirstName == firstName && LastName == lastName && EmailAddress == email;
        //    return FirstName == firstName && LastName == lastName;
        //}

        //public bool login1(string firstName, string lastName, string email = null)
        //{
        //    if (email != null)
        //        return CheckProfile(firstName, lastName, email);
        //    return FirstName == firstName && LastName == LastName;
        //}

        public virtual void PassengerType()
        {

            Console.WriteLine("I'Passenger");
        }
    }
}
