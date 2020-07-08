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
        private List<Furniture> furnitures = new List<Furniture>();
        private Rental rental;
        private Customer customer;
        private AdminIndexViewModel aRental;
        private ListOfAminIndex rentalsList;
        private int tempId2;
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
            //var availableFurnitures = _context.Furnitures.Where(x => !currentRentals.Contains(x.Id) ).ToList();

            var availableFurnitures = _context.Furnitures.Where(x => x.IsRented == false ).ToList();

            RentalFurnitureViewModel viewModel = new RentalFurnitureViewModel()
            {
                availableFurnitures = availableFurnitures
            };

            return View(viewModel);
        }

        public ActionResult AdminIndex()
        {
            //var rentalList = _context.Rentals.ToList();
            //List<Furniture> furnitures = new List<Furniture>();
            //for (int i = 0; i < rentalList.Count; i++)
            //{
            //    var tempid = rentalList[i].CustomerId;
            //    var test = _context.Rentals.Where(r => r.CustomerId == tempid).Select(r => r.FurnitureId).ToList();
            //}

            //for (int i = 0; i < rentalList.Count; i++)
            //{
            //    var idLoop = rentalList[i].FurnitureId;
            //    var furniture = _context.Furnitures.Single(f => f.Id == idLoop);
            //    furnitures.Add(furniture);
            //}


            //var customers = _context.customers.ToList();
            //var rentCount = _context.Rentals.GroupBy(x => x.CustomerId).ToList();

            //List<Rental> rentals = new List<Rental>();
            //for (int i = 0; i < rentCount.Count; i++)
            //{
            //    var customerIdLoop = customers[i].Id;
            //    Rental rental = new Rental();
            //    var test = _context.Rentals.Single(r => r.CustomerId == customerIdLoop);

            //    var temp = _context.Rentals.Where(x => x.CustomerId == customerIdLoop).ToList();


            //    //rental.furnituresFromRental = temp;
            //    //rental.furnituresFromRental = 

            //    rentals.Add(rental);
            //}

            ////List<Furniture> furnitures = new List<Furniture>();
            //for (int i = 0; i < rentals.Count; i++)
            //{
            //   //var furnitureCount = _context.Furnitures.Where( x => x.)
            //    var furnitureIdLoop = rentals[i].FurnitureId;
            //    Furniture furniture = new Furniture();
            //    furniture = _context.Furnitures.FirstOrDefault(x => x.Id == furnitureIdLoop);
            //    furnitures.Add(furniture);
            //}

            ////var furnitures = _context.Furnitures.ToList();
            ////var currentRentals = _context.Rentals.Select(x => x.FurnitureId).ToList();



            //var availableFurnitures = _context.Furnitures.Where(x => !currentRentals.Contains(x.Id)).ToList();

            var rentals = _context.Rentals.ToList();
            var customerRent = _context.Rentals
                                            .GroupBy(u => u.CustomerId)
                                             .Select(grp => grp.ToList())
                                            .ToList();

            rentalsList = new ListOfAminIndex();
            for (int i = 0; i < customerRent[0].ToList().Count; i++)
            {
                rental = new Rental();
                rental.Id = customerRent[0][i].Id;
                rental.Name = customerRent[0][i].Name;
                rental.FurnitureId = customerRent[0][i].FurnitureId;
                rental.CustomerId = customerRent[0][i].CustomerId;
                rentals.Add(rental);
            } 


            
            
            for (int i = 0; i < customerRent.Count; i++)
            {
                aRental = new AdminIndexViewModel();
                var customerHave = customerRent[i].ToList();
                
                foreach (var item in customerHave)
                {
                    tempId2 = item.CustomerId;
                    
                }
                //var tempId = customerHave[i].CustomerId;
                var dbCustomer = _context.customers.Single(c => c.Id == tempId2);
                aRental.customerName = dbCustomer.Name;
                aRental.customerId = dbCustomer.Id;
                aRental.rentalName = customerHave[0].Name;
                customer = new Customer() { Id = dbCustomer.Id, Name = dbCustomer.Name };

                for (int y = 0; y < customerHave.Count; y++)
                {
                    var tempId2 = customerHave[y].FurnitureId;

                    var dbFurniture = _context.Furnitures.Single(f => f.Id == tempId2);
                   
                    Furniture furniture = new Furniture()
                    {
                        Id = dbFurniture.Id,
                        Name = dbFurniture.Name,
                        IsRented = dbFurniture.IsRented
                    };
                    aRental.Furnitures.Add(furniture);
                    furnitures.Add(furniture);

                }
                rentalsList.rentals.Add(aRental);
                
            }

            var furnitureIDs = _context.Rentals.Select(x => x.FurnitureId).ToList();

            //for (int i = 0; i < rents.Count; i++)
            //{
            //    var listOfRentals = rents[i].ToList();
            //    var customerId = listOfRentals[i];
            //    var furnitureId = listOfRentals[i];

            //}
            //var customers = _context.Rentals.Where(r = ).ToList();

            RentalFurnitureViewModel viewModel = new RentalFurnitureViewModel()
            {
              Furnitures = furnitures,
              Customer = customer,
              Rentals = rentals

            };


            return View(rentalsList);
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
            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

            var rental = new Rental() {
                Name = unixTimestamp
            };
            var customer = new Customer();

            RentalFurnitureViewModel viewModel = new RentalFurnitureViewModel()
            {
                Furnitures = furnitures,
                Rental = rental,
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
            _context.customers.Add(multipleRentalPropose.Customer);

            List<Rental> rentals = new List<Rental>();
            for (int i = 0; i < multipleRentalPropose.Furnitures.Count; i++)
            {
                Rental rental = new Rental() {Name = multipleRentalPropose.Rental.Name,  FurnitureId = multipleRentalPropose.Furnitures[i].Id };
                var tempId = multipleRentalPropose.Furnitures[i].Id;
                var furniture = _context.Furnitures.Single(m => m.Id == tempId);
                furniture.IsRented = multipleRentalPropose.Furnitures[i].IsRented;
               
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