using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Enteties
{
    public class User
    {
        public User()
        {
            Roles = new List<Role>();
        }
        [Key]
        [Required(ErrorMessage = "Введите имя пользователя")]
        public string UserName { get; set; }
        [MaxLength(150)]
        [Required(ErrorMessage = "Введите Email")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Введите почту правильного формата")]
        public string Email { get; set; }
        [MaxLength(50)]
        [Required(ErrorMessage = "Введите пароль")]
        public string Password { get; set; }
        [MaxLength(50)]
        [Required(ErrorMessage = "Повторите ввод пароля")]
        [Compare("Password",ErrorMessage = "Пароли должны совпадать")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Введите дату рождения")]
        public DateTime BirthdayDate { get; set; }
        [MaxLength(50)]
        public string Captcha { get; set; }
        public ICollection<Role> Roles { get; set; }
    }
}