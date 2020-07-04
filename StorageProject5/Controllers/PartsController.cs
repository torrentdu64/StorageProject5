
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StorageProject5.ViewModels;
using System.Data.Entity;
using StorageProject5.Models;

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
        public ActionResult Create(FourniturePartViewModel fourniture)
        {


            var fun =_context.Furnitures.SingleOrDefault(m => m.Id == fourniture.Furniture.Id);
            //_context.SaveChanges();
            var partName = Request.Params["Part.Name[]"];
            var partNameList = partName.Split(',').ToList();

            var locationAddress = Request.Params["Location.Address[]"];

            // need to change comas too dangerous to use for a Address !!!!!
            var locationAddressList = locationAddress.Split(',').ToList();

            //var ObjFourniture = new Furniture(fourniture);


            List<Location> locationList = new List<Location>();
            foreach (var item in locationAddressList)
            {
                var location = new Location();
                location.Address = item;
                //location.FurnitureId = fun.Id;

                locationList.Add(location);
                
            }

            _context.locations.AddRange(locationList);
            _context.SaveChanges();


            List<Part> partList = new List<Part>();
            //foreach (var item in partNameList)
            //{
            //    var part = new Part();
            //    part.Name = item;
            //    part.LocationId = locationList[],
            //    part.FurnitureId = fun.Id;
            //    partList.Add(part);
                
            //}
            for (int i = 0; i < locationList.Count; i++)
            {
                var part = new Part();
                part.Name = partNameList[i];
                part.LocationId = locationList[i].Id;
                part.FurnitureId = fun.Id;
                partList.Add(part);
            }




            try
            {


               // _context.locations.AddRange(locationList);
               

                _context.Parts.AddRange(partList);


                _context.SaveChanges();




                //for (int i = 0; i < partList.Count; i++)
                //{
                //     //_context.Parts.Add(partList[i]);




                //}
                //_context.Furnitures.Add(fourniture);
                //_context.Furnitures.Add(fourniture);




                return RedirectToAction("AdminListFurniture", "Furnitures");
            }
            catch (Exception e)
            {
                return View();
            }


            //_context.Parts.Add(part);
            //_context.SaveChanges();
           
        }

        public ActionResult Edit(int id)
        {


            var part = _context.Parts.Include(m => m.Location).SingleOrDefault(m => m.Id == id);
            if (part == null)
                return HttpNotFound();

            return View(part);
        }

        [HttpPost]
        public ActionResult Update(Part part)
        {
            var dbPart = _context.Parts.Single(m => m.Id == part.Id);
            dbPart.Name = part.Name;
            dbPart.Location = part.Location;
            _context.SaveChanges();
            TempData["message"] = "Update Successfully";
            return RedirectToAction("AdminListFurniture", "Furnitures");
        }
    }
}