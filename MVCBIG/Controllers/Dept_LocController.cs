using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCBIG.Models;

namespace MVCBIG.Controllers
{
    public class Dept_LocController : Controller
    {
        CampanyContext db = new CampanyContext();

        public IActionResult Index()
        {
            List<Dept_Loc> Dept_LocsList = db.Dept_Locs.ToList();
            return View(Dept_LocsList);
        }
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveNew(Dept_Loc loc)
        {
            if (loc.Dnumber != null)
            {
                db.Add(loc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("New", loc);
        }

        public IActionResult Update(int id)
        {
            var loc = db.Dept_Locs.FirstOrDefault(d => d.Dnumber == id);
            if (loc == null)
            {
                return RedirectToAction("Index");
            }

            return View(loc);
        }

        [HttpPost]
        public IActionResult SaveUpdate(Dept_Loc loc)
        {
            if (ModelState.IsValid)
            {
                db.Update(loc); // Update the Dept_Loc in the database
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            // If the model is not valid, return to the "Update" view with validation errors
            return View("Update", loc);
        }
        public IActionResult GetById(int id)
        {
            var loc = db.Dept_Locs.FirstOrDefault(d => d.Dnumber == id);

            return View(loc);

        }
        public IActionResult Delete(int id)
        {
            var loc = db.Dept_Locs.FirstOrDefault(d => d.Dnumber == id);
            db.Remove(loc);
            db.SaveChanges();

            return RedirectToAction("Index");

        }



    }
}

