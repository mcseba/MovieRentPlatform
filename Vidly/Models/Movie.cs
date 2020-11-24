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
        [Required]
        public byte GenreId { get; set; }

        [Display(Name = "Title")]
        [Required]
        public string Name { get; set; }

        [Display(Name="Year of release")]
        [Required]
        public int ReleaseYear { get; set; }

        [Display(Name = "Date added")]
        [Required]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Number in stock")]
        [Required]
        public short NumberInStock { get; set; }
    }
}
