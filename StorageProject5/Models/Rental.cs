using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StorageProject5.Models
{
    public class Rental
    {
        public int Id { get; set; }

        public int Name { get; set; }

        public int FurnitureId { get; set; }
        public Furniture Furniture { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public virtual ICollection<Furniture> Furnitures { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}