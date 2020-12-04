using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public Genre Genre { get; set; }

        [Display(Name = "Genre")]
        [Required(ErrorMessage = "Please select genre.")]
        public byte GenreId { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "Please enter movie's title.")]
        [MaxLength(255)]
        public string Name { get; set; }

        [Display(Name="Year of release")]
        [Required(ErrorMessage = "Please enter movie's release year.")]
        public int ReleaseYear { get; set; }

        [Display(Name = "Date added")]
        [Required]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Number in stock")]
        [Required(ErrorMessage = "Please enter movie's quantity.")]
        public short NumberInStock { get; set; }
    }
}
