namespace AdminWeb.Models
{
    // Response Models
    public class GetListUserRes
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<UserAddress> Address { get; set; } = new();
        public string PhoneNumber { get; set; } = string.Empty;
        public string RoleName { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
        public string Picture { get; set; } = string.Empty;
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class GetUserDetailRes
    {
        public int UserID { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string? Avatar { get; set; }
        public int Gender { get; set; }
        public int Status { get; set; }
        public List<string> Roles { get; set; } = new();
        public DateTime CreatedAt { get; set; }
    }

    public class UserAddress
    {
        public string AddressDetail { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string Ward { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
    }

    public class GetListUserResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<GetListUserRes> Data { get; set; } = new();
        public int TotalRecords { get; set; }
    }

    // Request Models
    public class AddUserRequest
    {
        public string FullName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
        public List<string> Roles { get; set; } = new();
    }

    public class UpdateUserRequest
    {
        public int UserID { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string? Password { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string? Avatar { get; set; }
        public int Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Status { get; set; }
        public List<string> Roles { get; set; } = new();
    }

    public class UpdateUserReq
    {
        public int UserID { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string? Password { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string? Avatar { get; set; }
        public int Gender { get; set; }
        public int Status { get; set; }
    }

    // Role Models
    public class RoleDTO
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; } = string.Empty;
    }

    public class GetRoleListResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<RoleDTO> Data { get; set; } = new();
    }
}
