
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
            _context.SaveChanges();
            var partName = Request.Params["Part.Name[]"];
            var productNameList = partName.Split(',').ToList();

            //var ObjFourniture = new Furniture(fourniture);


            List<Part> partList = new List<Part>();
            foreach (var item in productNameList)
            {
                var part = new Part();
                part.Name = item;
                part.FurnitureId = fun.Id;
                partList.Add(part);
            }



            try
            {
                
               _context.Parts.AddRange(partList);

                //for (int i = 0; i < partList.Count; i++)
                //{
                //     //_context.Parts.Add(partList[i]);

                   
                  
                                     
                //}
                //_context.Furnitures.Add(fourniture);
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

        public ActionResult Edit(int id)
        {


            var part = _context.Parts.SingleOrDefault(m => m.Id == id);
            if (part == null)
                return HttpNotFound();

            return View(part);
        }

        [HttpPost]
        public ActionResult Update(Part part)
        {
            var dbPart = _context.Parts.Single(m => m.Id == part.Id);
            dbPart.Name = part.Name;
            _context.SaveChanges();
            TempData["message"] = "Update Successfully";
            return RedirectToAction("AdminListFurniture", "Furnitures");
        }
    }
}