using StorageProject5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StorageProject5.Controllers
{
    public class FurnituresController : Controller
    {
        private ApplicationDbContext _context;
        public FurnituresController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        // GET: Furnitures
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Show(int id)
        {
            var furniture = _context.Furnitures.SingleOrDefault(m => m.Id == id);
            return View("Show");
        }

        //[AllowAnonymous]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        //[AllowAnonymous]
        public ActionResult Create(Furniture furniture)
        {
            
            _context.Furnitures.Add(furniture);

            _context.SaveChanges();
            TempData["message"] = "Deposit Successfully record";
            return RedirectToAction("Show", "Furnitures" , new { id = furniture.Id } );
        }
    }
}