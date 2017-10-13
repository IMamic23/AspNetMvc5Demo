using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter movie's name.")]
        public string Name { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "Number in stock should be between 1 and 20")]
        public byte InStock { get; set; } = 0;

        [Required]
        public byte GenreId { get; set; }

        public Genre Genre { get; set; }
    }
}