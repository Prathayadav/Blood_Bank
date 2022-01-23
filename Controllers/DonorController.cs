using BloodDoner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloodDoner.Controllers
{
    public class DonorController : Controller
    {
        // GET: Donor
        
        public ActionResult Index()
        {
            if (Session["login"] == null)
                return RedirectToAction("Login", "Emp");
            else
            {
                List<Donor> donorlist = new DonorDBHandler().getlistofdonor();
                return View(donorlist);
            }
        }

        // GET: Donor/Details/5
        public ActionResult Details(int id)
        {
            if (Session["login"] == null)
                return RedirectToAction("Login", "Emp");
            else
            {
                Donor d = new DonorDBHandler().viewEdit(id);
                return View(d);
            }
        }

        // GET: Donor/Create
        public ActionResult Create()
        {
            if (Session["login"] == null)
                return RedirectToAction("Login", "Emp");
            else
            {
                return View();
            }
        }

        // POST: Donor/Create
        [HttpPost]
        public ActionResult Create(Donor d)
        {
            if (Session["login"] == null)
                return RedirectToAction("Login", "Emp");
            else
            {
                // TODO: Add insert logic here
                d.Created_Emp = Convert.ToString(Session["empname"]);
                new DonorDBHandler().createDonor(d);
                return RedirectToAction("Index");
            }
           
        }

        // GET: Donor/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["login"] == null)
                return RedirectToAction("Login", "Emp");
            else
            {
                Donor d = new DonorDBHandler().viewEdit(id);
                ViewBag.emp = d.Created_Emp;

                ViewBag.id = d.Id;

                return View(d);
            }
        }

        // POST: Donor/Edit/5
        [HttpPost]
        public ActionResult Edit(Donor d)
        {
            if (Session["login"] == null)
                return RedirectToAction("Login", "Emp");
            else
            {
                d.Created_Emp = Convert.ToString(Session["empname"]);
                new DonorDBHandler().editpost(d);

                return RedirectToAction("Index");
            }
                
            
        }

        // GET: Donor/Delete/5
        public ActionResult Delete(int id)
        {
            if (Session["login"] == null)
                return RedirectToAction("Login", "Emp");
            else
            {
                Donor d = new DonorDBHandler().viewEdit(id);
                ViewBag.emp = d.Created_Emp;

                ViewBag.id = d.Id;

                return View(d);
            }
        }

        // POST: Donor/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (Session["login"] == null)
                return RedirectToAction("Login", "Emp");
            else
            {
                // TODO: Add delete logic here
                new DonorDBHandler().deletedonor(id);
                return RedirectToAction("Index");
            }
            
        }
        public ActionResult SearchBlood()
        {
            if (Session["login"] == null)
                return RedirectToAction("Login", "Emp");
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult SearchBlood(Blood b)
        {
            if (Session["login"] == null)
                return RedirectToAction("Login", "Emp");
            else
            {
                Session["b2"] = b;
                return RedirectToAction("BloodList");
            }
        }
        public ActionResult BloodList(Blood b)
        {
            if (Session["login"] == null)
                return RedirectToAction("Login","Emp");
            else
            {
                List<Donor> d = null;
                d = new DonorDBHandler().displayblood(Session["b2"] as Blood);
                if (d == null)

                    return RedirectToAction("Msg");
                else return View(d);
            }
          
        }




    }
}
