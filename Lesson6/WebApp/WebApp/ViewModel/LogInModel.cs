using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModel
{
    public class LogInModel
    {
        [Required(ErrorMessage = "Введите имя пользователя")]
        public string UserName { get; set; }
        [MaxLength(150)]
        [Required(ErrorMessage = "Введите Email")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Введите почту правильного формата")]
        public string Email { get; set; }
        [MaxLength(50)]
        [Required(ErrorMessage = "Введите пароль")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}