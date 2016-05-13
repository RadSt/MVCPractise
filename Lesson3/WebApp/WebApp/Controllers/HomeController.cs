using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using WebApp.Models;
using WebApp.Models.Abstract;
using WebApp.Models.Concrete;
using WebApp.Models.Enteties;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private IUserManager _userManager;
        public HomeController(IUserManager userManager)
        {
            _userManager = userManager;
        }
        public ActionResult Index()
        {
            _userManager.Save(new User
            {
                Name = "Radik",
                Password = "123",
                Email = "rrr@mail.ru",
                Roles = new List<Role>
                {
                    new Role
                    {
                        Code = "Manager",
                        Name = "Менеджер"
                    }
                }
            });
            return View();
        }
    }
}