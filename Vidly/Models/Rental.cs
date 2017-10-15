using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Rental
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Date Rented")]
        public DateTime DateRented { get; set; }

        [Required]
        [Display(Name = "Date Returned")]
        public DateTime? DateReturned { get; set; }

        [Required]
        public Customer Customer { get; set; }

        [Required]
        public Movie Movie { get; set; }

    }
}