using System;
using System.Linq;
using System.Web.ModelBinding;
using System.Web.Mvc;
using WebApp.Controllers;
using WebApp.Models.Abstract;
using WebApp.Models.Enteties;
using static System.String;

namespace WebApp.Areas.Default.Controllers
{
    public class UserController : BaseController
    {
        // GET: User
        private IUserRegisterView _userRegisterView;
        public UserController(IUserRegisterView userRegisterView)
        {
            _userRegisterView = userRegisterView;
        }
        public ActionResult Index()
        {
            var users = UserManager.Users;
            return View(users);
        }

        public ActionResult Register()
        {
            var newUser = new User();
            ViewBag.BirthdayDayCollect = _userRegisterView.BirthdayDayCollect;
            ViewBag.BirthdayMonthCollect = _userRegisterView.BirthdayMonthCollect;
            ViewBag.BirthdayYearCollect = _userRegisterView.BirthdayYearCollect;
            return View(newUser);
        }

        [HttpPost]
        public ActionResult Register(User user, string birthdayDay, string birthdayMonth, string birthdayYear)
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
                user.BirthdayDate = Convert.ToDateTime(birthdayDay + birthdayMonth + birthdayYear);
                UserManager.Save(user);
            }

            return View(user);
        }
    }
}