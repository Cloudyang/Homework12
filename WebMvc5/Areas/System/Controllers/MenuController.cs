using Bussiness.IService;
using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMvc5.Areas.System.Controllers
{
    public class MenuController : Controller
    {
        private IMenuService _MenuService;
        public MenuController(IMenuService menuService)
        {
            _MenuService = menuService;
        }

        // GET: System/User
        public ActionResult Index()
        {
            var users = _MenuService.Set();
            ViewBag.Users = Newtonsoft.Json.JsonConvert.SerializeObject(users);
            return View();
        }

        // POST: System/User/Create
        [HttpPost]
        public string Create(Menu menu)
        {
            menu.CreateTime = DateTime.Now;
            int iResult = 0;
            try
            {
                iResult = _MenuService.Insert(menu);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return iResult.ToString();
        }

        // POST: System/User/Edit/5
        [HttpPost]
        public string Edit(Menu menu)
        {
            menu.CreateTime = DateTime.Now;
            int iResult = 0;
            try
            {
                iResult = _MenuService.Update(menu);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return iResult.ToString();
        }

        [HttpPost]
        public string Delete(Menu menu)
        {
            int iResult = 0;
            try
            {
                iResult = _MenuService.Delete(menu);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return iResult.ToString();
        }
    }
}
