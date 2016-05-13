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
        private IRolesManager _rolesManager;
        public HomeController(IRolesManager rolesManager)
        {
            _rolesManager = rolesManager;
        }
        public ActionResult Index()
        {
            _rolesManager.Save(new Role
            {
                Name = "Radik",
                Code = "123"
            });
            return View();
        }
    }
}