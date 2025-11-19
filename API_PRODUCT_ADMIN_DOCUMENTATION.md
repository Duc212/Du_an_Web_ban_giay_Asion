# API QU?N LÝ PRODUCT - DOCUMENTATION

## ?? T?NG QUAN

API này ???c thi?t k? cho trang admin ?? qu?n lý s?n ph?m, variants (size/color/stock) và hình ?nh.

**Base URL:** `/api/ProductAdmin`

**Authorization:** T?t c? endpoint ??u yêu c?u Bearer Token (tr? Get Colors/Sizes/Genders)

---

## ?? PH?N 1: QU?N LÝ PRODUCT (CRUD)

### 1. GET `/GetAllProducts` - L?y danh sách s?n ph?m

**Query Parameters:**
```json
{
  "pageIndex": 1,           // Trang hi?n t?i (default: 1)
  "pageSize": 10,          // S? item/trang (default: 10)
  "keyword": "Nike",       // Tìm ki?m theo tên (optional)
  "categoryId": 1,         // L?c theo danh m?c (optional)
  "brandId": 1,            // L?c theo th??ng hi?u (optional)
  "sortBy": "name",        // name | createdat (optional)
  "sortOrder": "asc"       // asc | desc (optional)
}
```

**Response:**
```json
{
  "success": true,
  "message": "L?y danh sách s?n ph?m thành công",
  "data": [
    {
      "productID": 1,
      "name": "Nike Air Max 270",
      "description": "Giày th? thao...",
      "imageUrl": "https://...",
      "brandId": 1,
      "brandName": "Nike",
      "categoryId": 1,
      "categoryName": "Ch?y b?",
      "genderId": 3,
      "genderName": "Unisex",
      "totalStock": 150,
      "minPrice": 2890000,
      "maxPrice": 2890000,
      "variantCount": 12,
      "createdAt": "2024-01-01T00:00:00"
    }
  ],
  "totalRecords": 100
}
```

---

### 2. GET `/GetProductDetail/{productId}` - L?y chi ti?t s?n ph?m

**Response:**
```json
{
  "success": true,
  "message": "L?y chi ti?t s?n ph?m thành công",
  "data": {
    "productID": 1,
    "name": "Nike Air Max 270",
    "description": "...",
    "imageUrl": "https://...",
    "brandId": 1,
    "brandName": "Nike",
    "categoryId": 1,
    "categoryName": "Ch?y b?",
    "genderId": 3,
    "genderName": "Unisex",
    "createdAt": "2024-01-01T00:00:00",
    "variants": [
      {
        "variantID": 1,
        "colorID": 1,
        "colorName": "?en",
        "colorHex": "#000000",
        "sizeID": 5,
        "sizeValue": "40",
        "importPrice": 2023000,
        "sellingPrice": 2890000,
        "stockQuantity": 15,
        "status": "Active"
      }
    ],
    "images": [
      {
        "imageID": 1,
        "colorID": 1,
        "colorName": "?en",
        "imageUrl": "https://...",
        "displayOrder": 1,
        "imageType": "Main",
        "isDefault": true,
        "isActive": true
      }
    ]
  }
}
```

---

### 3. POST `/AddProduct` - Thêm s?n ph?m m?i

**Request Body:**
```json
{
  "name": "Nike Air Max 270 Black",
  "description": "Giày th? thao cao c?p...",
  "imageUrl": "https://...",
  "brandId": 1,
  "categoryId": 1,
  "genderId": 3,
  "variants": [
    {
      "colorID": 1,
      "sizeID": 5,
      "importPrice": 2023000,
      "sellingPrice": 2890000,
      "stockQuantity": 15
    },
    {
      "colorID": 1,
      "sizeID": 6,
      "importPrice": 2023000,
      "sellingPrice": 2890000,
      "stockQuantity": 20
    }
  ],
  "images": [
    {
      "colorID": 1,
      "imageUrl": "https://...",
      "displayOrder": 1,
      "imageType": "Main",
      "isDefault": true
    },
    {
      "colorID": 1,
      "imageUrl": "https://...",
      "displayOrder": 2,
      "imageType": "Side",
      "isDefault": false
    }
  ]
}
```

