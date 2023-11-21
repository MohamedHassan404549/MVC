using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MVCBIG.Models;
using System.Data.SqlClient;

namespace MVCBIG.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        [HttpGet]
     
        public IActionResult Login()
        {
            return View();
        }

        void connectionString()
        {
            con.ConnectionString = "Data Source=.; Initial Catalog=BIG_COMPANY; Integrated Security=True; Encrypt=False;";
        }

        [HttpPost]
        public IActionResult Verify(Account acc)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from Login where Username='" + acc.Name + "' and Password='" + acc.Password + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                // Redirect to "Home/Index1" if login is successful
                return RedirectToAction("Index", "Home") ;
            }
            else
            {
                con.Close();
                return View("Error");
            }
        }
    }
}
