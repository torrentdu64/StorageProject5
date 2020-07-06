using StorageProject5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StorageProject5.ViewModels
{
    public class RenderFurnitureViewModel
    {
        public int FurnitureId { get; set; }
        public string Name { get; set; }
        public bool IsRented { get; set; }

        public int  CodeName { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}