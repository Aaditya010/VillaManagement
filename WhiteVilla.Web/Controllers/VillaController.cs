using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection.Metadata.Ecma335;
using WhiteVilla.Application.Common.Interfaces;
using WhiteVilla.Domain.Entities;
using WhiteVilla.Infrastructure.Data;

namespace WhiteVilla.Web.Controllers
{
    public class VillaController : Controller
    {
        private readonly IVillaRepository _villaRepo;

        public VillaController(IVillaRepository villaRepo)
        {
            _villaRepo = villaRepo;
            
        }
        public IActionResult Index()
        {
            var villas = _villaRepo.GetAll();
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
                _villaRepo.Add(obj);
                _villaRepo.Save();
                TempData["success"] = "Successfully Created";

                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Update(int villaId)
        {
            Villa? obj = _villaRepo.Get(u=>u.Id==villaId);
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
                _villaRepo.Update(obj);
                _villaRepo.Save();
                TempData["success"] = "Successfully Updated";

                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public IActionResult Delete(int villaId)
        {
            Villa? obj = _villaRepo.Get(u => u.Id == villaId);
            if (obj is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(obj);
        }
        [HttpPost]
        public IActionResult Delete(Villa obj)
        {
            Villa? objFromDb = _villaRepo.Get(u => u.Id == obj.Id);

            if (objFromDb is not null)
            {
                _villaRepo.Remove(objFromDb);
                _villaRepo.Save();
                TempData["success"] = "Successfully Deleted";
                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = "Can't Be Deleted";

            return View();
        }

    }
}
