using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DonationManager.Models
{
    [Table("Donations")]
    public class Donation
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public DateTime Date { get; set; }
        [Required]
        public float Amount { get; set; }

        public string Note { get; set; }
        public string Method { get; set; }
        
        [ForeignKey("Charity")]
        [Required]
        public int CharityID { get; set; }
        public Charity Charity { get; set; }

        
        //[ForeignKey("Cause")]
        //public int CauseID { get; set; }
        //public Cause Cause { get; set; }
    }
}