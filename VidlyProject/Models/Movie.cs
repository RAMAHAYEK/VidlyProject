using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyProject.Models
{
    public enum GenreType
    {
        Action = 0,
        Thriller = 1,
        Family = 2,
        Romance = 3,
        Comedy = 4
    }
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public int NumberInStuck { get; set; }

        [Required]
        public GenreType Genre { get; set; }

        public string ImagePath { get; set; }
    }
}