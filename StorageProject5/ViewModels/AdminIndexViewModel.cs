using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StorageProject5.Models;

namespace StorageProject5.ViewModels
{
    public class AdminIndexViewModel
    {
        public int rentalId { get; set; }
        public List<Rental> Rentals = new List<Rental>();
        public int customerId { get; set; }
        public string customerName { get; set; }
        public int rentalName { get; set; }
        public List<Furniture> Furnitures = new List<Furniture>();
    }
}