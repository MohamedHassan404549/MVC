using Microsoft.AspNetCore.Mvc;
using MVCBIG.Models;

namespace MVCBIG.Controllers
{
    public class EmployeeController : Controller
    {
            CampanyContext db = new CampanyContext();
            public IActionResult Index()
            {
                List<Employee> Employeeslist = db.Employees.ToList();
                return View(Employeeslist);

            }


            public IActionResult New()
            {
                return View();
            }

            [HttpPost]
            public IActionResult SaveNew(Employee emp)
            {
                if (emp.FullName != null)
                {
                    db.Add(emp);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View("New", emp);
            }

            public IActionResult Update(int id)
            {
                var emp = db.Employees.FirstOrDefault(d => d.SSN == id);
                if (emp == null)
                {
                    return RedirectToAction("Index");
                }

                return View(emp);
            }

            [HttpPost]
            public IActionResult SaveUpdate(Employee emp)
            {
                if (ModelState.IsValid)
                {
                    db.Update(emp); // Update the employee in the database
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                // If the model is not valid, return to the "Update" view with validation errors
                return View("Update", emp);
            }
            public IActionResult GetById(int id)
            {
                var emp = db.Employees.FirstOrDefault(d => d.SSN == id);

                return View(emp);

            }
            public IActionResult Delete(int id)
            {
                var emp = db.Employees.FirstOrDefault(d => d.SSN == id);
                db.Remove(emp);
                db.SaveChanges();

                return RedirectToAction("Index");

            }


        }
    }
