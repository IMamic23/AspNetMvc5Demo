using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public int? Id { get; set; } = 0;

        [Required(ErrorMessage = "Please enter movie's name.")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        [DataType(DataType.DateTime)]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Number in Stock")]
        [Range(1, 20, ErrorMessage = "Number in stock should be between 1 and 20")]
        public byte? InStock { get; set; } = 0;

        [Required]
        public byte? GenreId { get; set; }

        public string Title => Id != 0 ? "Edit Movie" : "New Movie";
    }
}