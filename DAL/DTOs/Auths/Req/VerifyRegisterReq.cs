namespace DAL.DTOs.Auths.Req
{
    public class VerifyRegisterReq
    {
        public string Email { get; set; }
        public string Code { get; set; }
    }
}
