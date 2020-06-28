using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StorageProject5.Models;

namespace StorageProject5.ViewModels
{
    public class FourniturePartViewModel
    {
        public  Furniture Furniture { get; set; }
        public Part Part { get; set; }

        public List<Furniture> Furnitures { get; set; }
        public List<Part> Parts { get; set; }
        public List<Part> Locations { get; set; }
    }
}