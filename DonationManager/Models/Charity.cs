using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DonationManager.Models
{
    public class Charity
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string OfficialName { get; set; }
        public string PreferredMethod { get; set; }
        public string Details { get; set; }
        public string Type { get; set; }
        public string Notes { get; set; }

    }
}