using System;
using System.Drawing.Imaging;
using System.Linq;
using System.Web.ModelBinding;
using System.Web.Mvc;
using System.Web.Security;
using WebApp.Controllers;
using WebApp.Models.Abstract;
using WebApp.Models.Enteties;
using WebApp.Models.ViewModel;
using WebApp.Tools;
using WebApp.ViewModel;
using static System.String;

namespace WebApp.Areas.Default.Controllers
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        // GET: User
        private ICustomMembershipProvider _membershipProvider;

        public UserController(ICustomMembershipProvider membershipProvider)
        {
            _membershipProvider = membershipProvider;
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LogInModel loginModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (_membershipProvider.ValidateUser(loginModel.UserName, loginModel.Password))
                {
                    FormsAuthentication.SetAuthCookie(loginModel.UserName, loginModel.RememberMe);
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("","Неправильный пароль или логин");
            }
            return View(loginModel);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "User");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                MembershipUser membershipUser = ((ICustomMembershipProvider)Membership.Provider).CreateUser(registerModel.UserName, registerModel.Email, registerModel.Password);
                if (membershipUser != null)
                {
                    FormsAuthentication.SetAuthCookie(registerModel.UserName, false);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("","Ошибка при регистрации");
            }
            return View(registerModel);
        }

        //public ActionResult Register()
        //{
        //    var newUser = new User();
        //    ViewBag.BirthdayDayCollect = _userRegisterView.BirthdayDayCollect;
        //    ViewBag.BirthdayMonthCollect = _userRegisterView.BirthdayMonthCollect;
        //    ViewBag.BirthdayYearCollect = _userRegisterView.BirthdayYearCollect;
        //    return View(newUser);
        //}

        //[HttpPost]
        //public ActionResult Register(User user, string birthdayDay, string birthdayMonth, string birthdayYear)
        //{
        //    if (user.Captcha != (string)Session[CaptchaImage.CaptchaValueKey] )
        //    {
        //        ModelState.AddModelError("Captcha","Текст с картинки введен неверно!");
        //    }

        //    var isUserExist = CustomMembershipProvider.Users.Any(p => Compare(p.UserName, user.UserName) == 0);

        //    if (isUserExist)
        //    {
        //        ModelState.AddModelError("UserName","Пользователь с таким именем уже зарегестрирован");
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        user.BirthdayDate = Convert.ToDateTime(birthdayDay + birthdayMonth + birthdayYear);
        //        CustomMembershipProvider.Save(user);
        //    }

        //    return View(user);
        //}

        public ActionResult Captcha()
        {
            Session[CaptchaImage.CaptchaValueKey] = new Random(DateTime.Now.Millisecond).Next(1111, 9999).ToString();
            var ci = new CaptchaImage(Session[CaptchaImage.CaptchaValueKey].ToString(), 221, 50, "Arial");

            // Change the response headers to output a JPEG image.
            Response.Clear();
            Response.ContentType = "image/jpg";

            // Write the image to the response stream in JPEG format.
            ci.Image.Save(Response.OutputStream, ImageFormat.Jpeg);

            // Dispose of the CAPTCHA image object.
            ci.Dispose();
            return null;
        }
    }
}