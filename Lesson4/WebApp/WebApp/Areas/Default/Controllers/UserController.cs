using System.Web.Mvc;
using WebApp.Controllers;

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
    }
}