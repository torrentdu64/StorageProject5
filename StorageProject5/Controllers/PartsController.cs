using StorageProject5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StorageProject5.ViewModels;

namespace StorageProject5.Controllers
{
    public class PartsController : Controller
    {

        private ApplicationDbContext _context;
        public PartsController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
        // GET: Parts
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FourniturePartViewModel four)
        {


            var fourniture = _context.Furnitures.SingleOrDefault(m => m.Id == four.Furniture.Id);
            var partName = Request.Params["Part.Name[]"];
            var productNameList = partName.Split(',').ToList();
            
            List<Part> partList = new List<Part>();
            foreach (var item in productNameList)
            {
                var part = new Part();
                part.Name = item;
                partList.Add(part);
            }

            try
            {

                
                for (int i = 0; i < partList.Count; i++)
                {
                    var part = _context.Parts.Add(partList[i]);
                    _context.Furnitures.Add(fourniture);
                   
                                     
                }
                //_context.Furnitures.Add(fourniture);

                _context.SaveChanges();

                return RedirectToAction("AdminListFurniture", "Furnitures");
            }
            catch (Exception e)
            {
                return View();
            }


            //_context.Parts.Add(part);
            //_context.SaveChanges();
           
        }
    }
}