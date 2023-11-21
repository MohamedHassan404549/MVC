using Microsoft.AspNetCore.Mvc;
using MVCBIG.Models;

namespace MVCBIG.Controllers
{
    public class DepartmentController : Controller
    {
        CampanyContext db = new CampanyContext();
        public IActionResult Index()
        {
            List<Department> DepartmentList = db.Departments.ToList();
            return View(DepartmentList);

        }


        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveNew(Department dept)
        {
            if (dept.DName != null)
            {
                db.Add(dept);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("New", dept);
        }

        public IActionResult Update(int id)
        {
            var dept = db.Departments.FirstOrDefault(d => d.Dnumber == id);
            if (dept == null)
            {
                return RedirectToAction("Index");
            }

            return View(dept);
        }

        [HttpPost]
        public IActionResult SaveUpdate(Department dept)
        {
            if (ModelState.IsValid)
            {
                db.Update(dept); // Update the department in the database
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            // If the model is not valid, return to the "Update" view with validation errors
            return View("Update", dept);
        }
        public IActionResult GetById(int id)
        {
            var dept = db.Departments.FirstOrDefault(d => d.Dnumber == id);

            return View(dept);

        }
        public IActionResult Delete(int id)
        {
            var dept = db.Departments.FirstOrDefault(d => d.Dnumber == id);
            db.Remove(dept);
            db.SaveChanges();

            return RedirectToAction("Index");

        }



    }
}
