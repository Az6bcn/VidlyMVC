﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleasedDate { get; set; }


        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        [Display(Name = "Number in Stock")]
        public int NumberInStock { get; set; }

        public MovieGenre Genre { get; set; } //Navigation property

        //specific GenreFK
        [Display(Name = "Genre")]
        [Required]
        public int GenreId { get; set; }

        public int NumberAvailable { get; set; }
    }
}