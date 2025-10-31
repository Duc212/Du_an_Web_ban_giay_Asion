# Avatar System Documentation

## T?ng quan

H? th?ng avatar t? ??ng t?o v� c?p nh?t ?nh ??i di?n cho ng??i d�ng:

1. **Register th�ng th??ng**: T? ??ng generate avatar v?i ch? c�i ??u (VD: Th�i S?n ? TS)
2. **Google Login**: L?y avatar t? t�i kho?n Google v� **lu�n c?p nh?t** m?i l?n login

## 1. Avatar cho Register (Ch? c�i ??u)

### C�ch ho?t ??ng

Khi user ??ng k� b?ng form th�ng th??ng, h? th?ng s?:
1. L?y t�n ??y ?? (VD: "Th�i S?n")
2. T?o initials t? t�n (VD: "TS")
3. Generate avatar URL v?i API mi?n ph�
4. L?u URL v�o database

### Service Implementation

**Helper/Utils/AvatarUtils.cs**:
```csharp
public string GenerateAvatarUrl(string fullName)
{
    var initials = GetInitials(fullName);
    var backgroundColor = GetColorFromName(fullName);
    
    return $"https://ui-avatars.com/api/?name={initials}&size=200&background={backgroundColor}&color=ffffff&bold=true";
}

public string GetInitials(string fullName)
{
    // "Th�i S?n" ? "TS"
    // "Nguy?n V?n A" ? "NA"
  var parts = fullName.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
    
    if (parts.Length == 1)
        return parts[0].Substring(0, Math.Min(2, parts[0].Length)).ToUpper();
    
    return parts[0][0].ToString().ToUpper() + parts[^1][0].ToString().ToUpper();
}
```

### V� d? Generated Avatars

| T�n ??y ?? | Initials | Avatar URL |
|------------|----------|------------|
| Th�i S?n | TS | `https://ui-avatars.com/api/?name=TS&size=200&background=007bff&color=ffffff&bold=true` |
| Nguy?n V?n A | NA | `https://ui-avatars.com/api/?name=NA&size=200&background=28a745&color=ffffff&bold=true` |
| L� Th? B | LB | `https://ui-avatars.com/api/?name=LB&size=200&background=dc3545&color=ffffff&bold=true` |
| John | JO | `https://ui-avatars.com/api/?name=JO&size=200&background=ffc107&color=ffffff&bold=true` |

### Color System

M?i t�n s? c� m�u background kh�c nhau d?a tr�n hash c?a t�n:

```csharp
private string GetColorFromName(string name)
{
    int hash = 0;
    foreach (char c in name) hash = ((hash << 5) - hash) + c;
    
    string[] colors = {
        "007bff", // Blue
        "6610f2", // Indigo
        "6f42c1", // Purple
        "e83e8c", // Pink
        "dc3545", // Red
        "fd7e14", // Orange
 "ffc107", // Yellow
        "28a745", // Green
"20c997", // Teal
        "17a2b8", // Cyan
  };
    
    return colors[Math.Abs(hash) % colors.Length];
}
```

## 2. Avatar t? Google Login

### C�ch ho?t ??ng

**Quan tr?ng**: Avatar t? Google ???c **c?p nh?t M?I L?N LOGIN**

```csharp
public async Task<CommonResponse<LoginRes>> GoogleLogin(GoogleLoginReq req)
{
    var payload = await GoogleJsonWebSignature.ValidateAsync(req.IdToken);
  
    if (existingUser == null)
    {
        // User m?i: L?u picture t? Google
        user = new User
        {
 Picture = payload.Picture, // ? Avatar t? Google
 // ... other fields
        };
    }
    else
    {
// User c?: LU�N c?p nh?t picture t? Google
        user = existingUser;
      if (!string.IsNullOrEmpty(payload.Picture))
        {
         user.Picture = payload.Picture;
   await _userRepository.UpdateAsync(user);
await _userRepository.SaveChangesAsync();
        }
    }
}
```

