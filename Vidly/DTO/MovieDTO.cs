using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.DTO
{
    public class MovieDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }

        [Required]

        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        public int NumberOfStocks { get; set; }

        public GenreDto Genre { get; set; }


        [Required]
        [Display(Name = "Genre")]
        public int GenreDtoId { get; set; }
    }
}