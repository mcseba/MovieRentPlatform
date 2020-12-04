using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;
using System.Data.Entity.Validation;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MyDbContext _context;
        public MoviesController()
        {
            _context = new MyDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public IActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList().AsQueryable();
            return View(movies);
        }

        public IActionResult MovieDetail(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre)
                .SingleOrDefault(m => m.Id == id);
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genres = genres,
                Movie = movie
            };

            ViewBag.Info = "Edit Movie";

            return View("NewMovieForm", viewModel);
        }

        public IActionResult AddMovie()
        {
            var genres = _context.Genres.ToList();
            var movie = new Movie
            {
                DateAdded = DateTime.Today
            };

            var viewModel = new MovieFormViewModel
            {
                Genres = genres,
                Movie = movie
            };

            ViewBag.Info = "New movie";

            return View("NewMovieForm", viewModel);
        }

        public IActionResult SaveMovie(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };
                return View("NewMovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseYear = movie.ReleaseYear;
                movieInDb.DateAdded = movie.DateAdded;
                movieInDb.GenreId = movie.GenreId;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
    }
}
