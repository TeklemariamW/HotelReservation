using Microsoft.AspNetCore.Identity;

namespace Hotel.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Nickname { get; set; }
        public int Age { get; set; }
    }
}