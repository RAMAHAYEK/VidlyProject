using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyProject.Models;

namespace VidlyProject.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
         
        public string Name { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public int NumberInStuck { get; set; }
        
        public GenreType Genre { get; set; }
    }
}