using StorageProject5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StorageProject5.Controllers
{
    public class PartsController : Controller
    {

        private ApplicationDbContext _context;
        public PartsController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
        // GET: Parts
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(Furniture furniture, Part part)
        {


            //_context.Parts.Add(part);
            //_context.SaveChanges();
            return RedirectToAction("AdminListFurniture", "Furnitures");
        }
    }
}