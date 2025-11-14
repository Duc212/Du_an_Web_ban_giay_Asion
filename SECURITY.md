# ?? Security Best Practices - Asion Project

## ?? Sensitive Information That Should NEVER Be Committed

### 1. **API Keys & Secrets (Backend - API)**
Located in `API/appsettings.json`:

```json
{
  "Jwt": {
    "Secret": "YOUR_JWT_SECRET_KEY_HERE_MINIMUM_32_CHARACTERS"
  },
  "EncryptionSettings": {
    "SecretKey": "YOUR_ENCRYPTION_SECRET_KEY"
  },
  "VNPay": {
    "TmnCode": "YOUR_VNPAY_TMN_CODE",
    "HashSecret": "YOUR_VNPAY_HASH_SECRET"
  },
  "Stripe": {
    "SecretKey": "sk_test_xxxxx" // ? NEVER expose to client
  },
  "PayPal": {
    "ClientId": "xxxxx",
    "ClientSecret": "xxxxx" // ? NEVER expose to client
  },
  "Google": {
    "ClientSecret": "xxxxx" // ? NEVER expose to client
  }
}
```

### 2. **Publishable Keys (Frontend - WebUI)**
Located in `WebUI/wwwroot/appsettings.json`:

```json
{
  "Stripe": {
    "PublishableKey": "pk_test_xxxxx" // ?? Safe to use in browser, but should be in config
  },
  "Google": {
    "ClientId": "xxxxx.apps.googleusercontent.com" // ?? Safe but should be in config
  }
}
```

**Why config is better than hardcoding:**
- ? Easy to rotate keys without changing code
- ? Different keys for dev/staging/production
- ? Team members can use their own test keys

### 3. **Database Connection Strings**
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=DATN_NAM;Trusted_Connection=True;" // ? Contains sensitive info
  }
}
```

## ?? Files Protected by .gitignore

```gitignore
# Sensitive configuration files - DO NOT COMMIT
appsettings.json
appsettings.Development.json
appsettings.Production.json
**/appsettings.json
**/appsettings.*.json
!**/appsettings.example.json

# Environment files
.env
.env.local
.env.*.local
```

## ? What's Safe to Commit

1. **Example configuration files** (`*.example.json`)
2. **Public keys** (already in example files)
3. **URLs** (API endpoints, OAuth URLs)
4. **Non-sensitive constants** (timeouts, page sizes, etc.)

## ?? Key Types & Their Security Level

| Key Type | Location | Security | Can Commit? |
|----------|----------|----------|-------------|
| JWT Secret | Backend | ?? Critical | ? Never |
| Encryption Key | Backend | ?? Critical | ? Never |
| Stripe Secret Key | Backend | ?? Critical | ? Never |
| Stripe Publishable Key | Frontend | ?? Medium | ?? Config only |
| PayPal Client Secret | Backend | ?? Critical | ? Never |
| PayPal Client ID | Backend | ?? Medium | ?? Config only |
| VNPay Hash Secret | Backend | ?? Critical | ? Never |
| Google Client Secret | Backend | ?? Critical | ? Never |
| Google Client ID | Frontend | ?? Low | ?? Config only |

## ??? Additional Security Recommendations

### 1. **Use Environment Variables (Production)**
Instead of `appsettings.json` in production:

```bash
export JWT_SECRET="your-production-secret"
export STRIPE_SECRET_KEY="sk_live_xxxxx"
```

### 2. **Key Rotation Schedule**
- ?? **JWT Secret**: Every 90 days
- ?? **API Keys**: When compromised or annually
- ?? **Database Passwords**: Every 6 months

### 3. **Access Control**
- Only senior developers should have production keys
- Use separate keys for each environment
- Never share keys via email/chat

### 4. **Monitoring**
- Enable API key usage alerts
- Monitor for suspicious payment activity
- Set up rate limiting

## ?? If a Key is Compromised

### Immediate Actions:
1. **Revoke the key** immediately in the provider's dashboard
2. **Generate a new key**
3. **Update all instances** (dev, staging, production)
4. **Notify the team**
5. **Review access logs** for suspicious activity

### For Git History:
If a key was accidentally committed:

```bash
# Use BFG Repo-Cleaner or git-filter-branch
git filter-branch --force --index-filter \
  "git rm --cached --ignore-unmatch API/appsettings.json" \
  --prune-empty --tag-name-filter cat -- --all

# Force push (?? requires coordination with team)
git push origin --force --all
```

## ?? Resources

- [OWASP API Security Top 10](https://owasp.org/www-project-api-security/)
- [Stripe Security Best Practices](https://stripe.com/docs/security/best-practices)
- [PayPal API Security](https://developer.paypal.com/api/rest/security/)
- [JWT Best Practices](https://tools.ietf.org/html/rfc8725)

## ?? Quick Security Checklist

Before pushing code:

- [ ] No `appsettings.json` files committed
- [ ] All sensitive keys in `.example.json` are placeholders
- [ ] `.gitignore` includes all sensitive file patterns
- [ ] No hardcoded keys in `.razor`, `.cs`, or `.js` files
- [ ] Database connection strings are not committed
- [ ] Review `git diff` before commit

---

**Remember**: It's easier to prevent a security incident than to clean up after one! ??
