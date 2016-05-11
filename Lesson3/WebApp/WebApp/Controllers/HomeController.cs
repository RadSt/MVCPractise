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
        public IWeapon Weapon { get; set; }
        public HomeController()
        {
            Weapon = DependencyResolver.Current.GetService<IWeapon>();
        }
        // GET: Home
        public ActionResult Index()
        {
            return View(Weapon);
        }
    }
}