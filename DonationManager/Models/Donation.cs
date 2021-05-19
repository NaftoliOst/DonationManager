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

        public DateTime Date { get; set; }
        public float Amount { get; set; }
        public string Note { get; set; }
        public string Method { get; set; }
        
        [ForeignKey("Charity")]
        public int CharityID { get; set; }
        public Charity Charity { get; set; }

        [ForeignKey("Person")]
        public int PersonID { get; set; }
        public Person Person { get; set; }

        //[ForeignKey("Cause")]
        //public int CauseID { get; set; }
        //public Cause Cause { get; set; }
        



    }
}