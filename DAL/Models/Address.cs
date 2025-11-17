using Microsoft.EntityFrameworkCore;
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
        [MaxLength(250),Unicode(true)]
        public string AddressDetail { get; set; }
        [MaxLength(100),Unicode(true)]
        public string City { get; set; }
        [MaxLength(100),Unicode(true)]
        public string? District { get; set; }
        [MaxLength(100),Unicode(true)]
        public string Ward { get; set; }
        [MaxLength(100),Unicode(true)]
        public string Street { get; set; }

        // Navigation
        public User? User { get; set; }
    }

}
