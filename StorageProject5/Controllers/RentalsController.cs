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

            var customers = _context.customers.ToList();


            List<Rental> rentals = new List<Rental>();
            for (int i = 0; i < customers.Count; i++)
            {
                var customerIdLoop = customers[i].Id;
                Rental rental = new Rental();
                rental.furnituresFromRental = _context.Rentals.Where(x => x.CustomerId == customerIdLoop).ToList();

                rentals.Add(rental);
            }

            List<Furniture> furnitures = new List<Furniture>();
            for (int i = 0; i < rentals.Count; i++)
            {
               //var furnitureCount = _context.Furnitures.Where( x => x.)
                var furnitureIdLoop = rentals[i].FurnitureId;
                Furniture furniture = new Furniture();
                furniture = _context.Furnitures.FirstOrDefault(x => x.Id == furnitureIdLoop);
                furnitures.Add(furniture);
            }

            //var furnitures = _context.Furnitures.ToList();
            //var currentRentals = _context.Rentals.Select(x => x.FurnitureId).ToList();
            


            //var availableFurnitures = _context.Furnitures.Where(x => !currentRentals.Contains(x.Id)).ToList();

            

            RentalFurnitureViewModel viewModel = new RentalFurnitureViewModel()
            {
                customers = customers,
                Rentals = rentals,
                Furnitures = furnitures
            };


            return View(viewModel);
        }


        public ActionResult New(RentalFurnitureViewModel multipleRentalPropose)
        {
            List<Furniture> furnitures = new List<Furniture>();
            foreach (var item in multipleRentalPropose.availableFurnitures)
            {
                if (item.IsRented)
                {
                    Furniture furniture = new Furniture();
                    furniture.Id = item.Id;
                    furniture.Name = item.Name;
                    furniture.IsRented = item.IsRented;
                    furnitures.Add(furniture);
                }
            }
            
            
            //var furniture = _context.Furnitures.SingleOrDefault(m => m.Id == id);
            var rent = new Rental();
            var customer = new Customer();

            RentalFurnitureViewModel viewModel = new RentalFurnitureViewModel()
            {
                Furnitures = furnitures,
                Rental = rent,
                Customer = customer
            };

            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var rent = _context.Rentals.SingleOrDefault(x => x.Id == id);
            return View(rent);
        }

        [HttpPost]
        public ActionResult Create(RentalFurnitureViewModel multipleRentalPropose)
        {


            //Rental rental = new Rental()
            //{
            //    Name = multipleRentalPropose.Rental.Name,
            //    FurnitureId = multipleRentalPropose.Furniture.Id
            //};
            //_context.Rentals.Add(rental);

            //_context.Rentals.AddRange()
            _context.customers.Add(multipleRentalPropose.Customer);

            List<Rental> rentals = new List<Rental>();
            for (int i = 0; i < multipleRentalPropose.Furnitures.Count; i++)
            {
                Rental rental = new Rental() {Name = multipleRentalPropose.Rental.Name,  FurnitureId = multipleRentalPropose.Furnitures[i].Id };
                var tempId = multipleRentalPropose.Furnitures[i].Id;
                var furniture = _context.Furnitures.Single(m => m.Id == tempId);
                furniture.IsRented = multipleRentalPropose.Furnitures[i].IsRented;
               // _context.Furnitures.Add(furniture);
                rentals.Add(rental);
            }

            try
            {
                //_context.Furnitures.AddRange(multipleRentalPropose.Furnitures);

                _context.Rentals.AddRange(rentals);
                _context.SaveChanges();
                 TempData["message"] = "Your Rental Successfully record";

                 return RedirectToAction("Index", "Rentals");
            }
            catch (Exception e)
            {

                throw;
            }
           

           
           
        }

        public ActionResult Update(Rental rental)
        {

            var dbRental = _context.Rentals.Single(m => m.Id == rental.Id);
            dbRental.Name = rental.Name;
            _context.SaveChanges();
            TempData["message"] = "Update Rental Successfully";
            return RedirectToAction("AdminIndex", "rentals");
            
        }

        public ActionResult DashboadRental()
        {
            return View();
        }
    }
}