using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bussiness.IService;
using Entity.Model;

namespace WebMvc5.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryService _CategoryServcie;
        public CategoryController(ICategoryService categoryService)
        {
            _CategoryServcie = categoryService;
        }

        // GET: Category
        public ActionResult Index()
        {
            IQueryable<Category> categorys = _CategoryServcie.Set();
            return View(categorys);
        }
        
    }
}
