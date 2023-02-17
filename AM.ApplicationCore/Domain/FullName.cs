
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
   // [Owned]

    public class FullName
    {
        [MaxLength(25)]
        [MinLength(3, ErrorMessage = "Invalid Phone Number!")]
        [RegularExpression(@"^[a-zA-Z]{3,25}$", ErrorMessage = "Invalid Phone Number!")]
        public string FirstName { get; set; }
        [MaxLength(25)]
        [MinLength(3)]
        public string LastName { get; set; }
    }
}
