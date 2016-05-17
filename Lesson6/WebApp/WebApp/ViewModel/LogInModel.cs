using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModel
{
    public class LogInModel
    {
        [Required(ErrorMessage = "Введите имя пользователя")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Введите пароль")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}