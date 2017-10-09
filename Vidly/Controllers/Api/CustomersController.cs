using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/customers
        [HttpGet]
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers
                .Include(c => c.MembershipType)
                .ToList()
                .Select(AutoMapper.Mapper.Map<Customer, CustomerDto>);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetCustomer(int id)
        {
            var customer = await _context.Customers.SingleOrDefaultAsync(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return Ok(AutoMapper.Mapper.Map<CustomerDto>(customer));
        }

        // POST /api/customers
        [HttpPost]
        public async Task<IHttpActionResult> CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = AutoMapper.Mapper.Map<Customer>(customerDto);
            customer.LastUpdateDate = DateTime.Now;
            customer.DateCreated = DateTime.Now;

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        // PUT /api/customers/1
        [HttpPut]
        public async Task<IHttpActionResult> UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerInDb = await _context.Customers.SingleOrDefaultAsync(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            AutoMapper.Mapper.Map(customerDto, customerInDb);
            customerInDb.LastUpdateDate = DateTime.Now;

            await _context.SaveChangesAsync();

            return Ok(customerDto);
        }

        // DELETE /api/customers/1
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteCustomer(int id)
        {
            var customerInDb = await _context.Customers.SingleOrDefaultAsync(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            _context.Customers.Remove(customerInDb);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
