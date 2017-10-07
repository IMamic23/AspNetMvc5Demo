using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using Vidly.Mapper;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _iMapper;

        public MoviesController()
        {
            _context = new ApplicationDbContext();

            var config = new AutoMapperConfiguration().Configure();
            _iMapper = config.CreateMapper();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public async Task<ViewResult>Index()
        {
            var movies = await _context.Movies.Include(m => m.Genre).ToListAsync();

            return View(movies);
        }

        // GET: Movies/Details
        public async Task<ActionResult> Details(int id)
        {
            var movie = await _context.Movies.Include(c => c.Genre).SingleOrDefaultAsync(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        public async Task<ActionResult> NewMovie()
        {
            var genresList = await _context.Genres.ToListAsync();
            var viewModel = new MovieFormViewModel
            {
                Genres = genresList
            };

            return View("MovieForm", viewModel);
        }
        [HttpPost]
        public async Task<ActionResult> Save(Movie movie)
        {
            Movie movieInDb = new Movie();

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
            }
            else
            {
                movieInDb = await _context.Movies.SingleOrDefaultAsync(m => m.Id == movie.Id);
                movie.DateAdded = movieInDb.DateAdded;
            }

            _context.Movies.AddOrUpdate(movie);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Movies");
        }

        public async Task<ActionResult> Edit(int id)
        {
            var movie = await _context.Movies.SingleOrDefaultAsync(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel()
            {
                Movie = movie,
                Genres = await _context.Genres.ToListAsync()
            };
            return View("MovieForm", viewModel);
        }
    }
}