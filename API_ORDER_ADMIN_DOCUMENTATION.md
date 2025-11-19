# API QU?N LÝ ORDER - DOCUMENTATION

## ?? T?NG QUAN

API này ???c thi?t k? cho trang admin ?? qu?n lý ??n hàng, t? xem danh sách, chi ti?t, c?p nh?t tr?ng thái ??n th?ng kê.

**Base URL:** `/api/OrderAdmin`

**Authorization:** T?t c? endpoint ??u yêu c?u Bearer Token

---

## ?? PH?N 1: QU?N LÝ ??N HÀNG

### 1. GET `/GetAllOrders` - L?y danh sách ??n hàng (Admin)

**Query Parameters:**
```json
{
  "pageIndex": 1,               // Trang hi?n t?i (default: 1)
  "pageSize": 20,              // S? item/trang (default: 20)
  "keyword": "Nguy?n",         // Tìm theo tên KH ho?c mã ??n (optional)
  "status": 0,                 // L?c theo tr?ng thái (optional)
  "paymentStatus": 1,          // L?c theo tr?ng thái thanh toán (optional)
  "paymentMethod": 1,          // L?c theo ph??ng th?c thanh toán (optional)
  "fromDate": "2024-01-01",    // T? ngày (optional)
  "toDate": "2024-12-31",      // ??n ngày (optional)
  "sortBy": "orderDate",       // orderDate | totalAmount | status (optional)
  "sortOrder": "desc"          // asc | desc (optional)
}
```

**Order Status Enum:**
- 0: Pending (Ch? xác nh?n)
- 1: Confirmed (?ã xác nh?n)
- 2: Processing (?ang x? lý)
- 3: Shipping (?ang giao)
- 4: Delivered (?ã giao)
- 5: Cancelled (?ã h?y)
- 6: Returned (?ã tr? hàng)

**Payment Status Enum:**
- 0: Unpaid (Ch?a thanh toán)
- 1: Paid (?ã thanh toán)
- 2: Refunded (?ã hoàn ti?n)
- 3: Failed (Th?t b?i)

**Payment Method Enum:**
- 1: COD (Thanh toán khi nh?n hàng)
- 2: VNPAY
- 3: GPAY
- 4: PAYPAL

**Response:**
```json
{
  "success": true,
  "message": "L?y danh sách ??n hàng thành công",
  "data": [
    {
      "orderID": 1,
      "orderCode": "ORD-ABC123",
      "customerName": "Nguy?n V?n A",
      "customerPhone": "0901234567",
      "customerEmail": "nguyenvana@gmail.com",
      "totalAmount": 5890000,
      "status": 0,
      "statusText": "Ch? xác nh?n",
      "paymentMethod": 1,
      "paymentMethodText": "COD",
      "paymentStatus": 0,
      "paymentStatusText": "Ch?a thanh toán",
      "orderDate": "2024-01-15T10:30:00",
      "itemCount": 3,
      "shippingAddress": "123 ???ng ABC, Qu?n 1, TP.HCM"
    }
  ],
  "totalRecords": 150
}
```

---

### 2. GET `/GetOrderDetail/{orderId}` - L?y chi ti?t ??n hàng

**Response:**
```json
{
  "success": true,
  "message": "L?y chi ti?t ??n hàng thành công",
  "data": {
    "orderID": 1,
    "orderCode": "ORD-ABC123",
    "orderDate": "2024-01-15T10:30:00",
    "status": 0,
    "statusText": "Ch? xác nh?n",
    "statusHistory": [
      {
        "status": 0,
        "statusText": "Ch? xác nh?n",
        "changedAt": "2024-01-15T10:30:00",
        "note": "??n hàng m?i ???c t?o"
      }
    ],
    
    "customer": {
      "userID": 5,
      "fullName": "Nguy?n V?n A",
      "username": "nguyenvana",
      "email": "nguyenvana@gmail.com",
      "phone": "0901234567"
    },
    
    "shippingInfo": {
      "receiverName": "Nguy?n V?n A",
      "receiverPhone": "0901234567",
      "address": "123 ???ng ABC",
      "ward": "Ph??ng 1",
      "district": "Qu?n 1",
      "city": "TP. H? Chí Minh",
      "fullAddress": "123 ???ng ABC, Ph??ng 1, Qu?n 1, TP. H? Chí Minh",
      "note": "Giao gi? hành chính"
    },
    
    "payment": {
      "paymentMethod": 1,
      "paymentMethodText": "COD",
      "paymentStatus": 0,
      "paymentStatusText": "Ch?a thanh toán",
      "paidAt": null
    },
    
    "shipment": {
      "shippingProvider": "Giao Hàng Nhanh",
      "trackingNumber": "GHN123456789",
      "shippedDate": null,
      "estimatedDelivery": "2024-01-20T00:00:00",
      "deliveryStatus": 0
    },
    
    "voucher": {
      "voucherCode": "NEWYEAR2024",
      "discountValue": 100000
    },
    
    "items": [
      {
        "orderDetailID": 1,
        "productID": 10,
        "productName": "Nike Air Max 270",
        "brandName": "Nike",
        "imageUrl": "https://...",
        "colorName": "?en",
        "sizeName": "42",
        "quantity": 2,
        "unitPrice": 2890000,
        "subtotal": 5780000
      },
      {
        "orderDetailID": 2,
        "productID": 15,
        "productName": "Adidas Ultraboost",
        "brandName": "Adidas",
        "imageUrl": "https://...",
        "colorName": "Tr?ng",
        "sizeName": "40",
        "quantity": 1,
        "unitPrice": 3450000,
        "subtotal": 3450000
      }
    ],
    
    "summary": {
      "subtotal": 9230000,
      "shippingFee": 30000,
      "discount": 100000,
      "totalAmount": 9160000
    },
    
    "note": "Khách hàng yêu c?u g?i tr??c khi giao"
  }
}
```

