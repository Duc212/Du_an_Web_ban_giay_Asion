# API TH?NG KÊ ??N HÀNG - H??NG D?N S? D?NG

## ?? Endpoint: GET `/api/Orders/GetOrderStatistics`

API này cung c?p th?ng kê t?ng quan v? ??n hàng trong m?t kho?ng th?i gian.

---

## ?? Authorization

**Required:** Bearer Token

```
Authorization: Bearer <your_access_token>
```

---

## ?? Request Parameters

| Parameter | Type | Required | Default | Description |
|-----------|------|----------|---------|-------------|
| `fromDate` | DateTime | No | 1 tháng tr??c | Ngày b?t ??u th?ng kê (YYYY-MM-DD) |
| `toDate` | DateTime | No | Hôm nay | Ngày k?t thúc th?ng kê (YYYY-MM-DD) |

### Example Request

```http
GET /api/Orders/GetOrderStatistics?fromDate=2024-01-01&toDate=2024-01-31
Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...
```

---

## ? Response Success

**Status Code:** 200 OK

```json
{
  "success": true,
  "message": "L?y th?ng kê ??n hàng thành công",
  "data": {
    "totalOrders": 250,
    "pendingOrders": 15,
    "confirmedOrders": 35,
    "shippingOrders": 40,
    "deliveredOrders": 145,
    "cancelledOrders": 15,
    "totalRevenue": 345000000,
    "averageOrderValue": 2379310,
    
    "paymentStats": {
      "cod": {
        "count": 120,
        "total": 180000000
      },
      "vnpay": {
        "count": 80,
        "total": 130000000
      },
      "gpay": {
        "count": 30,
        "total": 25000000
      },
      "paypal": {
        "count": 15,
        "total": 10000000
      }
    },
    
    "dailyOrders": [
      {
        "date": "2024-01-01T00:00:00",
        "orderCount": 8,
        "revenue": 12500000
      },
      {
        "date": "2024-01-02T00:00:00",
        "orderCount": 12,
        "revenue": 18000000
      },
      {
        "date": "2024-01-03T00:00:00",
        "orderCount": 10,
        "revenue": 15500000
      }
    ],
    
    "topProducts": [
      {
        "productID": 10,
        "productName": "Nike Air Max 270",
        "orderCount": 45,
        "totalQuantity": 78,
        "revenue": 80920000
      },
      {
        "productID": 15,
        "productName": "Adidas Ultraboost 22",
        "orderCount": 38,
        "totalQuantity": 65,
        "revenue": 72450000
      },
      {
        "productID": 7,
        "productName": "Converse Chuck Taylor",
        "orderCount": 52,
        "totalQuantity": 95,
        "revenue": 65000000
      }
    ]
  }
}
```

---

## ?? Response Data Structure

### Main Statistics

| Field | Type | Description |
|-------|------|-------------|
| `totalOrders` | int | T?ng s? ??n hàng trong kho?ng th?i gian |
| `pendingOrders` | int | S? ??n hàng ch? xác nh?n (Status = 0) |
| `confirmedOrders` | int | S? ??n hàng ?ã xác nh?n (Status = 1) |
| `shippingOrders` | int | S? ??n hàng ?ang giao (Status = 3) |
| `deliveredOrders` | int | S? ??n hàng ?ã giao thành công (Status = 4) |
| `cancelledOrders` | int | S? ??n hàng ?ã h?y (Status = 5) |
| `totalRevenue` | decimal | T?ng doanh thu (ch? tính ??n Delivered) |
| `averageOrderValue` | decimal | Giá tr? trung bình m?i ??n hàng |

### Payment Statistics

Th?ng kê theo ph??ng th?c thanh toán (ch? tính ??n hàng ?ã giao):

```json
{
  "cod": {
    "count": 120,     // S? ??n thanh toán COD
    "total": 180000000 // T?ng ti?n COD
  },
  "vnpay": {
    "count": 80,
    "total": 130000000
  },
  "gpay": {
    "count": 30,
    "total": 25000000
  },
  "paypal": {
    "count": 15,
    "total": 10000000
  }
}
```

### Daily Orders

Th?ng kê theo ngày (ch? tính ??n ?ã giao):

```json
[
  {
    "date": "2024-01-01T00:00:00",
    "orderCount": 8,        // S? ??n trong ngày
    "revenue": 12500000     // Doanh thu trong ngày
  }
]
```

### Top Products

Top 10 s?n ph?m bán ch?y nh?t (x?p theo doanh thu):

```json
[
  {
    "productID": 10,
    "productName": "Nike Air Max 270",
    "orderCount": 45,           // S? ??n hàng có s?n ph?m này
    "totalQuantity": 78,        // T?ng s? l??ng bán ra
    "revenue": 80920000         // T?ng doanh thu t? s?n ph?m
  }
]
```

---

## ? Error Responses

### 401 Unauthorized

```json
{
  "success": false,
  "message": "Unauthorized: Token không h?p l? ho?c ?ã h?t h?n.",
  "data": null
}
```

