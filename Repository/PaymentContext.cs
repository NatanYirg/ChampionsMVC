using Microsoft.EntityFrameworkCore;
using TheChampions.Models.View_Model;

namespace TheChampions.Repository
{
    public class PaymentContext : DbContext
    {
        public PaymentContext(DbContextOptions<PaymentContext> options) : base(options)
        {
            
        }

        public DbSet<PaymentViewModel> PaidCustomer { get; set; }
    }
}