### T?i sao lu�n c?p nh?t?

? **L� do:**
- User c� th? thay ??i avatar tr�n Google account
- ??m b?o avatar lu�n sync v?i t�i kho?n Google
- User kh�ng c?n manually update avatar trong app

### Google Avatar URL Format

```
https://lh3.googleusercontent.com/a/ACg8ocJ...
```

- URL n�y do Google cung c?p
- C� th? thay ??i khi user update avatar tr�n Google
- Kh�ng expire ngay l?p t?c nh?ng c� th? thay ??i

## 3. Database Schema

### User Table

```sql
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    FullName NVARCHAR(150) NOT NULL,
    Username NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    Picture NVARCHAR(500) NULL,  -- ? Avatar URL
    -- ... other fields
)
```

### Migration

```bash
dotnet ef migrations add AddPictureToUser --project DAL --startup-project API
dotnet ef database update --project DAL --startup-project API
```

## 4. API Response

### Register Response (v?i generated avatar)

```json
{
  "success": true,
  "message": "?� g?i m� x�c nh?n ??n email c?a b?n.",
  "data": "123456"
}
```

Sau khi verify, user s? c�:
```json
{
  "userID": 123,
  "fullName": "Th�i S?n",
  "email": "thaison@example.com",
  "picture": "https://ui-avatars.com/api/?name=TS&size=200&background=007bff&color=ffffff&bold=true"
}
```

### Google Login Response (v?i Google avatar)

**L?n ??u login:**
```json
{
  "success": true,
"message": "??ng nh?p Google th�nh c�ng! T�i kho?n m?i ?� ???c t?o.",
  "data": {
    "accessToken": "eyJ...",
    "userID": 124,
    "fullName": "Nguyen Van A",
    "email": "nguyenvana@gmail.com",
    "picture": "https://lh3.googleusercontent.com/a/ACg8ocJ...",
    "isEmailVerified": true
  }
}
```

**L?n sau login (avatar updated):**
```json
{
  "success": true,
  "message": "??ng nh?p Google th�nh c�ng!",
  "data": {
    "accessToken": "eyJ...",
    "userID": 124,
    "fullName": "Nguyen Van A",
    "email": "nguyenvana@gmail.com",
    "picture": "https://lh3.googleusercontent.com/a/NEW_AVATAR_URL...",
    "isEmailVerified": true
  }
}
```

## 5. Flow Diagrams

### Register Flow

```
User Register Form
    ?
Input: Th�i S?n
    ?
AvatarUtils.GenerateAvatarUrl("Th�i S?n")
    ?
GetInitials("Th�i S?n") ? "TS"
    ?
Generate URL: https://ui-avatars.com/api/?name=TS...
    ?
Cache tempData with Picture URL
    ?
User Verify OTP
    ?
Save User to DB with Picture
    ?
User has avatar with "TS" initials
```

### Google Login Flow

```
User Click "Sign in with Google"
    ?
Google OAuth ? ID Token
    ?
Backend: Validate ID Token
    ?
Extract: payload.Picture
    ?
Check if User exists?
    ?? No ? Create new User
    ?         ?? Set Picture = payload.Picture
    ?
    ?? Yes ? Update existing User
     ?? Set Picture = payload.Picture (ALWAYS)
    ?
Save to Database
    ?
Return Response with updated Picture
    ?
Frontend: Display Google avatar
```

## 6. Frontend Integration

### Display Avatar in HTML

```html
<div class="user-avatar">
    <img src="{{user.picture}}" 
         alt="{{user.fullName}}"
         onerror="this.src='https://ui-avatars.com/api/?name={{user.fullName}}'">
</div>
```

### Display Avatar in Blazor

```razor
@if (!string.IsNullOrEmpty(CurrentUser?.Picture))
{
    <img src="@CurrentUser.Picture" 
  alt="@CurrentUser.FullName" 
         class="user-avatar" />
}
else
{
    <div class="user-avatar-placeholder">
        @GetInitials(CurrentUser?.FullName)
    </div>
}
```

