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
            var currentRentals = _context.Rentals.Select(x => x.FurnitureId).ToList();
            var availableFurnitures = _context.Furnitures.Where(x => !currentRentals.Contains(x.Id) ).ToList();

            RentalFurnitureViewModel viewModel = new RentalFurnitureViewModel()
            {
                availableFurnitures = availableFurnitures
            };

            return View(viewModel);
        }

        public ActionResult AdminIndex()
        {
            var furnitures = _context.Furnitures.ToList();
            var currentRentals = _context.Rentals.Select(x => x.FurnitureId).ToList();
            var rentals = _context.Rentals.ToList();


            var availableFurnitures = _context.Furnitures.Where(x => !currentRentals.Contains(x.Id)).ToList();



            RentalFurnitureViewModel viewModel = new RentalFurnitureViewModel()
            {
                Rentals = rentals,
                Furnitures = furnitures,
                availableFurnitures = availableFurnitures
            };


            return View(viewModel);
        }


        public ActionResult New(int? id)
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

        public ActionResult Edit(int id)
        {
            var rent = _context.Rentals.SingleOrDefault(x => x.Id == id);
            return View(rent);
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

        public ActionResult Update(Rental rental)
        {

            var dbRental = _context.Rentals.Single(m => m.Id == rental.Id);
            dbRental.Name = rental.Name;
            _context.SaveChanges();
            TempData["message"] = "Update Rental Successfully";
            return RedirectToAction("AdminIndex", "rentals");
            
        }
    }
}