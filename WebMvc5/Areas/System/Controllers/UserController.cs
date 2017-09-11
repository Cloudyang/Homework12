using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMvc5.Areas.System.Controllers
{
    public class UserController : Controller
    {
        // GET: System/User
        public ActionResult Index()
        {
            return View();
        }

        // GET: System/User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: System/User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: System/User/Create
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

        // GET: System/User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: System/User/Edit/5
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

        // GET: System/User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: System/User/Delete/5
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
