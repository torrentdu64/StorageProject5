using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StorageProject5.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public List<Part> parts { get; set; }
    }
}