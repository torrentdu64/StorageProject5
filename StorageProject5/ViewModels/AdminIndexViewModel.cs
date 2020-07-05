using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StorageProject5.Models;

namespace StorageProject5.ViewModels
{
    public class AdminIndexViewModel
    {
        public int id { get; set; }
        public string cusrtomerName { get; set; }
        public string rentalName { get; set; }
        public List<Furniture> Furnitures = new List<Furniture>();
    }
}