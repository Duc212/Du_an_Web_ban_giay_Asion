using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ReturnRequest
    {
        public int ReturnID { get; set; }
        public int OrderID { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
        public DateTime RequestDate { get; set; }

        // Navigation
        public Order Order { get; set; }
        public ICollection<ReturnDetail> ReturnDetails { get; set; }
    }

}
