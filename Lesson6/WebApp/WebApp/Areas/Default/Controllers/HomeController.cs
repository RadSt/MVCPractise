using System.Web.Mvc;
using WebApp.Controllers;

namespace WebApp.Areas.Default.Controllers
{
    public class HomeController : BaseController
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}