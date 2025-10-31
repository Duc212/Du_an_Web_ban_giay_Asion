# ? Avatar System Summary

## ?? T?ng quan nhanh

H? th?ng t? ??ng t?o và c?p nh?t avatar cho user:

| Ph??ng th?c | Avatar Source | Update Logic |
|-------------|---------------|--------------|
| **Register** | Generated (Ch? cái ??u) | T?o 1 l?n khi ??ng ký |
| **Google Login** | Google Account | **C?p nh?t M?I L?N login** |

## ?? Register Avatar (Ch? cái ??u)

### Ví d?

```
Thái S?n     ? TS ? https://ui-avatars.com/api/?name=TS&...
Nguy?n V?n A ? NA ? https://ui-avatars.com/api/?name=NA&...
John Doe     ? JD ? https://ui-avatars.com/api/?name=JD&...
```

### Code

```csharp
// In Register method
var avatarUrl = _avatarUtils.GenerateAvatarUrl(req.FullName);
var tempData = new { 
    Picture = avatarUrl, // Save to cache
    // ... other fields
};
```

## ?? Google Login Avatar (Sync t? Google)

### Cách ho?t ??ng

```csharp
if (existingUser == null)
{
    // T?o m?i: L?u avatar t? Google
    user.Picture = payload.Picture;
}
else
{
    // ?ã t?n t?i: LUÔN c?p nh?t avatar t? Google
    if (!string.IsNullOrEmpty(payload.Picture))
    {
        user.Picture = payload.Picture;
        await _userRepository.UpdateAsync(user);
        await _userRepository.SaveChangesAsync();
  }
}
```

### T?i sao c?p nh?t m?i l?n?

? User thay ??i avatar trên Google ? App t? ??ng sync  
? Không c?n user manually update  
? Avatar luôn up-to-date v?i Google account  

## ?? Database

```sql
ALTER TABLE Users
ADD Picture NVARCHAR(500) NULL;
```

Migration ?ã apply:
```
? 20251031043715_AddPictureToUser.cs
```

## ?? API Responses

### Register + Verify

```json
{
  "userID": 123,
  "fullName": "Thái S?n",
  "picture": "https://ui-avatars.com/api/?name=TS&size=200&..."
}
```

### Google Login (M?i)

```json
{
  "userID": 124,
  "fullName": "Nguyen Van A",
  "picture": "https://lh3.googleusercontent.com/a/ACg8ocJ...",
  "isEmailVerified": true
}
```

### Google Login (C? - Updated)

```json
{
  "userID": 124,
  "fullName": "Nguyen Van A",
  "picture": "https://lh3.googleusercontent.com/a/NEW_URL...",
  "isEmailVerified": true
}
```

## ?? Implementation Checklist

- [x] Create IAvatarUtils interface
- [x] Implement AvatarUtils service
- [x] Register service in DI (API/Program.cs)
- [x] Add Picture column to User table
- [x] Update Register to generate avatar
- [x] Update VerifyRegister to save avatar
- [x] Update GoogleLogin to sync avatar (ALWAYS)
- [x] Create migration
- [x] Apply migration to database
- [x] Update LoginRes to include Picture
- [x] Update API responses
- [x] Create documentation

## ?? Usage Examples

### Frontend - Display Avatar

```html
<img src="{{user.picture}}" 
     alt="{{user.fullName}}"
     class="user-avatar"
     onerror="this.src='https://ui-avatars.com/api/?name={{user.fullName}}'">
```

### Blazor - Display Avatar

```razor
<img src="@CurrentUser?.Picture" 
 alt="@CurrentUser?.FullName" 
     class="rounded-circle"
     width="40" 
     height="40" />
```

## ?? Services Used

### UI Avatars (Free)
- URL: https://ui-avatars.com
- Generate avatars from initials
- Customizable colors, size, font
- No API key required
- No rate limits

### Google Profile Pictures
- Provided by Google OAuth
- High quality (up to 2048x2048)
- Updates when user changes Google avatar
- Format: `https://lh3.googleusercontent.com/...`

## ?? Documentation Files

- `AVATAR_SYSTEM_DOCUMENTATION.md` - Chi ti?t ??y ??
- `GOOGLE_LOGIN_GUIDE.md` - H??ng d?n Google Login
- `API_RESPONSE_EXAMPLES.md` - Examples API responses

## ?? Features

? **Auto-generate avatars** cho register users  
?? **Auto-sync** Google avatars m?i l?n login  
?? **Unique colors** cho m?i user (based on name hash)  
?? **Responsive** - Works on all devices  
?? **Fast** - Uses CDN for avatars  
?? **Secure** - Validates all URLs  

## ?? Testing

Test avatar generation:
```bash
# Register
curl -X POST https://localhost:7134/api/Auth/Register \
  -H "Content-Type: application/json" \
  -d '{"fullName":"Thái S?n","username":"thaison",...}'

# Check avatar in response after verify
```

Test Google avatar sync:
```bash
# Open test-google-login.html
# Login with Google
# Check picture URL in response
# Change Google avatar
# Login again
# Check picture URL updated
```

## ?? Tips

1. **Cache avatars** in frontend ?? gi?m load
2. **Use fallback** v?i onerror handler
3. **Lazy load** avatars trong danh sách dài
4. **Thumbnail size** (200px) cho performance t?t
5. **CDN** cho static avatars n?u có

## ?? Important Notes

- Google avatars **expire** sau m?t th?i gian
- User login l?i ?? **refresh** avatar t? Google
- Generated avatars **không expire** (static URL)
- Picture column **nullable** (cho users c?)

## ?? Color Palette

Generated avatars s? d?ng 12 màu:

```
Blue    #007bff    Indigo  #6610f2
Purple  #6f42c1    Pink    #e83e8c
Red     #dc3545    Orange  #fd7e14
Yellow  #ffc107    Green   #28a745
Teal    #20c997    Cyan    #17a2b8
Dark    #343a40    Gray    #6c757d
```

Màu ???c ch?n based on hash c?a tên ? Same name = same color!