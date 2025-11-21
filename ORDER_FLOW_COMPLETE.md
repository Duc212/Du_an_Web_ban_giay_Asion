# 🛒 Luồng Đặt Hàng Hoàn Chỉnh - ASION Shop

## 📋 Tổng quan

Luồng đặt hàng từ khách chọn sản phẩm → thanh toán → admin xử lý → GHN giao hàng

---

## 🔄 Luồng chi tiết (10 bước)

### **Bước 1: Khách hàng duyệt và chọn sản phẩm**

**Frontend**: `WebUI/Pages/Shop.razor` hoặc `ProductDetail.razor`

```
1. Khách xem danh sách sản phẩm
2. Click vào sản phẩm → Chọn Size, Color
3. Click "Thêm vào giỏ hàng"
```

**API Call**: 
- `POST /api/Cart/AddToCart`
- Lưu vào Cart (session hoặc DB nếu đã login)

**Trạng thái**: 
- Cart có items ✅
- Order: Chưa tạo ❌

---

### **Bước 2: Xem giỏ hàng**

**Frontend**: `WebUI/Pages/Cart.razor`

```
1. Hiển thị danh sách sản phẩm trong giỏ
2. Khách có thể:
   - Thay đổi số lượng
   - Xóa sản phẩm
   - Áp dụng mã giảm giá
3. Click "Thanh toán"
```

**API Call**: 
- `GET /api/Cart/GetCart` - Lấy giỏ hàng
- `PUT /api/Cart/UpdateQuantity` - Cập nhật số lượng

**Trạng thái**: 
- Cart validated ✅
- Chuyển sang Checkout ▶️

---

### **Bước 3: Nhập thông tin giao hàng**

**Frontend**: `WebUI/Pages/Checkout.razor`

```csharp
// Form thông tin giao hàng
- Họ tên
- Email
- Số điện thoại
- Tỉnh/Thành phố
- Địa chỉ chi tiết
- Ghi chú (optional)
```

**Frontend Code**:
```csharp
public class ShippingInfo
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string City { get; set; }
    public string Address { get; set; }
    public string? Note { get; set; }
}
```

**Validation**:
- Tất cả fields bắt buộc (trừ Note)
- Phone: 10 số
- Email: format đúng

**Trạng thái**: 
- Shipping info validated ✅
- Sẵn sàng chọn payment ▶️

---

### **Bước 4: Chọn phương thức thanh toán**

**Frontend**: `WebUI/Pages/Checkout.razor`

**Payment Methods**:
1. **COD** (Cash on Delivery) - Thanh toán khi nhận hàng
2. **VNPay** - Ví điện tử VN
3. **PayPal** - Thanh toán quốc tế
4. **Google Pay** - Thanh toán Google

**Code**:
```csharp
<select @bind="SelectedPaymentMethod">
    <option value="1">COD - Thanh toán khi nhận hàng</option>
    <option value="2">VNPay</option>
    <option value="3">PayPal</option>
    <option value="4">Google Pay</option>
</select>
```

**Trạng thái**: 
- Payment method selected ✅
- Click "Đặt hàng" ▶️

---

### **Bước 5: Tạo đơn hàng**

**API**: `POST /api/Orders/CreateOrder`

**Backend**: `BUS/Services/OrderServices.cs`

**Request Body**:
```json
{
  "userId": 123,
  "voucherId": 5,
  "orderType": "Online",
  "address": "123 Đường ABC, Quận 1, TP.HCM",
  "note": "Giao giờ hành chính",
  "orderDetails": [
    {
      "variantId": 10,
      "quantity": 2
    }
  ],
  "paymentId": 1
}
```

**Backend Logic**:
```csharp
1. Tạo Order mới
   - OrderCode: "ORD-20241121-XXXX"
   - Status: 0 (Pending)
   - OrderDate: DateTime.Now
   
2. Tạo OrderDetails
   - Lưu từng sản phẩm
   - Trừ StockQuantity
   
3. Tính TotalAmount
   - Cộng giá các items
   - Trừ discount (nếu có voucher)
   
4. Tạo OrderPayment
   - Status: 0 (Unpaid) nếu COD
   - Status: 0 (Unpaid) nếu online payment (chờ redirect)
   
5. Lưu vào DB (Transaction)
```

**Response**:
```json
{
  "success": true,
  "message": "Tạo đơn hàng thành công",
  "data": 456  // OrderId
}
```

**Trạng thái**: 
- **Order created** ✅
- **Status**: Pending (0)
- **PaymentStatus**: Unpaid (0)
- **GhnOrderCode**: null (chưa gửi GHN)

