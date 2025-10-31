# API Response Examples

## 1. Google Login Response

### Success Response - New User
```json
{
"success": true,
  "message": "??ng nh?p Google th�nh c�ng! T�i kho?n m?i ?� ???c t?o.",
  "data": {
    "accessToken": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjMiLCJuYW1lIjoiTmd1eWVuIFZhbiBBIiwiaWF0IjoxNjM2NjE2NDAwfQ.dBjftJeZ4CVP",
    "refreshToken": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjMiLCJ0eXBlIjoicmVmcmVzaCIsImlhdCI6MTYzNjYxNjQwMH0.K7aBxN",
    "userID": 123,
  "fullName": "Nguyen Van A",
    "email": "nguyenvana@gmail.com",
    "phone": " ",
    "picture": "https://lh3.googleusercontent.com/a/AEdFTp7wQx_abc123",
    "isEmailVerified": true,
    "roleName": ["User"]
  }
}
```

### Success Response - Existing User
```json
{
  "success": true,
  "message": "??ng nh?p Google th�nh c�ng!",
  "data": {
    "accessToken": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
 "refreshToken": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
    "userID": 456,
    "fullName": "Tran Thi B",
    "email": "tranthib@gmail.com",
    "phone": "0912345678",
    "picture": "https://lh3.googleusercontent.com/a/AEdFTp7wQx_def456",
    "isEmailVerified": true,
    "roleName": ["User", "Premium"]
  }
}
```

### Error Response - Invalid Token
```json
{
  "success": false,
  "message": "Token Google kh�ng h?p l?! Chi ti?t: JWT must consist of Header, Payload, and Signature",
  "data": null
}
```

### Error Response - Empty Token
```json
{
  "success": false,
  "message": "Token kh�ng h?p l?!",
  "data": null
}
```

## 2. Normal Login Response

### Success Response
```json
{
  "success": true,
  "message": "??ng nh?p th�nh c�ng.",
  "data": {
    "accessToken": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
    "refreshToken": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
    "userID": 789,
    "fullName": "Le Van C",
    "email": "levanc@example.com",
    "phone": "0909876543",
    "picture": null,
    "isEmailVerified": true,
    "roleName": ["User"]
  }
}
```

### Error Response - Wrong Password
```json
{
  "success": false,
  "message": "M?t kh?u kh�ng ?�ng.",
  "data": null
}
```

### Error Response - User Not Found
```json
{
  "success": false,
  "message": "T�i kho?n kh�ng t?n t?i.",
  "data": null
}
```

## 3. Register Response

### Success Response
```json
{
  "success": true,
  "message": "?� g?i m� x�c nh?n ??n email c?a b?n. Vui l�ng ki?m tra h?p th?.",
  "data": "123456"
}
```

### Error Response - Duplicate User
```json
{
  "success": false,
  "message": "T�n ??ng nh?p ho?c email ?� t?n t?i!",
  "data": null
}
```

## 4. Verify Register Response

### Success Response
```json
{
  "success": true,
  "message": "X�c nh?n th�nh c�ng, t�i kho?n c?a b?n ?� ???c t?o!",
  "data": true
}
```

### Error Response - Invalid Code
```json
{
  "success": false,
  "message": "M� x�c nh?n kh�ng ch�nh x�c!",
  "data": false
}
```

### Error Response - Expired Code
```json
{
  "success": false,
  "message": "M� x�c nh?n kh�ng t?n t?i ho?c ?� h?t h?n!",
  "data": false
}
```

## 5. Response Fields Explanation

### LoginRes Fields

| Field | Type | Description | Example |
|-------|------|-------------|---------|
| `accessToken` | string | JWT token for API authentication | `"eyJhbGc..."` |
| `refreshToken` | string | Token to get new access token | `"eyJhbGc..."` |
| `userID` | int | Unique user identifier | `123` |
| `fullName` | string | User's full name | `"Nguyen Van A"` |
| `email` | string | User's email address | `"user@gmail.com"` |
| `phone` | string | User's phone number | `"0912345678"` |
| `picture` | string? | Avatar URL (from Google or null) | `"https://lh3..."` |
| `isEmailVerified` | bool | Email verification status | `true` |
| `roleName` | string[] | List of user roles | `["User", "Admin"]` |

### CommonResponse Fields

| Field | Type | Description | Example |
|-------|------|-------------|---------|
| `success` | bool | Operation result | `true` |
| `message` | string | Result message | `"??ng nh?p th�nh c�ng."` |
| `data` | T? | Response data (nullable) | `LoginRes` or `null` |

## 6. Usage in Frontend

### JavaScript Example
```javascript
async function loginWithGoogle(idToken) {
    try {
        const response = await fetch('https://localhost:7134/api/Auth/GoogleLogin', {
    method: 'POST',
  headers: {
  'Content-Type': 'application/json'
      },
         body: JSON.stringify({ idToken })
  });

        const result = await response.json();

        if (result.success) {
            // Save tokens
        localStorage.setItem('accessToken', result.data.accessToken);
localStorage.setItem('refreshToken', result.data.refreshToken);

  // Save user info
   const userInfo = {
           id: result.data.userID,
                name: result.data.fullName,
        email: result.data.email,
          phone: result.data.phone,
   avatar: result.data.picture,
 verified: result.data.isEmailVerified,
    roles: result.data.roleName
 };
     localStorage.setItem('user', JSON.stringify(userInfo));

         // Display avatar
          if (result.data.picture) {
       document.getElementById('avatar').src = result.data.picture;
        }

       // Show welcome message
            alert(`Xin ch�o, ${result.data.fullName}!`);

    // Redirect
     window.location.href = '/dashboard';
        } else {
  alert(`L?i: ${result.message}`);
        }
    } catch (error) {
        console.error('Login error:', error);
        alert('Kh�ng th? k?t n?i ??n server');
    }
}
```

### C# Blazor Example
```csharp
public async Task<bool> LoginWithGoogle(string idToken)
{
    var request = new GoogleLoginReq { IdToken = idToken };
var response = await _httpClient.PostAsJsonAsync("api/Auth/GoogleLogin", request);
    var result = await response.Content.ReadFromJsonAsync<CommonResponse<LoginRes>>();

    if (result?.Success == true && result.Data != null)
    {
  // Save to local storage
  await _localStorage.SetItemAsync("accessToken", result.Data.AccessToken);
        await _localStorage.SetItemAsync("user", result.Data);

        // Update UI
StateHasChanged();

        return true;
    }

return false;
}
```

## 7. HTTP Status Codes

| Code | Description | When |
|------|-------------|------|
| 200 | OK | Request successful (check `success` field) |
| 400 | Bad Request | Invalid request format |
| 500 | Internal Server Error | Server error |

**Note**: API always returns 200 OK. Check `success` field in response body for actual result.