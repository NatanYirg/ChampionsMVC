using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;


namespace TheChampions.Models
{

    public class Activity
    {
       
        public int activityid { get; set; }

        [Display(Name = "Activity")]
        public string activityname { get; set; }

    }
}
