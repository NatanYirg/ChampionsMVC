using System.ComponentModel.DataAnnotations;

namespace TheChampions.Models
{
    public class CustomerReach
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Phone_Number { get; set; }
        public DateTime DateTime { get; set; }
        public string CustMessage { get; set; }
        
    }
}