---

### 3. PUT `/UpdateOrderStatus` - C?p nh?t tr?ng thái ??n hàng

**Request Body:**
```json
{
  "orderID": 1,
  "newStatus": 1,           // OrderStatusEnums
  "note": "?ã xác nh?n ??n hàng"
}
```

**Business Rules:**
- Pending ? Confirmed ? Processing ? Shipping ? Delivered
- Có th? Cancel t? Pending, Confirmed
- Có th? Return t? Delivered (trong 7 ngày)
- Không th? thay ??i t? Delivered, Cancelled

**Response:**
```json
{
  "success": true,
  "message": "C?p nh?t tr?ng thái ??n hàng thành công",
  "data": true
}
```

---

### 4. POST `/ConfirmOrder` - Xác nh?n ??n hàng

Shortcut ?? chuy?n t? Pending ? Confirmed và t?o shipment

**Request Body:**
```json
{
  "orderID": 1,
  "shippingProvider": "Giao Hàng Nhanh",
  "estimatedDelivery": "2024-01-20",
  "note": "Giao trong 3-5 ngày"
}
```

**Response:**
```json
{
  "success": true,
  "message": "Xác nh?n ??n hàng thành công",
  "data": {
    "trackingNumber": "GHN123456789"
  }
}
```

---

### 5. POST `/CancelOrder` - H?y ??n hàng

**Request Body:**
```json
{
  "orderID": 1,
  "cancelReason": "Khách hàng yêu c?u h?y",
  "refundRequired": true
}
```

**Response:**
```json
{
  "success": true,
  "message": "H?y ??n hàng thành công",
  "data": true
}
```

---

### 6. PUT `/UpdatePaymentStatus` - C?p nh?t tr?ng thái thanh toán

**Request Body:**
```json
{
  "orderID": 1,
  "paymentStatus": 1,      // PaymentStatus enum
  "note": "?ã nh?n ti?n COD"
}
```

**Response:**
```json
{
  "success": true,
  "message": "C?p nh?t tr?ng thái thanh toán thành công",
  "data": true
}
```

---

### 7. PUT `/UpdateShippingInfo` - C?p nh?t thông tin v?n chuy?n

**Request Body:**
```json
{
  "orderID": 1,
  "shippingProvider": "Giao Hàng Ti?t Ki?m",
  "trackingNumber": "GHTK987654321",
  "shippedDate": "2024-01-16T14:00:00",
  "estimatedDelivery": "2024-01-20T00:00:00",
  "note": "?ã chuy?n cho ??n v? v?n chuy?n"
}
```

**Response:**
```json
{
  "success": true,
  "message": "C?p nh?t thông tin v?n chuy?n thành công",
  "data": true
}
```

---

## ?? PH?N 2: TH?NG KÊ & BÁO CÁO

### 8. GET `/GetOrderStatistics` - Th?ng kê t?ng quan ??n hàng

**Query Parameters:**
```json
{
  "fromDate": "2024-01-01",    // optional
  "toDate": "2024-12-31"       // optional
}
```

**Response:**
```json
{
  "success": true,
  "message": "L?y th?ng kê ??n hàng thành công",
  "data": {
    "totalOrders": 1250,
    "pendingOrders": 45,
    "confirmedOrders": 120,
    "shippingOrders": 85,
    "deliveredOrders": 950,
    "cancelledOrders": 50,
    
    "totalRevenue": 345000000,
    "averageOrderValue": 276000,
    
    "paymentStats": {
      "cod": {
        "count": 800,
        "total": 220000000
      },
      "vnpay": {
        "count": 350,
        "total": 105000000
      },
      "gpay": {
        "count": 100,
        "total": 20000000
      }
    },
    
    "dailyOrders": [
      {
        "date": "2024-01-15",
        "orderCount": 45,
        "revenue": 12500000
      }
    ],
    
    "topProducts": [
      {
        "productID": 10,
        "productName": "Nike Air Max 270",
        "orderCount": 150,
        "totalQuantity": 280,
        "revenue": 80920000
      }
    ]
  }
}
```

