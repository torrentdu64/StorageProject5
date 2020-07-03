using StorageProject5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StorageProject5.ViewModels;

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

            var rentals = _context.Rentals.Select(x => x.Id).ToList();

            //var existingIds = db.ExistingBorrower.Select(x => x.ID).ToList();

            //var newBorrowers = db.AllClients.Where(x => !existingIds.Contains(x.ID));


            
            var availableFurnitures = _context.Furnitures.Where(x => !rentals.Contains(x.Id) ).ToList();

            //var availableFurniture = new List<Furniture>();
            //for (int i = 0; i < furnitures.Count; i++)
            //{
            //    if (rentals[i].FurnitureId.Equals(furnitures[i].Id))
            //    {
            //        availableFurniture.Add(furnitures[i]);
            //    }
            //}

            RentalFurnitureViewModel viewModel = new RentalFurnitureViewModel()
            {
                Furnitures = furnitures,
                availableFurnitures = availableFurnitures


            };


            return View(viewModel);
        }
        public ActionResult New(int id)
        {
            var furniture = _context.Furnitures.SingleOrDefault(m => m.Id == id);
            var rent = new Rental();

            RentalFurnitureViewModel viewModel = new RentalFurnitureViewModel()
            {
                Furniture = furniture,
                Rental = rent
            };

            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Create(RentalFurnitureViewModel rentalPropose)
        {
            Rental rental = new Rental()
            {
                Name = rentalPropose.Rental.Name,
                FurnitureId = rentalPropose.Furniture.Id
            };
            _context.Rentals.Add(rental);
            
            _context.SaveChanges();

            TempData["message"] = "Your Rental Successfully record";

            return RedirectToAction("Index", "Rentals");
           
        }
    }
}