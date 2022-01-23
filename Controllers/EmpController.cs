using BloodDoner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloodDoner.Controllers
{
    public class EmpController : Controller
    {
        // GET: Emp
       
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Employee e)
        {
           
           
            bool check=new EmpDBHandler().loginValidation(e);
            if (check)
            {
                Session["empname"] = e.Email;
                Session["login"] = true ;
                return RedirectToAction("Home");
            }
            else
            {
                ViewBag.c = "Something went Wrong";
                return View();
            }
        }
        
        public ActionResult Home()
        {

            if (Session["login"] == null)
            return RedirectToAction("Login");
                return View();
        }
        public ActionResult Logout()
        {
            Session["login"] = null;
            return RedirectToAction("Login");
        }
        public ActionResult Admin()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult Admin(Admin a)
        {
            if (a.Email == "admin@gmail.com" && a.Password == "admin")
            {
                Session["loginemp"] = true;
                return RedirectToAction("HomeAdmin");
            }
            else
            {
                ViewBag.check2 = "Something went Wrong";
                return View();
            }

        }
        public ActionResult HomeAdmin()
        {
            if (Session["loginemp"] == null)
                return RedirectToAction("Admin");
            else
            {
                return View(new EmpDBHandler().emplist());
            }
        }
        public ActionResult CreateEmp()
        {
            if (Session["loginemp"] == null)
                return RedirectToAction("Admin");
            else
            {
                return View();
            }
        }
        
        [HttpPost]
        public ActionResult CreateEmp(Admin a)
        {
            if (Session["loginemp"] == null)
                return RedirectToAction("Admin");
            else
            {
                new EmpDBHandler().createemp(a);
                return RedirectToAction("HomeAdmin", "Emp");
            }
        }
        [HttpGet]
        public ActionResult EmpDelete(string s)
        {
            if (Session["loginemp"] == null)
                return RedirectToAction("Admin");
            else
            {
                new EmpDBHandler().deleteemp(s);
                return RedirectToAction("HomeAdmin");
            }
           
        }
        public ActionResult LogoutEmp()
        {
            Session["loginemp"] = null;
            return RedirectToAction("Admin");
        }
       
       
    }
}

//  <li> @Html.DropDownList("bloodgroup", new SelectList(new List<String>() { "O+", "A+", "B+", "B-", "A-", "AB+", "AB-" })) </li>