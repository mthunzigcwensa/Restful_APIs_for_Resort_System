using Microsoft.AspNetCore.Identity;

namespace RestfulAPIs.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
