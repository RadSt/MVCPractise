using System.Linq;
using System.Web.ModelBinding;
using System.Web.Mvc;
using WebApp.Controllers;
using WebApp.Models.Enteties;
using static System.String;

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
            if (user.Captcha != "1234" )
            {
                ModelState.AddModelError("Captcha","Текст с картинки введен неверно!");
            }

            var isUserExist = UserManager.Users.Any(p => Compare(p.UserName, user.UserName) == 0);

            if (isUserExist)
            {
                ModelState.AddModelError("UserName","Пользователь с таким именем уже зарегестрирован");
            }

            if (ModelState.IsValid)
            {
                UserManager.Save(user);
            }

            return View(user);
        }
    }
}