using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Gender
    {
        [Key]
        public int GenderID { get; set; }
        public string Name{ get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
