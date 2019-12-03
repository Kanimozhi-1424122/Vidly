using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Random()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
            {
                return View("List");
                //var movie = GetMovies().ToList();
                //var movie = _context.Movies.Include(c => c.Genre).ToList();
                //if (movie == null)
                //{
                //    return Content("No Movies");
                //}
            }
            return View("ReadOnlyList");
              //return View(movie);
        }
        public ActionResult GetMoviesById(int id)
        {
            // var movie = GetMovies().FirstOrDefault(c => c.Id == id);
            var movie = _context.Movies.Include(c => c.Genre).FirstOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }
        public List<Movie> GetMovies()
        {
            var movie = new List<Movie>()
            {
             new Movie{Id=1,Name="Bigil"},
             new Movie{Id=2,Name="Asuran"},
            };
            return movie;
        }
        [Authorize(Roles =RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var Genre = _context.Genres.ToList();
            var viewmodel = new MovieFromViewModel
            {
                Movie = new Movie(),
                Genres = Genre
            };
          
            return View("New",viewmodel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var Genre = _context.Genres.ToList();
                var viewmodel = new MovieFromViewModel
                {
                   
                    Genres = Genre
                };

                return View("New", viewmodel);
            }
            else
            {
                if (movie.Id == 0)
                {
                    movie.DateAdded = DateTime.Now;
                    _context.Movies.Add(movie);
                }
                else
                {
                    var customersInDb = _context.Movies.FirstOrDefault(c => c.Id == movie.Id);
                    customersInDb.Name = movie.Name;
                    customersInDb.ReleaseDate = movie.ReleaseDate;
                    customersInDb.Genre = movie.Genre;
                    customersInDb.NumberOfStocks = movie.NumberOfStocks;
                    _context.SaveChanges();
                    return RedirectToAction("Random", "Movies");
                }
                _context.SaveChanges();
                return RedirectToAction("Random", "Movies");
            }
        }
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.FirstOrDefault(c => c.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            var viewmodel = new MovieFromViewModel
            {
               Movie=movie,
               Genres=_context.Genres.ToList()
            };
            return View("New",viewmodel);         
        }      
    }
}