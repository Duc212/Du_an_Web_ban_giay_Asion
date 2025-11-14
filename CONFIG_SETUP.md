# Asion - Shoe E-commerce Project

## Configuration Setup

### API Configuration

1. Copy `API/appsettings.example.json` to `API/appsettings.json`
2. Update the following settings with your actual values:

#### Database Connection
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=YOUR_DATABASE;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

#### JWT Settings
```json
"Jwt": {
  "Secret": "YOUR_JWT_SECRET_KEY_HERE_MINIMUM_32_CHARACTERS"
}
```

#### Encryption
```json
"EncryptionSettings": {
  "SecretKey": "YOUR_ENCRYPTION_SECRET_KEY"
}
```

#### Google OAuth (Optional)
```json
"Google": {
  "ClientId": "YOUR_GOOGLE_CLIENT_ID",
  "ClientSecret": "YOUR_GOOGLE_CLIENT_SECRET"
}
```

#### VNPay Payment Gateway
```json
"VNPay": {
  "TmnCode": "YOUR_VNPAY_TMN_CODE",
  "HashSecret": "YOUR_VNPAY_HASH_SECRET"
}
```

#### Stripe Payment Gateway
```json
"Stripe": {
  "SecretKey": "YOUR_STRIPE_SECRET_KEY",
  "PublishableKey": "YOUR_STRIPE_PUBLISHABLE_KEY"
}
```

#### PayPal Payment Gateway
```json
"PayPal": {
  "ClientId": "YOUR_PAYPAL_CLIENT_ID",
  "ClientSecret": "YOUR_PAYPAL_CLIENT_SECRET"
}
```

### WebUI Configuration

1. Copy `WebUI/wwwroot/appsettings.example.json` to `WebUI/wwwroot/appsettings.json`
2. Update Google OAuth and Stripe settings if needed:

```json
"Stripe": {
  "PublishableKey": "pk_test_YOUR_PUBLISHABLE_KEY"
}
```

## Security Notes

?? **IMPORTANT**: Never commit `appsettings.json` files containing real credentials to Git!

The `.gitignore` file is configured to exclude:
- `appsettings.json`
- `appsettings.Development.json`
- `appsettings.Production.json`

Only `appsettings.example.json` files should be committed.

## Getting Started

1. Clone the repository
2. Set up configuration files as described above
3. Run database migrations
4. Start the API project
5. Start the WebUI project

## Projects in Solution

- **API**: ASP.NET Core Web API (.NET 8)
- **WebUI**: Blazor WebAssembly
- **AdminWeb**: Blazor WebAssembly (Admin Panel)
- **BUS**: Business Logic Layer
- **DAL**: Data Access Layer
- **Helper**: Utility and Helper Classes