---

### 9. GET `/GetRevenueReport` - Báo cáo doanh thu

**Query Parameters:**
```json
{
  "fromDate": "2024-01-01",
  "toDate": "2024-01-31",
  "groupBy": "day"           // day | week | month
}
```

**Response:**
```json
{
  "success": true,
  "message": "L?y báo cáo doanh thu thành công",
  "data": {
    "totalRevenue": 45000000,
    "totalOrders": 163,
    "averageOrderValue": 276000,
    "details": [
      {
        "period": "2024-01-15",
        "orderCount": 12,
        "revenue": 3312000,
        "paidOrders": 10,
        "unpaidOrders": 2
      }
    ]
  }
}
```

---

### 10. GET `/GetOrdersByStatus` - ??n hàng theo tr?ng thái

**Query Parameters:**
```json
{
  "status": 0,              // OrderStatusEnums
  "pageIndex": 1,
  "pageSize": 20
}
```

**Response:** Gi?ng nh? `GetAllOrders` nh?ng ?ã filter theo status

---

### 11. GET `/GetPendingOrders` - ??n hàng ch? x? lý (Shortcut)

L?y nhanh các ??n hàng Pending ?? admin x? lý

**Response:**
```json
{
  "success": true,
  "message": "L?y danh sách ??n hàng ch? x? lý thành công",
  "data": [
    {
      "orderID": 1,
      "orderCode": "ORD-ABC123",
      "customerName": "Nguy?n V?n A",
      "totalAmount": 5890000,
      "orderDate": "2024-01-15T10:30:00",
      "waitingTime": "2 gi? 30 phút",
      "priority": "high"      // high | normal | low
    }
  ],
  "totalRecords": 45
}
```

---

## ?? PH?N 3: TÌM KI?M & L?C

### 12. GET `/SearchOrders` - Tìm ki?m ??n hàng

**Query Parameters:**
```json
{
  "query": "ORD-ABC",       // Tìm theo mã ??n, tên KH, S?T, email
  "pageIndex": 1,
  "pageSize": 20
}
```

**Response:** Gi?ng format `GetAllOrders`

---

### 13. GET `/GetOrdersByCustomer/{customerId}` - L?ch s? ??n hàng c?a khách

**Response:**
```json
{
  "success": true,
  "message": "L?y l?ch s? ??n hàng thành công",
  "data": {
    "customer": {
      "userID": 5,
      "fullName": "Nguy?n V?n A",
      "email": "nguyenvana@gmail.com",
      "phone": "0901234567",
      "totalOrders": 8,
      "totalSpent": 23000000
    },
    "orders": [
      {
        "orderID": 1,
        "orderCode": "ORD-ABC123",
        "orderDate": "2024-01-15T10:30:00",
        "status": 4,
        "totalAmount": 5890000
      }
    ]
  },
  "totalRecords": 8
}
```

---

## ?? PH?N 4: TI?N ÍCH

### 14. GET `/GetOrderTimeline/{orderId}` - L?ch s? thay ??i tr?ng thái

**Response:**
```json
{
  "success": true,
  "message": "L?y timeline ??n hàng thành công",
  "data": [
    {
      "status": 0,
      "statusText": "Ch? xác nh?n",
      "timestamp": "2024-01-15T10:30:00",
      "note": "??n hàng m?i ???c t?o",
      "updatedBy": "System"
    },
    {
      "status": 1,
      "statusText": "?ã xác nh?n",
      "timestamp": "2024-01-15T14:00:00",
      "note": "Admin ?ã xác nh?n ??n hàng",
      "updatedBy": "admin@example.com"
    }
  ]
}
```

---

### 15. POST `/BulkUpdateStatus` - C?p nh?t tr?ng thái hàng lo?t

**Request Body:**
```json
{
  "orderIDs": [1, 2, 3, 5],
  "newStatus": 1,
  "note": "Xác nh?n hàng lo?t"
}
```

**Response:**
```json
{
  "success": true,
  "message": "C?p nh?t 4 ??n hàng thành công",
  "data": {
    "successCount": 4,
    "failedCount": 0,
    "details": [
      {
        "orderID": 1,
        "success": true
      }
    ]
  }
}
```

---

### 16. POST `/ExportOrders` - Xu?t danh sách ??n hàng (Excel/CSV)

