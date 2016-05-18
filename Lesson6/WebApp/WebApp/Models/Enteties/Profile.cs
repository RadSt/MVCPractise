using System;

namespace WebApp.Models.Enteties
{
    public class Profile
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public string UserName { get; set; }
        public virtual User User { get; set; }
    }
}