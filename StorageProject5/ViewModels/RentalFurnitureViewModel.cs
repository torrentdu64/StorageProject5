using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StorageProject5.Models;

namespace StorageProject5.ViewModels
{
    public class RentalFurnitureViewModel
    {
        public Furniture Furniture { get; set; }
        public Rental Rental { get; set; }

        public List<Furniture> Furnitures { get; set; }
        public List<Rental> Rentals { get; set; }

        public List<Furniture> availableFurnitures { get; set; }

        public List<Furniture> OrdersThisWeek { get; set; } = new List<Furniture>();

        public Customer Customer { get; set; }

        public List<Customer> customers { get; set; }
    }
}