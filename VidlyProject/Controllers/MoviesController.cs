using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyProject.Models;
using VidlyProject.ViewModels;

namespace VidlyProject.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Movies
        public ViewResult Index()
        {
            #region some code we may need 
            //var movie = new Movie() { Name = "Shadow recruit" };
            //var customers = new List<Customer>
            //{
            //    new Customer{ Name = "Rama Hayek" },
            //    new Customer{ Name = "Shahed Kayali" }
            //};
            //var viewModel = new RandomMovieViewModel()
            //{
            //    Movie = movie,
            //    Customers = customers
            //};
            //return View(viewModel);
            #endregion
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("Index");
                return View("ReadOnlyList");
            //    var movies = _context.Movies.ToList();
            //return View(movies);

        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null) return HttpNotFound();
            return View(movie);
         
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genreTypes = Enum.GetValues(typeof(GenreType)).Cast<GenreType>();
            var viewModel = new AddEditMovieViewModel
            {
                genreTypes = genreTypes
                ,
                Movie = new Movie()
            };
            return View("AddEditMovie", viewModel);
            
        }

        [HttpPost]
        public ActionResult Save(Movie movie , HttpPostedFileBase  picture)
        {

            if (picture != null && picture.ContentLength > 0)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    string PictureFileName = picture.FileName;
                    picture.InputStream.CopyTo(ms);
                    Image bpic = Bitmap.FromStream(ms);
                    Bitmap bitmap = new Bitmap(bpic);
                    string path = Path.Combine(Server.MapPath("/Content/Uploads/movies/") + PictureFileName);
                    if (!Directory.Exists(Server.MapPath("/Content/Uploads/movies/")))
                        Directory.CreateDirectory(Server.MapPath("/Content/Uploads/movies/"));
                    picture.SaveAs(path);
                    //bitmap.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
                    movie.ImagePath = "/Content/Uploads/Slides/" + PictureFileName;
                }
            }

            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.NumberInStuck = movie.NumberInStuck;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.Genre = movie.Genre;
                movieInDb.ImagePath = movie.ImagePath;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
        #region some code about routing 
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
        #endregion
 

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            var genreTypes = Enum.GetValues(typeof(GenreType)).Cast<GenreType>();
            if (movie == null)
            {
                return HttpNotFound();
            }
            var viewModel = new AddEditMovieViewModel()
            {
                Movie = movie,
                genreTypes = genreTypes
            };
            return View("AddEditMovie" , viewModel);
        }
    }

}