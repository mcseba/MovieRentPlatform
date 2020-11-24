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
            return View(movie);
        }

        public IActionResult AddMovie()
        {
            var genres = _context.Genres.ToList();
            var movie = new Movie
            {
                DateAdded = DateTime.Today.Date
            };

            var viewModel = new MovieFormViewModel
            {
                Genres = genres,
                Movie = movie
            };

            return View("NewMovieForm", viewModel);
        }

        public IActionResult SaveMovie(Movie movie)
        {
            try
            {
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
            } 
            catch(DbEntityValidationException e)
            {
                foreach(var ex in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following " +
                        "validation errors: ", ex.Entry.Entity.GetType().Name, ex.Entry.State);
                    foreach (var ve in ex.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
                    }
                }
            }

            return RedirectToAction("Index", "Movies");
        }
    }
}
