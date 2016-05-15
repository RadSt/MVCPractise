using System.Web.Mvc;
using WebApp.Controllers;

namespace WebApp.Areas.Default.Controllers
{
    public class RoleController : BaseController
    {
        // GET: Role
        public ActionResult Index()
        {
            var roles = UserManager.Roles;
            return View(roles);
        }
    }
}