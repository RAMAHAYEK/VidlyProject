using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyProject.Models;

namespace VidlyProject.ViewModels
{
    public class AddEditMovieViewModel
    {
        public IEnumerable<GenreType> genreTypes { get; set; }
        public Movie Movie { get; set; }

    }
}