---

### **Bước 6: Thanh toán (nếu online payment)**

#### **6a. Nếu chọn COD**
- Skip bước này
- PaymentStatus = Unpaid
- Chờ admin xác nhận

#### **6b. Nếu chọn VNPay/PayPal/Google Pay**

**API**: `POST /api/Payment/create-payment`

**Flow**:
```
1. Frontend gọi API create payment
   ↓
2. Backend tạo payment URL
   ↓
3. Redirect khách đến VNPay/PayPal
   ↓
4. Khách nhập thông tin thẻ
   ↓
5. VNPay/PayPal callback về API
   ↓
6. API verify payment
   ↓
7. Update OrderPayment status = Paid (1)
   ↓
8. Redirect khách về /payment-success?orderId=456
```

**Callback API**:
- `GET /api/Payment/vnpay-return`
- `GET /api/Payment/paypal-return`

**Update PaymentStatus**:
```csharp
// Sau khi verify thành công
orderPayment.Status = (int)PaymentStatus.Paid;
order.Status = (int)OrderStatusEnums.Pending; // Vẫn Pending, chờ admin xác nhận
```

**Trạng thái**: 
- **PaymentStatus**: Paid (1) ✅
- **Order Status**: Vẫn Pending (0)
- Chờ admin xác nhận ▶️

---

### **Bước 7: Admin xác nhận đơn hàng**

**Admin Panel**: `AdminWeb/Pages/Orders.razor`

**Admin actions**:
1. **Xem danh sách đơn Pending**
   - `GET /api/OrderAdmin/GetPendingOrders`
   
2. **Click chi tiết đơn hàng**
   - `GET /api/OrderAdmin/GetOrderDetail/{orderId}`
   - Hiển thị: Customer info, items, payment status
   
3. **Xác nhận đơn hàng**
   - Click nút "Xác nhận"
   - `POST /api/OrderAdmin/ConfirmOrder`

**API**: `POST /api/OrderAdmin/ConfirmOrder`

**Request Body**:
```json
{
  "orderId": 456,
  "shippingProvider": "GHN",
  "estimatedDelivery": "2024-12-25",
  "note": "Đơn hàng đã được xác nhận"
}
```

**Backend Logic**:
```csharp
1. Update Order Status = Confirmed (1)
2. Tạo Shipment record (nếu cần)
3. Gửi email xác nhận cho khách
```

**Trạng thái**: 
- **Order Status**: Confirmed (1) ✅
- Sẵn sàng gửi GHN ▶️

---

### **Bước 8: Gửi đơn lên GHN** 🚀

**Admin Panel**: `AdminWeb/Components/OrderDetailDialog.razor`

**Admin actions**:
1. Click nút **"Gửi đơn lên GHN"** (màu cam)
2. Frontend gọi API

**API**: `POST /api/shipping/create-ghn`

**Request Body**:
```json
{
  "orderId": 456,
  "paymentTypeId": 2,
  "note": "Giao giờ hành chính"
}
```

**Backend Logic** (`BUS/Services/GhnService.cs`):
```csharp
1. Lấy thông tin Order từ DB
   - Customer info
   - Order items
   - Địa chỉ giao hàng
   
2. Chuẩn bị payload GHN
   {
     "from_name": "ASION Store",
     "from_phone": "0123456789",
     "from_address": "Địa chỉ shop",
     "to_name": "Khách hàng",
     "to_phone": "0901234567",
     "to_address": "123 Đường ABC...",
     "cod_amount": 500000,
     "weight": 1000,
     "items": [...]
   }
   
3. Gọi GHN API
   POST https://dev-online-gateway.ghn.vn/shiip/public-api/v2/shipping-order/create
   Headers: Token, ShopId
   
4. GHN trả về
   {
     "code": 200,
     "data": {
       "order_code": "GHNA1B2C3",
       "total_fee": 35000,
       "expected_delivery_time": "2024-12-25"
     }
   }
   
5. Lưu vào DB
   - order.GhnOrderCode = "GHNA1B2C3"
   - order.GhnStatus = "pending"
   - order.GhnFee = 35000
   - order.GhnCreatedAt = DateTime.Now
   - order.Status = Shipping (3)
```

**Response**:
```json
{
  "success": true,
  "message": "Đã gửi đơn lên GHN thành công!",
  "ghnOrderCode": "GHNA1B2C3",
  "totalFee": 35000,
  "expectedDeliveryTime": "2024-12-25T00:00:00"
}
```

