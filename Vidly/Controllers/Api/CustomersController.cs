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
            return _context.Customers.ToList().Select(AutoMapper.Mapper.Map<Customer, CustomerDto>);
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

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        // PUT /api/customers/1
        [HttpPut]
        public async Task UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = await _context.Customers.SingleOrDefaultAsync(c => c.Id == id);

            if(customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            AutoMapper.Mapper.Map(customerDto, customerInDb);

            await _context.SaveChangesAsync();
        }

        // DELETE /api/customers/1
        [HttpDelete]
        public async Task DeleteCustomer(int id)
        {
            var customerInDb = await _context.Customers.SingleOrDefaultAsync(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerInDb);
            await _context.SaveChangesAsync();
        }
    }
}
