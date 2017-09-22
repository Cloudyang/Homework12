using Bussiness.IService;
using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Model;

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
            return View();
        }

        public JsonResult GetMenuTreeGrid()
        {
            var treeResult = _MenuService.GetMenuTreeGrid();
            return Json(treeResult, JsonRequestBehavior.AllowGet);
        }

        // POST: System/User/Create
        [HttpPost]
        public string Create(int parentId)
        {
            string SourcePath = string.Empty;
            if (parentId != 0)
            {
                SourcePath = _MenuService.Find(parentId)?.SourcePath;
            }
            var menu = new Menu()
            {
                CreatorId = 1,
                Name = "new",
                ParentId = parentId,
                SourcePath = SourcePath+"/",
                Sort = 100,
                MenuLevel = 1,
                Url = string.Empty,
                State = 1,
                Description=string.Empty
            };
            menu.CreateTime = DateTime.Now;
            int iResult = 0;

            iResult = _MenuService.AddMenuReturnId(menu);

            return iResult.ToString();
        }

        // POST: System/User/Edit/5
        [HttpPost]
        public string Edit(MenuView m)
        {
            var menu = new Menu()
            {
                CreatorId = 1,
                Description = m.Description,
                Id = m.Id,
                Name = m.Name,
                ParentId = m.ParentId,
                Url = m.Url,
                SourcePath = m.SourcePath,
                Sort = m.Sort,
                State = m.State
            };

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
        public string Delete(int Id)
        {
            int iResult = 0;
            try
            {
                iResult = _MenuService.Delete(Id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return iResult.ToString();
        }
    }
}
