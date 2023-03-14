using Floral_WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Floral_WebApp.Controllers
{
    public class RegisterController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Register
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Login(Login l)
        {
            var Credentials = db.Registers.Where(model => model.Email.Equals( l.U_Name) && model.Password .Equals( l.U_Password)).SingleOrDefault();

            if (Credentials != null)
            {

                if (Credentials.Role.Contains("Admin"))
                {
                    Session["Username"] = Credentials.Name.ToString();
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    if (Credentials !=null)
                    {
                        Session["Username"] = Credentials.Name.ToString();
                        TempData["message"] = "<script>alert('Login Successfully !')</script>";
                        return RedirectToAction("Index", "Home");


                    }

                    else
                    {
                        ViewBag.error = "<script>alert('UserEmail or UserPassword is incorrect !')</script>";
                        return View();
                    }
                }
            }


            else
            {
                return View();
              
            }
                

        }
    
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Register");
        }

        public ActionResult register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult register(Register r)
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