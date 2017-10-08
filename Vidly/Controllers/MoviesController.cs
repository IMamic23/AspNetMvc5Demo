using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
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

        public async Task<ActionResult> New()
        {
            var genresList = await _context.Genres.ToListAsync();
            var viewModel = new MovieFormViewModel
            {
                Genres = genresList
            };

            return View("MovieForm", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel()
                {
                    Genres = await _context.Genres.ToListAsync()
                };

                AutoMapper.Mapper.Map(movie, viewModel);

                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
            }
            else
            {
                var movieInDb = await _context.Movies.SingleOrDefaultAsync(m => m.Id == movie.Id);
                movie.DateAdded = movieInDb.DateAdded;
            }
            movie.LastUpdateDate = DateTime.Now;

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
                Genres = await _context.Genres.ToListAsync()
            };

            AutoMapper.Mapper.Map(movie, viewModel);

            return View("MovieForm", viewModel);
        }
    }
}