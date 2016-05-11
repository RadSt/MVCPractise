using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private IWeapon weapon;

        public HomeController(IWeapon weapon)
        {
            this.weapon = weapon;
        }

        public ActionResult Index()
        {
            return View(weapon);
        }
    }
}