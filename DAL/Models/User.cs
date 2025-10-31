using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        [MaxLength(150),Unicode(true)]
        public string FullName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }
        [Required]
        [MaxLength(100)]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }
        [Phone]
        [MaxLength(20)]
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        [MaxLength(500)]
        public string? Picture { get; set; }
        [Required]
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; } 

        // Navigation
        public ICollection<UserRole>UserRoles  { get; set; } = new List<UserRole>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
        public ICollection<Cart> Carts { get; set; }    = new List<Cart>();
    }

}
