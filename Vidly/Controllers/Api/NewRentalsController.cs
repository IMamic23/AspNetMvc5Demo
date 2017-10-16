using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Vidly.Models;
using Vidly.Models.ModelDto;

namespace Vidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public async Task<IHttpActionResult> CreateNewRentals(NewRentalDto newRental)
        {
            try
            {
                var customer = await _context.Customers.SingleAsync(c => c.Id == newRental.CustomerId);

                var movies = await _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToListAsync();

                foreach (var movie in movies)
                {
                    if (movie.NumberAvailable == 0)
                        return BadRequest("Movie is not available");

                    movie.NumberAvailable--;

                    var rental = new Rental
                    {
                        Customer = customer,
                        Movie = movie,
                        DateRented = DateTime.Now
                    };

                    _context.Rentals.Add(rental);
                }

                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        //[HttpPost]
        //public async Task<IHttpActionResult> CreateNewRentalsDefensiveForPublicApi(NewRentalDto newRental)
        //{
        //    if (newRental.MovieIds.Count == 0)
        //        return BadRequest("No movie Ids have been given");

        //    var customer = await _context.Customers.SingleOrDefaultAsync(c => c.Id == newRental.CustomerId);

        //    if (customer == null)
        //        return BadRequest("Customer Id is not valid.");

        //    var movies = await _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToListAsync();

        //    if (movies.Count != newRental.MovieIds.Count)
        //        return BadRequest("One or more movie Ids are invalid");

        //    foreach (var movie in movies)
        //    {
        //        if (movie.NumberAvailable == 0)
        //            return BadRequest("Movie is not available");

        //        movie.NumberAvailable--;

        //        var rental = new Rental
        //        {
        //            Customer = customer,
        //            Movie = movie,
        //            DateRented = DateTime.Now
        //        };

        //        _context.Rentals.Add(rental);
        //    }

        //    await _context.SaveChangesAsync();

        //    return Ok();
        //}
    }
}