**Response:**
```json
{
  "success": true,
  "message": "Thêm s?n ph?m thành công",
  "data": true
}
```

---

### 4. PUT `/UpdateProduct` - C?p nh?t thông tin s?n ph?m

**Request Body:**
```json
{
  "productID": 1,
  "name": "Nike Air Max 270 Black",
  "description": "Giày th? thao cao c?p...",
  "imageUrl": "https://...",
  "brandId": 1,
  "categoryId": 1,
  "genderId": 3
}
```

**Response:**
```json
{
  "success": true,
  "message": "C?p nh?t s?n ph?m thành công",
  "data": true
}
```

---

### 5. DELETE `/DeleteProduct/{productId}` - Xóa s?n ph?m

**Response:**
```json
{
  "success": true,
  "message": "Xóa s?n ph?m thành công",
  "data": true
}
```

**L?u ý:** API này s? xóa luôn t?t c? variants và images c?a s?n ph?m.

---

## ?? PH?N 2: QU?N LÝ VARIANTS

### 6. GET `/GetProductVariants/{productId}` - L?y variants c?a s?n ph?m

**Response:**
```json
{
  "success": true,
  "message": "L?y danh sách variant thành công",
  "data": [
    {
      "variantID": 1,
      "colorID": 1,
      "colorName": "?en",
      "colorHex": "#000000",
      "sizeID": 5,
      "sizeValue": "40",
      "importPrice": 2023000,
      "sellingPrice": 2890000,
      "stockQuantity": 15,
      "status": "Active"
    }
  ]
}
```

---

### 7. POST `/AddVariant` - Thêm variant m?i

**Request Body:**
```json
{
  "productID": 1,
  "colorID": 2,
  "sizeID": 7,
  "importPrice": 2023000,
  "sellingPrice": 2890000,
  "stockQuantity": 25
}
```

**Response:**
```json
{
  "success": true,
  "message": "Thêm variant thành công",
  "data": true
}
```

---

### 8. PUT `/UpdateVariant` - C?p nh?t variant

**Request Body:**
```json
{
  "variantID": 1,
  "importPrice": 2100000,
  "sellingPrice": 3000000,
  "stockQuantity": 30,
  "status": "Active"
}
```

**Response:**
```json
{
  "success": true,
  "message": "C?p nh?t variant thành công",
  "data": true
}
```

---

### 9. DELETE `/DeleteVariant/{variantId}` - Xóa variant

**Response:**
```json
{
  "success": true,
  "message": "Xóa variant thành công",
  "data": true
}
```

---

### 10. PUT `/UpdateStock` - C?p nh?t t?n kho hàng lo?t

**Request Body:**
```json
{
  "items": [
    {
      "variantID": 1,
      "newStock": 50
    },
    {
      "variantID": 2,
      "newStock": 30
    },
    {
      "variantID": 3,
      "newStock": 20
    }
  ]
}
```

**Response:**
```json
{
  "success": true,
  "message": "C?p nh?t t?n kho thành công",
  "data": true
}
```

---

## ??? PH?N 3: API H? TR? (DROPDOWNS)

### 11. GET `/GetColors` - L?y danh sách màu

**Response:**
```json
{
  "success": true,
  "message": "L?y danh sách màu thành công",
  "data": [
    {
      "colorID": 1,
      "colorName": "?en",
      "hexColor": "#000000"
    },
    {
      "colorID": 2,
      "colorName": "Tr?ng",
      "hexColor": "#FFFFFF"
    }
  ]
}
```

---

### 12. GET `/GetSizes` - L?y danh sách size

