using Microsoft.AspNetCore.Mvc;
using MVCBIG.Models;
using System.Runtime.Intrinsics.Arm;

namespace MVCBIG.Controllers
{
    public class DepandentController : Controller
    {
        CampanyContext db = new CampanyContext();
        public IActionResult Index()
        {
            List<Depandent> depandentslist = db.Depandents.ToList();
            return View(depandentslist);

        }


        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveNew(Depandent Dep)
        {
            if (Dep.ESSN != null)
            {
                db.Add(Dep);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("New", Dep);
        }

        public IActionResult Update(int id)
        {
            var Dep = db.Depandents.FirstOrDefault(d => d.ESSN == id);
            if (Dep == null)
            {
                return RedirectToAction("Index");
            }

            return View(Dep);
        }

        [HttpPost]
        public IActionResult SaveUpdate(Depandent Dep)
        {
            if (ModelState.IsValid)
            {
                db.Update(Dep); // Update the Depandent in the database
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            // If the model is not valid, return to the "Update" view with validation errors
            return View("Update", Dep);
        }
        public IActionResult GetById(int id)
        {
            var Dep = db.Depandents.FirstOrDefault(d => d.ESSN == id);

            return View(Dep);

        }
        public IActionResult Delete(int id)
        {
            var Dep = db.Depandents.FirstOrDefault(d => d.ESSN == id);
            db.Remove(Dep);
            db.SaveChanges();

            return RedirectToAction("Index");

        }



    }
}
