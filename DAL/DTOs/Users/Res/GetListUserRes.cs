using System.ComponentModel.DataAnnotations;

namespace DAL.DTOs.Users.Res
{
    public class GetListUserRes
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<GetAddressUserRes> Address { get; set; }
        public string PhoneNumber { get; set; }
        public string RoleName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Picture { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
