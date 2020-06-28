using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StorageProject5.Models
{
    public class Part
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Fourniture")]
        public int FurnitureId { get; set; }
        public Furniture Fourniture { get; set; }
        public Location Location { get; set; }
        public int LocationId { get; set; }
    }
}