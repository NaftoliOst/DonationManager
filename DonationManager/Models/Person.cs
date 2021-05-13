using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DonationManager.Models
{
    [Table("Persons")]
    public class Person
    {
        [Key]
        public int ID { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        
        //[ForeignKey("Users.Id")]
        //public int UserID { get; set; }
    }
}