using DAL.Models;
using System;
using System.Collections.Generic;

namespace DAL.DTOs.Auths.Res
{
    public class UserWithAddressRes
    {
        public int UserID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string? Picture { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int Status { get; set; }
        public List<Address> Addresses { get; set; } = new();
    }
}