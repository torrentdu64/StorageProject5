using StorageProject5.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StorageProject5.ViewModels;

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

        public ActionResult AdminListFurniture()
        {
            var furnitures = _context.Furnitures.ToList();
            return View(furnitures);
        }

        public ActionResult Show(int id)
        {
            var furniture = _context.Furnitures.SingleOrDefault(m => m.Id == id);
            return View(furniture);
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

        public ActionResult AdminFurnitureParts(int id)
        {
            var furniture = _context.Furnitures.SingleOrDefault(m => m.Id == id);

            var viewModel = new FourniturePartViewModel
            {
                Furniture = furniture,
                Part = new Part()
            };

            return View(viewModel);
        }
    }
}