using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Floral_WebApp.Models;
namespace Floral_WebApp.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
        public ActionResult Gallery()
        {
            return View();
        }

        public ActionResult Occasion()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(Contact c)
        {
           

            if (ModelState.IsValid==true)
            {
                db.Contactss.Add(c);
                int a = db.SaveChanges();
                if(a > 0) { 
                ViewBag.message = "<script>alert('Thankyou For Contacting')</script>";
                ModelState.Clear();
                }
                else
                {
                    ViewBag.message = "<script>alert('Invalid Data')</script>";
                    return View();


                }

            }
            

                return View();
            
        }

        public ActionResult Login()
        {

            return View();
        }

    }
}