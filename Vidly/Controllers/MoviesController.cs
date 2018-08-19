using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;
using System.Data.Entity.Validation;


namespace Vidly.Controllers
{
    [Authorize(Roles = RoleName.CanManagerMovies)]
    public class MoviesController : Controller
    {

        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }




        [AllowAnonymous]
        [Route("movies")]
        public ActionResult GetMovies()
        {
            var moviesList = _context.Movies.Include(m => m.Genre).ToList();

            if (User.IsInRole(RoleName.CanManagerMovies))
            {
                return View("Movies", moviesList);
            }

            return View("ReadOnlyList", moviesList);
        }

        [AllowAnonymous]
        public ActionResult MovieDetails(int Id)
        {
            var movieDetail = _context.Movies.Include(m => m.Genre).FirstOrDefault(x => x.Id == Id);
            return View("MovieDetails", movieDetail);
        }



        public ActionResult New()
        {
            //get list of Genres for the MovieViewModel
            var movieGenres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                //movie = new Movie(), ==> having this line makes the form prepulate default values for all required properties
                                         // in the form at Load. But this I don;t want to prevent this, Move the movie model 
                                         // properties into the ModelFormViewModel and make them nullable
                Genres = movieGenres,
                Mode = "New Movie"
            };

            return View("MovieForm", viewModel);
        }



        [ValidateAntiForgeryToken]
        public ActionResult CreateUpdate(MovieFormViewModel movieFormData)
        {

            if (!ModelState.IsValid)
            {
                var viewModel2 = new MovieFormViewModel
                {
                    Genres = _context.Genres.ToList(),
                    Mode = movieFormData.Mode,
                };

                return View("MovieForm", viewModel2);
            }


            //movieId == 0, new movie
            if (movieFormData.Id == 0)
            {
                movieFormData.DateAdded = DateTime.Now;
                _context.Movies.Add(MovieMap(movieFormData));
            }
            //Update
            else
            {
                var movieInDb = _context.Movies.First(m => m.Id == movieFormData.Id);

                movieInDb.Name = movieFormData.Name;
                movieInDb.NumberInStock = (int)movieFormData.NumberInStock;
                movieInDb.ReleasedDate = (DateTime)movieFormData.ReleasedDate;
                movieInDb.GenreId = (int)movieFormData.GenreId;
            }

        
                _context.SaveChanges();
          


            return RedirectToAction("GetMovies");
        }



        public ActionResult Edit(int Id)
        {
            var movieToUpdate = _context.Movies.First(m => m.Id == Id);

            //get list of Genres for the MovieViewModel
            var movieGenres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Id = movieToUpdate.Id,
                Name = movieToUpdate.Name,
                NumberInStock = movieToUpdate.NumberInStock,
                DateAdded = movieToUpdate.DateAdded,
                GenreId = movieToUpdate.GenreId,
                ReleasedDate = movieToUpdate.ReleasedDate,
                Genres = movieGenres,
                Mode = "Edit Movie"
            };

            return View("MovieForm", viewModel);
        }



        private Movie MovieMap(MovieFormViewModel movie)
        {
            var movieMapped = new Movie
            {
                Id = (int)movie.Id,
                DateAdded = (DateTime)movie.DateAdded,
                GenreId = (int)movie.GenreId,
                Name = movie.Name,
                NumberInStock = (int)movie.NumberInStock,
                ReleasedDate = (DateTime)movie.ReleasedDate
            };

            return movieMapped;
        }



        [Route("Movies/released/{year}/{month}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        // custom Route
        public ActionResult ByReleaseDate2(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}