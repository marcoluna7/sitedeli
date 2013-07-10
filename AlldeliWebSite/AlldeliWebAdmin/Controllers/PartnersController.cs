using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Alldeli.BusinessLogic.DbLayer;
using Alldeli.BusinessLogic.Models;

namespace AlldeliWebAdmin.Controllers
{
    public class PartnersController : Controller
    {
        //
        // GET: /Partners/

        public ActionResult Index()
        {
            List<Partner> listaPartner = new List<Partner>();
            using (AccessDataBase acceso = new AccessDataBase())
            {
                listaPartner = acceso.GetPartners(0);
            }            
            return View(listaPartner);
        }

        //
        // GET: /Partners/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Partners/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Partners/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Partners/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Partners/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Partners/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Partners/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
