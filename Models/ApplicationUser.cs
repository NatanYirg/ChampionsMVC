using Microsoft.AspNetCore.Identity;

namespace TheChampions.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }
        //public string? FirstName { get; set; }
        //public string? LastName { get; set; }
        

    }
}
