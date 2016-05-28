using System.Web.Mvc;
using WebApp.Controllers;

namespace WebApp.Areas.Default.Controllers
{
    public class HomeController : BaseController
    {
        [Authorize]
        public ActionResult Index()
        {
            //Проверка есть ли залогенный пользователь
            if (Request.IsAuthenticated)
            {
                //Имя пользователя
                string userName = User.Identity.Name;
                return View();
            }
            return View();
        }
    }
}