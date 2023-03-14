using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Floral_WebApp.Models;

namespace Floral_WebApp.Controllers
{
    public class AdminController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
      

        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]

        public ActionResult AddUser(Register r)
        {
            if (ModelState.IsValid == true)
            {
                r.Role = "User";
                db.Registers.Add(r);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    ViewBag.message = "<script>alert('Registered Successfully !')</script>";
                    ModelState.Clear();
                    return View();
                }

            }
            else
            {
                ViewBag.message = "<script>alert('Registration Failed !')</script>";
                return View();

            }
            return View();

        }
    }
}