using MessagePack;
using Microsoft.Build.Execution;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TheChampions.Models
{
    public class Transac
    {

        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int T_Id { get; set; }
        public DateTime Date { get; set; }
        public string Pay_Request_Id { get; set; }    
        public int amount { get; set; }
        public string Reference { get; set; }
        public string Transaction_Status { get; set; }
        public ResultCodes Result_Code { get; set; }
        public string Result_Desc { get; set; }
        public string Email_address { get; set; }
    }

    public enum ResultCodes
    {
    Call_for_Approval=900001,		
	Card_Expired= 900002,	
	Insufficient_Funds	= 900003,
    Invalid_Card_Number	= 900004,	
	Bank_Interface_Timeout = 900005, 
	Invalid_Card = 900006,	
	Declined = 900007,
	Lost_Card = 900009,
	Invalid_Card_Length = 900010,	
	Suspected_Fraud	= 900011,
	Card_Reported_as_Stolen	= 900012,
	Restricted_Card	= 900013,
	Excessive_Card_Usage = 900014,	
	Card_Blacklisted = 900015,	
	Declined_authentication_failed = 900207,
	ThreeD_Secure_Lookup_Timeout = 900210,
	Invalid_expiry_date = 991001,	
	Invalid_Amount = 991002
    }

}
