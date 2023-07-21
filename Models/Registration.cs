using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using TheChampions.Models.View_Model;

namespace TheChampions.Models
{
    public class Registration
    {
        
        public int id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Second Name")]
        public string LastName { get; set; }

        [Display(Name = "Age")]
        public int age { get; set; }

        [Display(Name = "Activity")]
        public int activity { get; set; }
        [ForeignKey("activity")]
        public virtual Activity selectactivity { get; set; }

        [Required]
        [Display(Name = "Phone number")]
        public int tel_No { get; set; }

        [Display(Name = "Email Address")]
        public string Email { get; set; }
        public int Fee { get; set; }


        [NotMapped]
        public IFormFile studentImage { get; set; }
        public string imagePath { get; set; }

        public static implicit operator Registration(PaymentViewModel v)
        {
            throw new NotImplementedException();
        }
    }
}
