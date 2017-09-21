using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bussiness.IService;
using Entity.Model;

namespace WebMvc5.Areas.System.Controllers
{
    public class UserController : Controller
    {
        private IUserService _UserService;
        public UserController(IUserService userService)
        {
            _UserService = userService;
        }

        // GET: System/User
        public ActionResult Index()
        {
            var users = _UserService.Set();
            ViewBag.Users = Newtonsoft.Json.JsonConvert.SerializeObject(users);
            return View();
        }

        // POST: System/User/Create
        [HttpPost]
        public string Create(User user)
        {
            user.CreateTime = DateTime.Now;
            int iResult = 0;
            try
            {
                iResult = _UserService.AddUserReturnId(user);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return iResult.ToString();
        }

        // POST: System/User/Edit/5
        [HttpPost]
        public string Edit(User user)
        {
            user.CreateTime = DateTime.Now;
            int iResult = 0;
            try
            {
                iResult = _UserService.Update(user);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return iResult.ToString();
        }

        [HttpPost]
        public string Delete(User user)
        {
            int iResult = 0;
            try
            {
                iResult = _UserService.Delete(user);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return iResult.ToString();
        }
    }
}