**Request Body:**
```json
{
  "fromDate": "2024-01-01",
  "toDate": "2024-01-31",
  "status": null,           // optional filter
  "format": "excel"         // excel | csv
}
```

**Response:**
```json
{
  "success": true,
  "message": "Xu?t file thành công",
  "data": {
    "fileUrl": "https://.../orders_2024-01.xlsx",
    "fileName": "orders_2024-01.xlsx",
    "recordCount": 163
  }
}
```

---

### 17. POST `/SendNotification` - G?i thông báo cho khách hàng

**Request Body:**
```json
{
  "orderID": 1,
  "type": "status_update",  // status_update | shipping_update | general
  "channel": "email",       // email | sms | both
  "customMessage": "??n hàng c?a b?n ?ang ???c giao..."
}
```

**Response:**
```json
{
  "success": true,
  "message": "G?i thông báo thành công",
  "data": true
}
```

---

### 18. GET `/GetOrderSummary/{orderId}` - Tóm t?t ??n hàng (In hóa ??n)

Format ??n gi?n ?? in hóa ??n

**Response:**
```json
{
  "success": true,
  "data": {
    "orderCode": "ORD-ABC123",
    "orderDate": "15/01/2024 10:30",
    "customer": "Nguy?n V?n A - 0901234567",
    "shippingAddress": "123 ???ng ABC, Q1, TP.HCM",
    "items": [
      {
        "name": "Nike Air Max 270 (?en - 42)",
        "quantity": 2,
        "price": "2,890,000?",
        "total": "5,780,000?"
      }
    ],
    "subtotal": "9,230,000?",
    "shippingFee": "30,000?",
    "discount": "-100,000?",
    "totalAmount": "9,160,000?",
    "paymentMethod": "COD",
    "status": "Ch? xác nh?n"
  }
}
```

---

## ?? AUTHENTICATION

T?t c? endpoint yêu c?u Bearer Token:

```
Authorization: Bearer <your_token_here>
```

**Permissions:**
- Admin: Toàn quy?n
- Staff: Ch? xem và c?p nh?t tr?ng thái (không xóa)

---

## ?? ERROR RESPONSES

```json
{
  "success": false,
  "message": "L?i: <chi ti?t l?i>",
  "data": null
}
```

**Common Errors:**
- 400: Invalid request (status không h?p l?, missing fields)
- 401: Unauthorized (token invalid/expired)
- 403: Forbidden (không ?? quy?n)
- 404: Order not found
- 409: Conflict (không th? chuy?n tr?ng thái)

---

## ?? BUSINESS RULES

### Quy trình x? lý ??n hàng:
1. **Pending** (Ch? xác nh?n)
   - Admin xem và xác nh?n ??n
   - Có th? h?y
   
2. **Confirmed** (?ã xác nh?n)
   - T? ??ng t?o shipment
   - Chu?n b? hàng
   - Có th? h?y (c?n lý do)
   
3. **Processing** (?ang x? lý)
   - ?óng gói hàng
   - Không th? h?y
   
4. **Shipping** (?ang giao)
   - ?ã bàn giao cho ??n v? v?n chuy?n
   - Có tracking number
   - Không th? h?y
   
5. **Delivered** (?ã giao)
   - Khách ?ã nh?n hàng
   - Có th? yêu c?u tr? hàng (7 ngày)
   - N?u COD: C?p nh?t payment status = Paid
   
6. **Cancelled** (?ã h?y)
   - Tr? l?i stock
   - N?u ?ã thanh toán: X? lý hoàn ti?n
   
7. **Returned** (?ã tr? hàng)
   - T? Delivered
   - Hoàn ti?n cho khách

### Stock Management:
- Tr? stock khi ??n hàng Confirmed
- Tr? l?i stock khi Cancel ho?c Return

### Payment:
- COD: Payment status = Paid khi order status = Delivered
- Online: Payment status = Paid ngay sau khi thanh toán thành công

---

## ?? USE CASES

### Use Case 1: X? lý ??n hàng m?i
1. G?i `GetPendingOrders` ?? xem ??n ch?
2. G?i `GetOrderDetail/{id}` ?? xem chi ti?t
3. G?i `ConfirmOrder` ?? xác nh?n
4. System t? ??ng t?o shipment và tr? stock

### Use Case 2: Theo dõi ??n hàng
1. G?i `GetAllOrders` v?i filter theo tr?ng thái
2. G?i `UpdateOrderStatus` khi có thay ??i
3. G?i `SendNotification` ?? thông báo khách hàng

### Use Case 3: Xem th?ng kê
1. G?i `GetOrderStatistics` ?? xem t?ng quan
2. G?i `GetRevenueReport` ?? xem doanh thu chi ti?t

---

## ?? TESTING

S? d?ng Swagger UI: `https://localhost:<port>/swagger`
