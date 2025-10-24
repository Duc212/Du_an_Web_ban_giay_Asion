using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ReturnRequest
    {
        [Key]
        public int ReturnID { get; set; }
        public int OrderID { get; set; }
        // Navigation
        public Order? Order { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
        public DateTime RequestDate { get; set; }

        
    }

}
