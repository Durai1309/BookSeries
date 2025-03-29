using Microsoft.AspNetCore.Identity;

namespace Bookservie.Services.AuthAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
