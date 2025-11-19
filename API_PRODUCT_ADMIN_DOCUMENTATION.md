# API QU?N L� PRODUCT - DOCUMENTATION

## ?? T?NG QUAN

API n�y ???c thi?t k? cho trang admin ?? qu?n l� s?n ph?m, variants (size/color/stock) v� h�nh ?nh.

**Base URL:** `/api/ProductAdmin`

**Authorization:** T?t c? endpoint ??u y�u c?u Bearer Token (tr? Get Colors/Sizes/Genders)

---

## ?? PH?N 1: QU?N L� PRODUCT (CRUD)

### 1. GET `/GetAllProducts` - L?y danh s�ch s?n ph?m

**Query Parameters:**
```json
{
  "pageIndex": 1,           // Trang hi?n t?i (default: 1)
  "pageSize": 10,          // S? item/trang (default: 10)
  "keyword": "Nike",       // T�m ki?m theo t�n (optional)
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
  "message": "L?y danh s�ch s?n ph?m th�nh c�ng",
  "data": [
    {
      "productID": 1,
      "name": "Nike Air Max 270",
      "description": "Gi�y th? thao...",
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
  "message": "L?y chi ti?t s?n ph?m th�nh c�ng",
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

### 3. POST `/AddProduct` - Th�m s?n ph?m m?i

**Request Body:**
```json
{
  "name": "Nike Air Max 270 Black",
  "description": "Gi�y th? thao cao c?p...",
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
  "message": "Th�m s?n ph?m th�nh c�ng",
  "data": true
}
```

---

### 4. PUT `/UpdateProduct` - C?p nh?t th�ng tin s?n ph?m

**Request Body:**
```json
{
  "productID": 1,
  "name": "Nike Air Max 270 Black",
  "description": "Gi�y th? thao cao c?p...",
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
  "message": "C?p nh?t s?n ph?m th�nh c�ng",
  "data": true
}
```

---

### 5. DELETE `/DeleteProduct/{productId}` - X�a s?n ph?m

**Response:**
```json
{
  "success": true,
  "message": "X�a s?n ph?m th�nh c�ng",
  "data": true
}
```

**L?u �:** API n�y s? x�a lu�n t?t c? variants v� images c?a s?n ph?m.

---

## ?? PH?N 2: QU?N L� VARIANTS

### 6. GET `/GetProductVariants/{productId}` - L?y variants c?a s?n ph?m

**Response:**
```json
{
  "success": true,
  "message": "L?y danh s�ch variant th�nh c�ng",
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

### 7. POST `/AddVariant` - Th�m variant m?i

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
  "message": "Th�m variant th�nh c�ng",
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
  "message": "C?p nh?t variant th�nh c�ng",
  "data": true
}
```

---

### 9. DELETE `/DeleteVariant/{variantId}` - X�a variant

**Response:**
```json
{
  "success": true,
  "message": "X�a variant th�nh c�ng",
  "data": true
}
```

---

### 10. PUT `/UpdateStock` - C?p nh?t t?n kho h�ng lo?t

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
  "message": "C?p nh?t t?n kho th�nh c�ng",
  "data": true
}
```

---

## ??? PH?N 3: API H? TR? (DROPDOWNS)

### 11. GET `/GetColors` - L?y danh s�ch m�u

**Response:**
```json
{
  "success": true,
  "message": "L?y danh s�ch m�u th�nh c�ng",
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

### 12. GET `/GetSizes` - L?y danh s�ch size

**Response:**
```json
{
  "success": true,
  "message": "L?y danh s�ch size th�nh c�ng",
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

### 13. GET `/GetGenders` - L?y danh s�ch gi?i t�nh

**Response:**
```json
{
  "success": true,
  "message": "L?y danh s�ch gi?i t�nh th�nh c�ng",
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

## ?? PH?N 4: TH?NG K�

### 14. GET `/GetProductStatistics` - Th?ng k� s?n ph?m

**Response:**
```json
{
  "success": true,
  "message": "L?y th?ng k� th�nh c�ng",
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

### 15. GET `/GetLowStockProducts` - S?n ph?m s?p h?t h�ng

**Query Parameters:**
```json
{
  "pageIndex": 1,
  "pageSize": 10,
  "threshold": 10  // Ng??ng c?nh b�o (default: 10)
}
```

**Response:** Gi?ng nh? `GetAllProducts` nh?ng ch? tr? v? s?n ph?m c� t?n kho < threshold

---

## ?? AUTHENTICATION

T?t c? endpoint (tr? GetColors, GetSizes, GetGenders) y�u c?u Bearer Token:

```
Authorization: Bearer <your_token_here>
```

---

## ?? ERROR RESPONSES

T?t c? API ??u tr? v? format th?ng nh?t khi c� l?i:

```json
{
  "success": false,
  "message": "L?i: <chi ti?t l?i>",
  "data": null
}
```

---

## ?? L?U � QUAN TR?NG

1. **Pagination:** PageIndex b?t ??u t? 1 (kh�ng ph?i 0)
2. **Soft Delete:** DeleteProduct s? x�a h?n product, variants v� images
3. **Stock Management:** UpdateStock cho ph�p c?p nh?t nhi?u variants c�ng l�c
4. **Variant Uniqueness:** M?i product kh�ng ???c c� 2 variants gi?ng nhau (c�ng color + size)
5. **Sorting:** sortBy h? tr? "name" v� "createdat", sortOrder h? tr? "asc" v� "desc"

---

## ?? USE CASES

### Use Case 1: Th�m s?n ph?m m?i ho�n ch?nh
1. G?i `GetColors`, `GetSizes`, `GetGenders` ?? l?y dropdown data
2. G?i `GetListCategory` v� `GetLisBrand` t? ProductLandingController
3. T?o form th�m product v?i ??y ?? th�ng tin
4. G?i `AddProduct` v?i variants v� images

### Use Case 2: Qu?n l� t?n kho
1. G?i `GetAllProducts` ?? xem danh s�ch
2. G?i `GetLowStockProducts` ?? xem s?n ph?m s?p h?t
3. G?i `GetProductVariants/{id}` ?? xem chi ti?t variants
4. G?i `UpdateStock` ?? c?p nh?t h�ng lo?t

### Use Case 3: Xem th?ng k�
1. G?i `GetProductStatistics` ?? xem t?ng quan
2. G?i `GetLowStockProducts` ?? xem s?n ph?m c?n nh?p h�ng

---

## ?? TESTING

S? d?ng Swagger UI ?? test: `https://localhost:<port>/swagger`

T?t c? API ?� ???c document ??y ?? v?i XML comments trong code.
