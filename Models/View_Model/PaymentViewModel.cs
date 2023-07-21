using System.ComponentModel.DataAnnotations;


namespace TheChampions.Models.View_Model
{
    public class PaymentViewModel
    {
        [Key]
        public string public_key { get; set; }
        [Required]
        public string First_Name { get; set; }
        [Required]
        public string Last_Name { get; set; }

        [Required, EmailAddress] 
        public string  Email { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public string tx_ref { get; set; }

         // Generate random six-digit number for our chapa tx_ref
        
       
    }

    //public int RandomNumber(int tx_ref)
    //{
    //    int randomNumber = new Random().Next(100000, 999999);
    //    tx_ref = randomNumber;
    //    return tx_ref;
    //}
}
