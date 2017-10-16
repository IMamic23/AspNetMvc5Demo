using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Vidly.Models;
using Vidly.Models.ModelDto;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/movies
        [HttpGet]
        public IEnumerable<MovieDto> GetMovies(string query = null)
        {
            var moviesQuery = _context.Movies
                .Include(m => m.Genre)
                .Where(m => m.NumberAvailable > 0);

            if (!String.IsNullOrWhiteSpace(query))
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));

            return moviesQuery
                .ToList()
                .Select(AutoMapper.Mapper.Map<Movie, MovieDto>);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetMovie(int id)
        {
            var movie = await _context.Movies.SingleOrDefaultAsync(c => c.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(AutoMapper.Mapper.Map<MovieDto>(movie));
        }

        // POST /api/movies
        [Authorize(Roles = RoleName.CanManageMovies)]
        [HttpPost]
        public async Task<IHttpActionResult> CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = AutoMapper.Mapper.Map<Movie>(movieDto);
            movie.LastUpdateDate = DateTime.Now;
            movie.DateAdded = DateTime.Now;

            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        // PUT /api/movies/1
        [Authorize(Roles = RoleName.CanManageMovies)]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = await _context.Movies.SingleOrDefaultAsync(c => c.Id == id);

            if (movieInDb == null)
                return NotFound();

            AutoMapper.Mapper.Map(movieDto, movieInDb);
            movieInDb.LastUpdateDate = DateTime.Now;

            await _context.SaveChangesAsync();

            return Ok(movieDto);
        }

        // DELETE /api/movies/1
        [Authorize(Roles = RoleName.CanManageMovies)]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteMovie(int id)
        {
            var movieInDb = await _context.Movies.SingleOrDefaultAsync(c => c.Id == id);

            if (movieInDb == null)
                return NotFound();

            _context.Movies.Remove(movieInDb);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
