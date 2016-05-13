using System.Web.Mvc;
using WebApp.Controllers;
using WebApp.Models.Enteties;

namespace WebApp.Areas.Default.Controllers
{
    public class UserController : BaseController
    {
        // GET: User
        public ActionResult Index()
        {
            var users = UserManager.Users;
            return View(users);
        }

        public ActionResult Register()
        {
            var newUser = new User();
            return View(newUser);
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            return View(user);
        }
    }
}