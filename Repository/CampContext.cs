using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TheChampions.Models;
using TheChampions.Models.View_Model;

namespace TheChampions.Repository
{
    public class CampContext : IdentityDbContext<ApplicationUser>
    {
        public CampContext(DbContextOptions<CampContext> options) : base(options)
        {

        }

        public DbSet<Registration> registrations { get; set; }
        public DbSet<Activity> activities { get; set; }
        public DbSet<Transaction> transactions { get; set; }

            
    }
}
