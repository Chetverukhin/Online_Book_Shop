using Microsoft.AspNetCore.Identity;
using System;

namespace OnlineShop.Db.Models
{
    public class User : IdentityUser
    {
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
    }
}