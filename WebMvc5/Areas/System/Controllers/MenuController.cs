using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMvc5.Areas.System.Controllers
{
    public class MenuController : Controller
    {
        // GET: System/Menu
        public ActionResult Index()
        {
            return View();
        }

        // GET: System/Menu/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: System/Menu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: System/Menu/Create
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

        // GET: System/Menu/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: System/Menu/Edit/5
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

        // GET: System/Menu/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: System/Menu/Delete/5
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
