using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vidly.Models;
using System.Data.Entity;

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
    }
}
