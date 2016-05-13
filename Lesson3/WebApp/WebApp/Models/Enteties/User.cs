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
        public int UserId { get; set; }
        [MaxLength(150)]
        public string Name { get; set; }
        [MaxLength(150)]
        public string Email { get; set; }
        [MaxLength(50)]
        public string Password { get; set; }
        public ICollection<Role> Roles { get; set; }
    }
}