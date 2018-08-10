using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        // public Movie movie { get; set; }
        public List<MovieGenre> Genres { get; set; }
        public string Mode { get; set; }

        // movie model properties
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleasedDate { get; set; }


        [Required]
        public DateTime? DateAdded { get; set; }

        [Required]
        [Display(Name = "Number in Stock")]
        public int? NumberInStock { get; set; }

        //specific GenreFK
        [Display(Name = "Genre")]
        [Required]
        public int? GenreId { get; set; }


        public MovieFormViewModel()
        {
            // set Id = 0  to make sure in our form the hidden field id is prepopulated
            Id = 0;
        }
    }
}