**Trạng thái**: 
- **Order Status**: Shipping (3) ✅
- **GhnOrderCode**: "GHNA1B2C3" ✅
- **GhnStatus**: "pending" (chờ shipper lấy)
- Đợi GHN webhook ▶️

---

### **Bước 9: GHN xử lý và giao hàng**

**GHN Process**:
```
1. Shipper đến lấy hàng
   → GHN webhook: status = "picking"
   
2. Đã lấy hàng, đang vận chuyển
   → GHN webhook: status = "delivering"
   
3. Đến kho gần khách
   → GHN webhook: status = "out_for_delivery"
   
4. Giao hàng thành công
   → GHN webhook: status = "delivered"
   → COD collected = true
```

**Webhook API**: `POST /api/webhook/ghn`

**Request từ GHN**:
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

**Backend Logic** (`API/Controllers/WebhookController.cs`):
```csharp
1. Verify webhook secret
   - Header: X-WEBHOOK-SECRET
   - Must match appsettings.json
   
2. Log raw payload
   
3. Tìm Order theo GhnOrderCode
   
4. Update Order
   - order.GhnStatus = "delivered"
   - order.CodCollected = true (nếu có CODTransferDate)
   - order.GhnUpdatedAt = DateTime.Now
   - order.Status = Delivered (4) (nếu delivered)
   
5. Gửi email thông báo cho khách
```

**Auto-update UI**:
- Admin refresh page → Thấy status mới
- Customer xem Orders → Thấy "Đã giao"

**Trạng thái**: 
- **Order Status**: Delivered (4) ✅
- **GhnStatus**: "delivered" ✅
- **CodCollected**: true ✅
- Hoàn tất ✅

---

### **Bước 10: Khách hàng theo dõi đơn hàng**

**Customer UI**: `WebUI/Pages/Orders.razor`

**API**: `GET /api/Orders/GetListOrderByUser`

**Hiển thị**:
```
┌─────────────────────────────────────┐
│ Mã đơn: ORD-20241121-0456          │
│ Trạng thái: Đã giao ✅              │
├─────────────────────────────────────┤
│ 📦 Vận chuyển GHN                   │
│ Mã vận đơn: GHNA1B2C3               │
│ Trạng thái: Đã giao ✅              │
│ Phí ship: 35,000₫                   │
│ COD: Đã thu ✅                      │
│ [Xem trên GHN]                      │
└─────────────────────────────────────┘
```

**Tracking realtime**:
- Click "Xem trên GHN" → Mở https://donhang.ghn.vn/?order_code=GHNA1B2C3
- Xem chi tiết lịch sử vận chuyển

---

## 📊 Bảng trạng thái Order

| Status | Value | Tên | Màu | Khi nào |
|--------|-------|-----|-----|---------|
| Pending | 0 | Chờ xử lý | 🟡 Yellow | Sau khi khách đặt hàng |
| Confirmed | 1 | Đã xác nhận | 🔵 Blue | Admin xác nhận |
| Processing | 2 | Đang chuẩn bị | 🟢 Cyan | Admin đóng gói |
| Shipping | 3 | Đang giao | 🟠 Orange | Đã gửi GHN |
| Delivered | 4 | Đã giao | ✅ Green | GHN giao thành công |
| Cancelled | 5 | Đã hủy | 🔴 Red | Khách/Admin hủy |
| Returned | 6 | Đã trả hàng | ⚫ Gray | Khách trả lại |

## 📊 Bảng trạng thái GHN

| GhnStatus | Tên | Icon | Khi nào |
|-----------|-----|------|---------|
| pending | Chờ lấy hàng | 🕒 | Vừa tạo đơn |
| picking | Đang lấy hàng | 📦 | Shipper đến lấy |
| delivering | Đang giao | 🚚 | Đang vận chuyển |
| delivered | Đã giao | ✅ | Giao thành công |
| return | Hoàn trả | ↩️ | Không giao được |
| cancel | Đã hủy | ❌ | Hủy đơn |

---

## 🔔 Notifications & Emails

### Email tự động gửi:

1. **Đặt hàng thành công** (Bước 5)
   - Tiêu đề: "Đơn hàng #ORD-XXX đã được tạo"
   - Nội dung: Thông tin đơn, tổng tiền, link theo dõi

2. **Xác nhận đơn hàng** (Bước 7)
   - Tiêu đề: "Đơn hàng #ORD-XXX đã được xác nhận"
   - Nội dung: Đơn đang được chuẩn bị

