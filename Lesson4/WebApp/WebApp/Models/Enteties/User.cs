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
        public string UserName { get; set; }
        [MaxLength(150)]
        public string Email { get; set; }
        [MaxLength(50)]
        public string Password { get; set; }
        public ICollection<Role> Roles { get; set; }
    }
}