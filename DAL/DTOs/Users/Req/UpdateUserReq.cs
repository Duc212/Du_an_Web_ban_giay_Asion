namespace DAL.DTOs.Users.Req
{
    public class UpdateUserReq
    {
        public int UserID { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string? Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Status { get; set; }
        public List<string> Roles { get; set; }
    }
}
