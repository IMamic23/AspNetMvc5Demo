using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public async Task<ViewResult> Index()
        {
            var customers = await _context.Customers.Include(c => c.MembershipType).ToListAsync();

            return View(customers);
        }

        public async Task<ActionResult> Details(int id)
        {
            var customer = await _context.Customers.Include(c => c.MembershipType).SingleOrDefaultAsync(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public async Task<ActionResult> NewCustomer()
        {
            var membershipTypes = await _context.MembershipTypes.ToListAsync();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Save(Customer customer)
        {
            _context.Customers.AddOrUpdate(customer);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Customers");
        }

        public async Task<ActionResult> Edit(int id)
        {
            var customer = await _context.Customers.SingleOrDefaultAsync(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = await _context.MembershipTypes.ToListAsync()
            };
            return View("CustomerForm", viewModel);
        }
    }
}