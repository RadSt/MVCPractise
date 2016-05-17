using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Enteties
{
    public class User
    {
        [Key]
        [Required(ErrorMessage = "Введите имя пользователя")]
        public string UserName { get; set; }
        [MaxLength(150)]
        [Required(ErrorMessage = "Введите Email")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Введите почту правильного формата")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Введите пароль")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Введите дату рождения")]
        public DateTime BirthdateDate { get; set; }
        public int? RoleId { get; set; }
        public Role Role { get; set; }
    }
}