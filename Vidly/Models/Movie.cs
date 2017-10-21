using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter movie's name.")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        public DateTime LastUpdateDate { get; set; }

        [Required]
        [Display(Name = "Number in Stock")]
        [Range(1,20, ErrorMessage = "Number in stock should be between 1 and 20")]
        public byte InStock { get; set; } = 0;

        public byte NumberAvailable { get; set; }

        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }
        [Required]
        public byte GenreId { get; set; }
    }
}