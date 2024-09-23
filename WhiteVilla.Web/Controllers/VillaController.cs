using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection.Metadata.Ecma335;
using WhiteVilla.Domain.Entities;
using WhiteVilla.Infrastructure.Data;

namespace WhiteVilla.Web.Controllers
{
    public class VillaController : Controller
    {
        private readonly ApplicationDbContext _db;

        public VillaController(ApplicationDbContext db)
        {
            _db = db;
            
        }
        public IActionResult Index()
        {
            var villas = _db.Villas.ToList();
            return View(villas);

        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Villa obj)
        {
            if(obj.Name==obj.Description)
            {
                ModelState.AddModelError("name","The Description Exactly cannot be matched");
            }
            if (ModelState.IsValid)
            {
                _db.Villas.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Successfully Created";

                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Update(int villaId)
        {
            Villa? obj = _db.Villas.FirstOrDefault(u=>u.Id==villaId);
            if(obj==null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(obj);
        }
        [HttpPost]
        public IActionResult Update(Villa obj)
        {
           
            if (ModelState.IsValid && obj.Id>0)
            {
                _db.Villas.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Successfully Updated";

                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int villaId)
        {
            Villa? obj = _db.Villas.FirstOrDefault(u => u.Id == villaId);
            if (obj is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(obj);
        }
        [HttpPost]
        public IActionResult Delete(Villa obj)
        {
            Villa? objFromDb = _db.Villas.FirstOrDefault(u => u.Id == obj.Id);

            if (objFromDb is not null)
            {
                _db.Villas.Remove(objFromDb);
                _db.SaveChanges();
                TempData["success"] = "Successfully Deleted";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Can't Be Deleted";

            return View();
        }

    }
}
