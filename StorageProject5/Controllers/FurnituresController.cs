using StorageProject5.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StorageProject5.ViewModels;
using System.Data.Entity;

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
            var partsLocations = _context.Parts.Include(m => m.Location).ToList();
            var viewModel = new FourniturePartViewModel
            {
                Furnitures = furnitures,
                Parts = partsLocations,
            };

            return View(viewModel);
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
            //_context.Parts.Add(new Part { Name = "Need to be administrate" });
            _context.SaveChanges();
            TempData["message"] = "Deposit Successfully record";
            return RedirectToAction("Show", "Furnitures" , new { id = furniture.Id } );
        }

        public ActionResult AdminFurnitureParts(int id)
        {
            var furniture = _context.Furnitures.SingleOrDefault(m => m.Id == id);

            var parts = _context.Parts.Where( m => m.FurnitureId == id).ToList();
            var locations = _context.Parts.Include(m => m.Location ).ToList();
            var location = new Location();
            var viewModel = new FourniturePartViewModel
            {
                Furniture = furniture,
                Part = new Part(),
                Location = location,
                Parts = parts,
                Locations = locations
            };

            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var furniture = _context.Furnitures.SingleOrDefault(m => m.Id == id);
            if (furniture == null)
                return HttpNotFound();

            return View(furniture);
        }

        [HttpPost]
        public ActionResult Update(Furniture furniture)
        {
            var dbFurniture = _context.Furnitures.Single( m => m.Id == furniture.Id);
            dbFurniture.Name = furniture.Name;
            _context.SaveChanges();
            TempData["message"] = "Update Successfully";
            return RedirectToAction("AdminListFurniture", "Furnitures");
        }

        
        public ActionResult GiveBack(RenderFurnitureViewModel code)
        {
            var rental = _context.Rentals.Where(x => x.Name == code.CodeName).Select(x => x.FurnitureId).ToList();
            var furnitures = _context.Furnitures.Where(x => rental.Contains(x.Id) ).ToList();
            
            return View(furnitures);
        }

   
        public ActionResult Back(Furniture furniture)
        {

            //var test = Request.Params("item.IsRented[]");

            //var partName = Request.Params["FurnitureBack"];

            //var partName3 = Request.Params["item.id"];
            //var partName233 = Request.Form["item.IsRented"];

            //var partName5 = Request.Params["item.Name"];
            //var partName78 = Request.Params["name"];
            //var partName2 = Request.Form["value"];

            var furnitureBack = Request.Params["item.id"].Split(',').ToList();


            List<Furniture> furnitureGiveBack = new List<Furniture>();
            for (int i = 0; i < furnitureBack.Count; i++)
            {
                // check if bool of id came from if giveback
                var furnitureIdBack = int.Parse(furnitureBack[i]);
                var dbFurniture = _context.Furnitures.Single(m => m.Id == furnitureIdBack);
                //furnitureGiveBack.Add(d);
                dbFurniture.IsRented = false;
            }

            _context.SaveChanges();


            return RedirectToAction( "Index" , "Home" );
        }
    }
}