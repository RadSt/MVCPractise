using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Enteties
{
    public class Role
    {
        public Role()
        {
            Users = new List<User>();
        }
        public int RoleId { get; set; }
        [MaxLength(50)]
        public string Code { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
    }
}