### CSS for Avatar

```css
.user-avatar {
    width: 40px;
 height: 40px;
    border-radius: 50%;
    object-fit: cover;
    border: 2px solid #e0e0e0;
}

.user-avatar-placeholder {
    width: 40px;
    height: 40px;
    border-radius: 50%;
    background: #007bff;
    color: white;
    display: flex;
    align-items: center;
  justify-content: center;
    font-weight: bold;
    font-size: 16px;
}
```

## 7. Alternative Avatar Services

### DiceBear API (More styles)

```csharp
public string GenerateAvatarUrlDiceBear(string fullName, string style = "initials")
{
    var seed = HttpUtility.UrlEncode(fullName);
    return $"https://api.dicebear.com/7.x/{style}/svg?seed={seed}";
}
```

Styles available:
- `initials` - Letter avatars
- `avataaars` - Cartoon style
- `bottts` - Robot style
- `identicon` - Geometric patterns

### Gravatar (if user has account)

```csharp
public string GenerateGravatarUrl(string email, int size = 200)
{
    using var md5 = MD5.Create();
    var emailBytes = Encoding.UTF8.GetBytes(email.Trim().ToLowerInvariant());
    var hashBytes = md5.ComputeHash(emailBytes);
    var hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
    
    return $"https://www.gravatar.com/avatar/{hash}?s={size}&d=identicon";
}
```

## 8. Testing

### Test Register Avatar

```bash
POST /api/Auth/Register
{
  "fullName": "Th�i S?n",
  "username": "thaison",
  "email": "thaison@example.com",
  "password": "123456",
  "phone": "0123456789",
  "dateOfBirth": "1990-01-01"
}

# Response will contain code, verify it
POST /api/Auth/Verify
{
  "email": "thaison@example.com",
  "code": "123456"
}

# User now has avatar: https://ui-avatars.com/api/?name=TS...
```

### Test Google Login Avatar

```bash
# First login - creates user with Google avatar
POST /api/Auth/GoogleLogin
{
  "idToken": "eyJhbGc..."
}

# Response:
{
  "picture": "https://lh3.googleusercontent.com/a/ORIGINAL..."
}

# User changes Google avatar
# Second login - updates avatar automatically
POST /api/Auth/GoogleLogin
{
  "idToken": "eyJhbGc..."
}

# Response:
{
  "picture": "https://lh3.googleusercontent.com/a/UPDATED..."
}
```

## 9. Best Practices

### ? DO:
- Always sync Google avatar on login
- Use fallback avatars (onerror handler)
- Cache avatar URLs in frontend
- Use CDN for avatar images
- Validate Picture URL before display

### ? DON'T:
- Don't let users manually edit Google avatars
- Don't cache Google avatars too long (they can change)
- Don't expose full Google avatar URLs in logs
- Don't skip avatar update on Google login

## 10. Troubleshooting

### Avatar kh�ng hi?n th?

**Register Avatar:**
```
Problem: Generated avatar URL kh�ng load
Solution: Check UI Avatars API status, use fallback
```

**Google Avatar:**
```
Problem: Google avatar URL expired
Solution: User login l?i ?? refresh avatar
```

### Avatar kh�ng update

**Check:**
1. Verify `payload.Picture` c� gi� tr?
2. Check `UpdateAsync` ???c g?i
3. Verify database c� c?t `Picture`
4. Check SaveChangesAsync ???c await

### Performance Issues

**Solution:**
- Cache avatar URLs in Redis
- Use CDN for generated avatars
- Lazy load avatars in UI
- Use thumbnail size (200px) not full size

## 11. Security Considerations

? **Implemented:**
- Sanitize fullName before generating avatar
- Validate Picture URL format
- Use HTTPS for all avatar URLs
- Don't expose user emails in avatar URLs

?? **Consider:**
- Rate limiting avatar generation
- Validate image content type
- Implement avatar moderation system
- Allow users to upload custom avatars later