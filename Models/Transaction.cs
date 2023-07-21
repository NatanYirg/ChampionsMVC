using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;

namespace TheChampions.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        [Column(TypeName = "nvarchar(12)")]
        [DisplayName("Account Number")]
        [Required]
        [MaxLength(12, ErrorMessage = "Maximum 12 characters only")]
        public string AccountNumber { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Beneficiary Name")]
        [Required]
        public string BeneficiaryName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Bank Name")]
        //[Required(ErrorMessage ="This Field is required")]
        
        public string BankName { get; set; }

        [Column(TypeName = "nvarchar(11)")]
        [DisplayName("Swift Code")]
        [Required]
        public string SwiftCode { get; set;}

        [DisplayName("Amount")]
        [Required]
        public int amount { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM-dd-yy}")]
        public DateTime Date { get; set; }

    }
}
