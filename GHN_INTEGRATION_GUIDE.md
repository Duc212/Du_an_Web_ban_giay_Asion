# Tích hợp Giao Hàng Nhanh (GHN) - Hướng dẫn sử dụng

## 📋 Tổng quan

Hệ thống đã được tích hợp đầy đủ với Giao Hàng Nhanh (GHN) để tự động hóa quy trình vận chuyển. Admin có thể gửi đơn hàng lên GHN, theo dõi trạng thái, và tự động cập nhật qua webhook.

---

## 🔧 Cấu hình ban đầu

### 1. Cập nhật appsettings.json

Mở file `API/appsettings.json` và cập nhật thông tin GHN của bạn:

```json
{
  "GHN": {
    "BaseUrl": "https://dev-online-gateway.ghn.vn/shiip/public-api",
    "Token": "YOUR_GHN_API_TOKEN",
    "ShopId": "YOUR_GHN_SHOP_ID",
    "WebhookSecret": "YOUR_GHN_WEBHOOK_SECRET"
  }
}
```

**⚠️ QUAN TRỌNG:**
- **Token**: Lấy từ GHN Dashboard → Cài đặt → Token API
- **ShopId**: Lấy từ GHN Dashboard → Shop của tôi → ID Shop
- **WebhookSecret**: Tự tạo một chuỗi bí mật (VD: `MySecretKey123!@#`)

### 2. Cấu hình Webhook trên GHN

1. Đăng nhập GHN Dashboard: https://dev-online-gateway.ghn.vn/
2. Vào **Cài đặt** → **Webhook**
3. Nhập URL webhook của bạn: `https://yourdomain.com/api/webhook/ghn`
4. Nhập **WebhookSecret** giống trong appsettings.json
5. Chọn các sự kiện cần nhận:
   - Đơn hàng đã lấy
   - Đang giao hàng
   - Giao hàng thành công
   - Giao hàng thất bại
   - Đã thu COD

### 3. Chạy Migration

Mở terminal và chạy:

```bash
cd DAL
dotnet ef migrations add AddGhnFieldsToOrder --startup-project ../API
dotnet ef database update --startup-project ../API
```

---

## 🎯 Sử dụng từ Admin Panel

### Gửi đơn hàng lên GHN

1. Vào **Quản lý Đơn hàng**
2. Click vào đơn hàng cần gửi
3. Trong dialog chi tiết, tìm phần **"Giao Hàng Nhanh (GHN)"**
4. Click nút **"Gửi đơn lên GHN"**
5. Hệ thống sẽ:
   - Gửi thông tin đơn hàng lên GHN
   - Lưu mã đơn GHN vào database
   - Hiển thị mã tracking và phí ship

### Theo dõi trạng thái

Sau khi gửi đơn, bạn sẽ thấy:
- **Mã đơn GHN**: Tracking code của GHN
- **Trạng thái GHN**: `pending`, `picking`, `delivering`, `delivered`, `cancel`, `return`
- **Phí GHN**: Chi phí vận chuyển
- **COD đã thu**: Có/Không

### Làm mới trạng thái

- Click nút **"Làm mới trạng thái"** để lấy thông tin mới nhất từ GHN API
- Click **"Xem trên GHN"** để mở trang tracking của GHN

---

## 🔗 API Endpoints

### 1. Tạo đơn GHN

**POST** `/api/shipping/create-ghn`

**Headers:**
```
Authorization: Bearer {your_jwt_token}
```

**Request Body:**
```json
{
  "orderId": 123,
  "paymentTypeId": 2,
  "note": "Ghi chú đơn hàng"
}
```

**Response:**
```json
{
  "success": true,
  "message": "Đã gửi đơn lên GHN thành công!",
  "ghnOrderCode": "GHNA1B2C3",
  "totalFee": 35000,
  "expectedDeliveryTime": "2024-12-25T00:00:00"
}
```

### 2. Lấy thông tin tracking

**GET** `/api/shipping/{orderId}/tracking`

**Response:**
```json
{
  "orderId": 123,
  "orderCode": "ORD-2024-001",
  "ghnOrderCode": "GHNA1B2C3",
  "ghnStatus": "delivering",
  "ghnStatusText": "Đang giao hàng",
  "ghnFee": 35000,
  "codCollected": false,
  "expectedDeliveryTime": "2024-12-25T00:00:00",
  "lastUpdated": "2024-12-24T10:30:00"
}
```

### 3. Webhook từ GHN

**POST** `/api/webhook/ghn`

**Headers:**
```
X-WEBHOOK-SECRET: YOUR_GHN_WEBHOOK_SECRET
```