**Response:**
```json
{
  "success": true,
  "message": "L?y danh sách size thành công",
  "data": [
    {
      "sizeID": 1,
      "value": "36"
    },
    {
      "sizeID": 2,
      "value": "37"
    }
  ]
}
```

---

### 13. GET `/GetGenders` - L?y danh sách gi?i tính

**Response:**
```json
{
  "success": true,
  "message": "L?y danh sách gi?i tính thành công",
  "data": [
    {
      "genderId": 1,
      "name": "Nam"
    },
    {
      "genderId": 2,
      "name": "N?"
    },
    {
      "genderId": 3,
      "name": "Unisex"
    }
  ]
}
```

---

## ?? PH?N 4: TH?NG KÊ

### 14. GET `/GetProductStatistics` - Th?ng kê s?n ph?m

**Response:**
```json
{
  "success": true,
  "message": "L?y th?ng kê thành công",
  "data": {
    "totalProducts": 100,
    "activeProducts": 85,
    "outOfStockProducts": 15,
    "lowStockProducts": 12,
    "totalInventoryValue": 500000000,
    "categoryStats": [
      {
        "categoryID": 1,
        "categoryName": "Ch?y b?",
        "productCount": 25,
        "totalStock": 500
      }
    ],
    "brandStats": [
      {
        "brandID": 1,
        "brandName": "Nike",
        "productCount": 30,
        "totalStock": 600
      }
    ]
  }
}
```

---

### 15. GET `/GetLowStockProducts` - S?n ph?m s?p h?t hàng

**Query Parameters:**
```json
{
  "pageIndex": 1,
  "pageSize": 10,
  "threshold": 10  // Ng??ng c?nh báo (default: 10)
}
```

**Response:** Gi?ng nh? `GetAllProducts` nh?ng ch? tr? v? s?n ph?m có t?n kho < threshold

---

## ?? AUTHENTICATION

T?t c? endpoint (tr? GetColors, GetSizes, GetGenders) yêu c?u Bearer Token:

```
Authorization: Bearer <your_token_here>
```

---

## ?? ERROR RESPONSES

T?t c? API ??u tr? v? format th?ng nh?t khi có l?i:

```json
{
  "success": false,
  "message": "L?i: <chi ti?t l?i>",
  "data": null
}
```

---

## ?? L?U Ý QUAN TR?NG

1. **Pagination:** PageIndex b?t ??u t? 1 (không ph?i 0)
2. **Soft Delete:** DeleteProduct s? xóa h?n product, variants và images
3. **Stock Management:** UpdateStock cho phép c?p nh?t nhi?u variants cùng lúc
4. **Variant Uniqueness:** M?i product không ???c có 2 variants gi?ng nhau (cùng color + size)
5. **Sorting:** sortBy h? tr? "name" và "createdat", sortOrder h? tr? "asc" và "desc"

---

## ?? USE CASES

### Use Case 1: Thêm s?n ph?m m?i hoàn ch?nh
1. G?i `GetColors`, `GetSizes`, `GetGenders` ?? l?y dropdown data
2. G?i `GetListCategory` và `GetLisBrand` t? ProductLandingController
3. T?o form thêm product v?i ??y ?? thông tin
4. G?i `AddProduct` v?i variants và images

### Use Case 2: Qu?n lý t?n kho
1. G?i `GetAllProducts` ?? xem danh sách
2. G?i `GetLowStockProducts` ?? xem s?n ph?m s?p h?t
3. G?i `GetProductVariants/{id}` ?? xem chi ti?t variants
4. G?i `UpdateStock` ?? c?p nh?t hàng lo?t

### Use Case 3: Xem th?ng kê
1. G?i `GetProductStatistics` ?? xem t?ng quan
2. G?i `GetLowStockProducts` ?? xem s?n ph?m c?n nh?p hàng

---

## ?? TESTING

S? d?ng Swagger UI ?? test: `https://localhost:<port>/swagger`

T?t c? API ?ã ???c document ??y ?? v?i XML comments trong code.
