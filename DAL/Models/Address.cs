using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Address
    {
        [Key]
        public int AddressID { get; set; }
        public int UserID { get; set; }
        public string? AddressDetail { get; set; }
        public string? City { get; set; }
        public string? Ward { get; set; }

        // Navigation
        public User? User { get; set; }
    }

}