**Payload mẫu:**
```json
{
  "OrderCode": "GHNA1B2C3",
  "Status": "delivered",
  "CODAmount": 500000,
  "CODTransferDate": "2024-12-25",
  "Fee": 35000,
  "Time": "2024-12-25T14:30:00"
}
```

---

## 📊 Database Schema

Các field được thêm vào bảng `Orders`:

| Field | Type | Description |
|-------|------|-------------|
| `GhnOrderCode` | nvarchar(50) | Mã đơn hàng GHN |
| `GhnStatus` | nvarchar(50) | Trạng thái GHN (pending, delivering, delivered...) |
| `CodCollected` | bit | COD đã được thu chưa |
| `GhnFee` | int | Phí vận chuyển GHN (VNĐ) |
| `GhnCreatedAt` | datetime2 | Thời gian tạo đơn trên GHN |
| `GhnUpdatedAt` | datetime2 | Thời gian cập nhật trạng thái GHN |

---

## 🚨 Xử lý lỗi thường gặp

### Lỗi: "Invalid Token"
- **Nguyên nhân**: Token GHN không đúng hoặc hết hạn
- **Giải pháp**: Lấy token mới từ GHN Dashboard

### Lỗi: "Shop not found"
- **Nguyên nhân**: ShopId không đúng
- **Giải pháp**: Kiểm tra lại ShopId trong GHN Dashboard

### Lỗi: "Invalid webhook secret"
- **Nguyên nhân**: WebhookSecret không khớp
- **Giải pháp**: Đảm bảo secret trong appsettings.json giống với GHN Dashboard

### Lỗi: "Order already sent to GHN"
- **Nguyên nhân**: Đơn hàng đã được gửi lên GHN trước đó
- **Giải pháp**: Không thể gửi lại, chỉ có thể theo dõi trạng thái

---

## 🔐 Bảo mật

1. **Không commit appsettings.json** có chứa Token thật lên Git
2. **Sử dụng appsettings.Production.json** cho môi trường production
3. **Webhook Secret** phải đủ phức tạp (ít nhất 16 ký tự)
4. **Chỉ admin** mới được gửi đơn lên GHN (có `[BAuthorize]`)

---

## 📝 Logging

Tất cả request/response GHN đều được log:

```csharp
// API/appsettings.json
{
  "Logging": {
    "LogLevel": {
      "BUS.Services.GhnService": "Information",
      "API.Controllers.WebhookController": "Information"
    }
  }
}
```

Xem log tại: `API/logs/` hoặc Console khi chạy debug.

---

## 🔄 Cập nhật khi deploy Production

Khi deploy lên môi trường thực:

1. **Đổi BaseUrl** từ `dev-online-gateway` → `online-gateway`:
   ```json
   "BaseUrl": "https://online-gateway.ghn.vn/shiip/public-api"
   ```

2. **Cập nhật Token và ShopId** của shop production

3. **Cập nhật Webhook URL** trên GHN Dashboard

4. **Cập nhật thông tin shop** trong `GhnService.cs` (line ~81):
   ```csharp
   FromName = request.FromName ?? "ASION Store",
   FromPhone = request.FromPhone ?? "0123456789",
   FromAddress = request.FromAddress ?? "Địa chỉ shop thật"
   ```

---

## 🧪 Testing

### Test Webhook với Postman

1. **POST** `https://localhost:7134/api/webhook/ghn`
2. **Headers:**
   ```
   X-WEBHOOK-SECRET: YOUR_GHN_WEBHOOK_SECRET
   Content-Type: application/json
   ```
3. **Body:**
   ```json
   {
     "OrderCode": "GHNA1B2C3",
     "Status": "delivered",
     "CODAmount": 500000,
     "CODTransferDate": "2024-12-25"
   }
   ```

### Test tạo đơn (Mock)

Nếu chưa có Token GHN thật, bạn có thể mock response trong `GhnService.cs` để test UI.

---

## 📞 Hỗ trợ

- **GHN Docs**: https://api.ghn.vn/home/docs/
- **GHN Hotline**: 1900 9247
- **GHN Dashboard**: https://dev-online-gateway.ghn.vn/

---

## ✅ Checklist triển khai

- [ ] Cập nhật GHN Token, ShopId, WebhookSecret
- [ ] Chạy migration database
- [ ] Cấu hình webhook trên GHN Dashboard
- [ ] Test gửi đơn từ Admin Panel
- [ ] Test webhook với Postman
- [ ] Cập nhật thông tin shop (FromName, FromPhone, FromAddress)
- [ ] Deploy và test trên production

---

**Phiên bản**: 1.0  
**Ngày cập nhật**: 2024-12-21  
**Tác giả**: Senior .NET Dev Team
