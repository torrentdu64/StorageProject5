using StorageProject5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StorageProject5.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        // GET: Customers
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.customers.Single(x => x.Id == id);
            return View(customer);
        }

        [HttpPost]
        public ActionResult Update(Customer customer)
        {
            var dbCustomer = _context.customers.Single(x => x.Id == customer.Id );

            dbCustomer.Name = customer.Name;

            _context.SaveChanges();

            TempData["message"] = "Update Successfully";
            return RedirectToAction("AdminIndex", "Rentals");
        }
    }
}