using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyProject.Models;
using VidlyProject.ViewModels;

namespace VidlyProject.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ViewResult Random()
        {
            var movie = new Movie() { Name = "Shadow recruit" };
            var customers = new List<Customer>
            {
                new Customer{ Name = "Rama Hayek" },
                new Customer{ Name = "Shahed Kayali" }
            };
            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };
            return View(viewModel);

           
        }
        //public ActionResult Edit(int id)
        //{
        //    return Content("id =" + id);
        //}
        ////movies
        //public ActionResult Index(int? pageIndex,string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;
        //    if (string.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";
        //    return Content(String.Format("pageIndex={0}&sortBy={1}" , pageIndex , sortBy));
        //}
        //public ActionResult ByReleaseDate(int year , int month)
        //{
        //    return Content(year + "/" + month);
        //}
    }

}