### 500 Internal Server Error

```json
{
  "success": false,
  "message": "L?i khi l?y th?ng kê: <chi ti?t l?i>",
  "data": null
}
```

---

## ?? Business Logic

### Quy t?c tính toán:

1. **T?ng ??n hàng (totalOrders):**
   - ??m T?T C? ??n hàng trong kho?ng th?i gian
   - Bao g?m c? ??n h?y

2. **Doanh thu (totalRevenue):**
   - CH? tính ??n hàng có status = Delivered (4)
   - Không tính ??n Pending, Cancelled, Returned

3. **Giá tr? trung bình (averageOrderValue):**
   - = totalRevenue / deliveredOrders
   - N?u không có ??n delivered ? return 0

4. **Payment Statistics:**
   - CH? tính ??n hàng ?ã giao (Delivered)
   - Nhóm theo PaymentMethod t? b?ng Payment

5. **Daily Orders:**
   - CH? tính ??n ?ã giao
   - Group by Date (không tính gi?)
   - S?p x?p t?ng d?n theo ngày

6. **Top Products:**
   - Tính d?a trên OrderDetail
   - Top 10 s?n ph?m có revenue cao nh?t
   - Revenue = SUM(Quantity × SellingPrice)

---

## ?? Use Cases

### Use Case 1: Dashboard Admin - T?ng quan hôm nay

```http
GET /api/Orders/GetOrderStatistics
```

Không truy?n tham s? ? t? ??ng l?y th?ng kê 30 ngày g?n nh?t

---

### Use Case 2: Báo cáo tháng

```http
GET /api/Orders/GetOrderStatistics?fromDate=2024-01-01&toDate=2024-01-31
```

Th?ng kê tháng 1/2024

---

### Use Case 3: So sánh quý

**Quý 1:**
```http
GET /api/Orders/GetOrderStatistics?fromDate=2024-01-01&toDate=2024-03-31
```

**Quý 2:**
```http
GET /api/Orders/GetOrderStatistics?fromDate=2024-04-01&toDate=2024-06-30
```

---

### Use Case 4: Báo cáo tu?n

```http
GET /api/Orders/GetOrderStatistics?fromDate=2024-01-08&toDate=2024-01-14
```

---

## ?? Tips & Best Practices

### 1. Date Range Optimization
- Không nên query quá nhi?u tháng (> 12 tháng) ? performance issue
- Nên chia nh? báo cáo theo tháng/quý

### 2. Caching
- K?t qu? có th? cache 15-30 phút cho cùng date range
- Implement server-side caching n?u c?n

### 3. Export Data
- S? d?ng k?t qu? ?? xu?t Excel/PDF
- `dailyOrders` ? Chart d?ng line
- `paymentStats` ? Chart d?ng pie
- `topProducts` ? Table/Bar chart

### 4. Frontend Display

**T?ng quan:**
```
???????????????????????????????????????????
? T?ng ??n hàng: 250                      ?
? Doanh thu: 345,000,000?                 ?
? Giá tr? TB: 2,379,310?                  ?
???????????????????????????????????????????

Tr?ng thái:
- Ch? xác nh?n: 15 ??n
- ?ã xác nh?n: 35 ??n  
- ?ang giao: 40 ??n
- ?ã giao: 145 ??n
- ?ã h?y: 15 ??n
```

**Payment Methods (Pie Chart):**
```
COD: 52% (180M)
VNPAY: 38% (130M)
GPAY: 7% (25M)
PAYPAL: 3% (10M)
```

**Daily Revenue (Line Chart):**
```
Doanh thu theo ngày
?
?     ?
?   ?   ?
? ?       ?
??????????????? Ngày
```

---

## ?? Testing

### Swagger UI
```
https://localhost:5001/swagger
```

### Postman Collection
Import endpoint:
```
GET {{baseUrl}}/api/Orders/GetOrderStatistics?fromDate={{fromDate}}&toDate={{toDate}}
Headers:
  Authorization: Bearer {{token}}
```

### Sample cURL
```bash
curl -X GET "https://localhost:5001/api/Orders/GetOrderStatistics?fromDate=2024-01-01&toDate=2024-01-31" \
  -H "Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
```

---

## ?? Performance Notes

- Query ???c optimize v?i AsNoTrackingQueryable()
- Ch? load data c?n thi?t (không load navigation properties không dùng)
- Top Products limit 10 ?? tránh quá t?i
- Daily Orders ?ã group by date ?? gi?m s? record

**Estimated Response Time:**
- < 1,000 orders: ~200-500ms
- 1,000 - 10,000 orders: ~500ms - 2s
- > 10,000 orders: ~2-5s

---

## ?? Future Enhancements

Có th? m? r?ng thêm:
1. Filter theo category/brand
2. Compare v?i period tr??c ?ó (% change)
3. Th?ng kê theo khu v?c ??a lý
4. Customer statistics (new vs returning)
5. Refund/Return statistics
6. Hourly breakdown
7. Conversion rate
