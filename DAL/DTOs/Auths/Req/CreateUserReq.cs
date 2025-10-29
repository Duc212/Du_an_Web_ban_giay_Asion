namespace DAL.DTOs.Auths.Req
{
    public class CreateUserReq
    {
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<string> ListRole { get; set; }
    }
}