3. **Đã gửi GHN** (Bước 8)
   - Tiêu đề: "Đơn hàng #ORD-XXX đang được giao"
   - Nội dung: Mã vận đơn GHN, link tracking

4. **Giao hàng thành công** (Bước 9)
   - Tiêu đề: "Đơn hàng #ORD-XXX đã được giao"
   - Nội dung: Cảm ơn, yêu cầu review

---

## 🛠️ API Endpoints đầy đủ

### Customer APIs:
```
POST   /api/Cart/AddToCart
GET    /api/Cart/GetCart
PUT    /api/Cart/UpdateQuantity
DELETE /api/Cart/RemoveItem

POST   /api/Orders/CreateOrder
GET    /api/Orders/GetListOrderByUser
GET    /api/Orders/GetOrderDetail/{id}
POST   /api/Orders/UpdateStatusOrder

POST   /api/Payment/create-payment
GET    /api/Payment/vnpay-return
GET    /api/Payment/paypal-return
```

### Admin APIs:
```
GET    /api/OrderAdmin/GetAllOrders
GET    /api/OrderAdmin/GetPendingOrders
GET    /api/OrderAdmin/GetOrderDetail/{id}
POST   /api/OrderAdmin/ConfirmOrder
POST   /api/OrderAdmin/CancelOrder
PUT    /api/OrderAdmin/UpdateOrderStatus
PUT    /api/OrderAdmin/UpdateShippingInfo
```

### Shipping APIs:
```
POST   /api/shipping/create-ghn
GET    /api/shipping/{id}/tracking
POST   /api/shipping/calculate-fee
GET    /api/shipping/ghn-detail/{code}
```

### Webhook APIs:
```
POST   /api/webhook/ghn
GET    /api/webhook/ghn/test
```

---

## 🎯 Tính năng tự động

### 1. Auto-cancel order chưa thanh toán (Background Service)
```csharp
// OrderCancellationService.cs
- Chạy mỗi 1 giờ
- Tìm orders: Status = Pending && PaymentStatus = Unpaid && CreatedAt < 24h ago
- Auto cancel và restore stock
```

### 2. Auto-update từ GHN Webhook
```csharp
// WebhookController.cs
- Nhận callback từ GHN
- Verify secret
- Update order status tự động
- Không cần admin can thiệp
```

### 3. Auto-send email notifications
```csharp
// MailServices.cs
- Gửi email sau mỗi status change
- Template có sẵn
- Queue để không block request
```

---

## 🧪 Test Scenarios

### Scenario 1: Đặt hàng COD thành công
```
1. Khách thêm sản phẩm vào giỏ
2. Checkout → Nhập thông tin → Chọn COD
3. Đặt hàng thành công → Status = Pending
4. Admin xác nhận → Status = Confirmed
5. Admin gửi GHN → GhnOrderCode tạo
6. GHN giao thành công → Status = Delivered
7. COD đã thu → CodCollected = true
```

### Scenario 2: Thanh toán VNPay
```
1. Checkout → Chọn VNPay
2. Đặt hàng → Redirect VNPay
3. Thanh toán thành công → PaymentStatus = Paid
4. Admin xác nhận và gửi GHN
5. Giao hàng thành công
```

### Scenario 3: Hủy đơn
```
1. Khách đặt hàng → Status = Pending
2. Khách click "Hủy đơn" (nếu chưa xác nhận)
3. Status = Cancelled
4. Stock được restore
5. Nếu đã thanh toán → Hoàn tiền
```

---

## 📱 Mobile Responsive

Tất cả pages đều responsive:
- Checkout: Stack vertical trên mobile
- Orders list: Card layout
- Order detail: Collapsible sections

---

## 🔒 Security

1. **Authentication**: JWT token required cho user APIs
2. **Authorization**: Admin role required cho admin APIs
3. **Webhook verification**: X-WEBHOOK-SECRET header
4. **SQL Injection**: EF Core parameterized queries
5. **XSS**: Blazor auto-escape output

---

## 🚀 Performance

1. **Caching**: Cart cache trong memory
2. **Transaction**: Order creation trong transaction
3. **Background jobs**: Email sending không block
4. **Lazy loading**: Include() chỉ khi cần

---

## 📈 Monitoring

Cần monitor:
- Order creation rate
- Payment success rate
- GHN API response time
- Webhook processing time
- Email delivery rate

---

**Tác giả**: Senior .NET Dev Team  
**Version**: 1.0.0  
**Ngày tạo**: 21/11/2025
