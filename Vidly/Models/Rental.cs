using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Rental
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Date Rented")]
        public DateTime DateRented { get; set; }

        [Display(Name = "Date Returned")]
        public DateTime? DateReturned { get; set; }

        [Required]
        public Customer Customer { get; set; }

        [Required]
        public Movie Movie { get; set; }

    }
}