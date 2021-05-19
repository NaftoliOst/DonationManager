using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DonationManager.Models
{
    [Table("Charities")]
    public class Charity
    {
        [Key]
        public int ID { get; set; }
        
        public string Name { get; set; }
        public string OfficialName { get; set; }
        public string PreferredMethod { get; set; }
        public string Details { get; set; }
        public string Type { get; set; }
        public string Notes { get; set; }

        public ICollection<Donation> Donations { get; set; }

        // public ICollection<Cause> Causes { get; set; }

    }
}