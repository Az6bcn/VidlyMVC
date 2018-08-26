using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Rental
    {
        public int RentalID { get; set; }

        public DateTime DateRented { get; set; }

        public DateTime? DateReturned { get; set; }

        [Required]
        public Customer Customer { get; set; }

        public int CustomerID { get; set; }

         [Required]
        public Movie Movie { get; set; }

        public int MovieID { get; set; }
    }
}