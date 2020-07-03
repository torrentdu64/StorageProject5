using StorageProject5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StorageProject5.Controllers
{
    public class RentalsController : Controller
    {
        private ApplicationDbContext _context;
        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
        // GET: Rentals
        public ActionResult Index()
        {
            var furnitures = _context.Furnitures.ToList();

            return View(furnitures);
        }
    }
}