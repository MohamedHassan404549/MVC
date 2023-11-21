using Microsoft.AspNetCore.Mvc;
using MVCBIG.Models;

namespace MVCBIG.Controllers
{
    public class ProjectController : Controller
    {
        CampanyContext db = new CampanyContext();
        public IActionResult Index()
        {
            List<Project> Projectlist = db.Projects.ToList();
            return View(Projectlist);

        }


        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveNew(Project Pro)
        {
            if (Pro.PNumber != null)
            {
                db.Add(Pro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("New", Pro);
        }

        public IActionResult Update(int id)
        {
            var Pro = db.Projects.FirstOrDefault(d => d.PNumber == id);
            if (Pro == null)
            {
                return RedirectToAction("Index");
            }

            return View(Pro);
        }

        [HttpPost]
        public IActionResult SaveUpdate(Project Pro)
        {
            if (ModelState.IsValid)
            {
                db.Update(Pro); // Update the Project in the database
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            // If the model is not valid, return to the "Update" view with validation errors
            return View("Update", Pro);
        }
        public IActionResult GetById(int id)
        {
            var Pro = db.Projects.FirstOrDefault(d => d.PNumber == id);

            return View(Pro);

        }
        public IActionResult Delete(int id)
        {
            var Pro = db.Projects.FirstOrDefault(d => d.PNumber == id);
            db.Remove(Pro);
            db.SaveChanges();

            return RedirectToAction("Index");

        }



    }
}