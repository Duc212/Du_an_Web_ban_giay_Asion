# Hướng Dẫn Quản Lý Màu Sắc và Kích Cỡ - Asion Shop Admin

## 📋 Tổng Quan

Tài liệu này mô tả chi tiết về chức năng quản lý **Màu sắc (Colors)** và **Kích cỡ (Sizes)** trong hệ thống Admin của Asion Shop.

---

## 🏗️ Kiến Trúc

### Backend (API)

#### 1. DTOs (Data Transfer Objects)

**Colors:**
- `DAL/DTOs/Colors/Req/AddColorReq.cs` - Request thêm màu
- `DAL/DTOs/Colors/Req/UpdateColorReq.cs` - Request cập nhật màu
- `DAL/DTOs/Colors/Res/GetColorRes.cs` - Response màu sắc

**Sizes:**
- `DAL/DTOs/Sizes/Req/AddSizeReq.cs` - Request thêm size
- `DAL/DTOs/Sizes/Req/UpdateSizeReq.cs` - Request cập nhật size
- `DAL/DTOs/Sizes/Res/GetSizeRes.cs` - Response size

#### 2. Services (Business Logic)

**Colors:**
- `BUS/Services/Interfaces/IColorService.cs` - Interface
- `BUS/Services/ColorService.cs` - Implementation

**Sizes:**
- `BUS/Services/Interfaces/ISizeService.cs` - Interface
- `BUS/Services/SizeService.cs` - Implementation

**Chức năng:**
- ✅ Lấy danh sách tất cả
- ✅ Lấy theo ID
- ✅ Thêm mới (với validation)
- ✅ Cập nhật (với validation)
- ✅ Xóa (kiểm tra ràng buộc với sản phẩm)

#### 3. API Controllers

**Colors:**
- `API/Controllers/ColorController.cs`
- Base URL: `https://localhost:7134/api/Color`

**Sizes:**
- `API/Controllers/SizeController.cs`
- Base URL: `https://localhost:7134/api/Size`

**Endpoints:**

```
GET    /GetAllColors          - Lấy tất cả màu sắc
GET    /GetColorById/{id}     - Lấy màu theo ID
POST   /AddColor              - Thêm màu mới (Auth required)
PUT    /UpdateColor           - Cập nhật màu (Auth required)
DELETE /DeleteColor/{id}      - Xóa màu (Auth required)

GET    /GetAllSizes           - Lấy tất cả size
GET    /GetSizeById/{id}      - Lấy size theo ID
POST   /AddSize               - Thêm size mới (Auth required)
PUT    /UpdateSize            - Cập nhật size (Auth required)
DELETE /DeleteSize/{id}       - Xóa size (Auth required)
```

---

### Frontend (AdminWeb)

#### 1. Models

- `AdminWeb/Models/ColorDTOs.cs` - DTOs cho Colors
- `AdminWeb/Models/SizeDTOs.cs` - DTOs cho Sizes

#### 2. Services

- `AdminWeb/Services/ColorService.cs` - HTTP client cho Color API
- `AdminWeb/Services/SizeService.cs` - HTTP client cho Size API

#### 3. Pages

- `AdminWeb/Pages/Colors.razor` - Trang quản lý màu sắc
- `AdminWeb/Pages/Sizes.razor` - Trang quản lý kích cỡ

#### 4. Navigation

- `AdminWeb/Components/Sidebar.razor` - Menu sidebar (đã thêm Colors và Sizes)

---

## 🎨 Tính Năng Colors (Màu Sắc)

### Validation Rules

**Tên màu:**
- Bắt buộc
- Tối đa 50 ký tự
- Không được trùng (case-insensitive)

**Mã Hex:**
- Bắt buộc
- Format: `#RRGGBB` hoặc `#RGB`
- Regex: `^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$`
- Không được trùng

### UI Features

✅ **Danh sách màu:**
- Hiển thị preview màu (color box)
- Tên màu
- Mã Hex
- Số lượng sản phẩm sử dụng màu

✅ **Form thêm/sửa:**
- Input text cho tên màu
- Color picker (HTML5 `<input type="color">`)
- Input text cho mã Hex
- Preview màu real-time

✅ **Xóa màu:**
- Kiểm tra ràng buộc với sản phẩm
- Cảnh báo nếu màu đang được sử dụng
- Confirm dialog

---

## 📏 Tính Năng Sizes (Kích Cỡ)

### Validation Rules

**Giá trị size:**
- Bắt buộc
- Tối đa 10 ký tự
- Không được trùng (case-insensitive)

### UI Features

✅ **Danh sách size:**
- Hiển thị badge size với gradient
- Số lượng sản phẩm sử dụng size

✅ **Form thêm/sửa:**
- Input text cho giá trị size
- Preview size badge

✅ **Xóa size:**
- Kiểm tra ràng buộc với sản phẩm
- Cảnh báo nếu size đang được sử dụng
- Confirm dialog

---

## 🔧 Cấu Hình

### 1. Đăng ký Services trong API/Program.cs

```csharp
builder.Services.AddTransient<IColorService, ColorService>();
builder.Services.AddTransient<ISizeService, SizeService>();
```

### 2. Đăng ký Services trong AdminWeb/Program.cs

```csharp
builder.Services.AddHttpClient<ColorService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7134/");
})
.AddHttpMessageHandler<AuthorizationMessageHandler>();

builder.Services.AddHttpClient<SizeService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7134/");
})
.AddHttpMessageHandler<AuthorizationMessageHandler>();
```

---

## 🚀 Cách Sử Dụng

### 1. Quản Lý Màu Sắc

**Thêm màu mới:**
1. Vào trang `/colors`
2. Click nút "Thêm màu sắc"
3. Nhập tên màu (ví dụ: "Xanh Navy")
4. Chọn màu từ color picker hoặc nhập mã Hex (ví dụ: `#001F3F`)
5. Xem preview
6. Click "Lưu"

**Sửa màu:**
1. Click nút "Sửa" trên hàng màu cần sửa
2. Chỉnh sửa thông tin
3. Click "Lưu"

**Xóa màu:**
1. Click nút "Xóa" trên hàng màu cần xóa
2. Xác nhận xóa
3. Nếu màu đang được sử dụng, hệ thống sẽ cảnh báo

### 2. Quản Lý Kích Cỡ

**Thêm size mới:**
1. Vào trang `/sizes`
2. Click nút "Thêm kích cỡ"
3. Nhập giá trị size (ví dụ: "46", "47")
4. Xem preview
5. Click "Lưu"

**Sửa size:**
1. Click nút "Sửa" trên hàng size cần sửa
2. Chỉnh sửa giá trị
3. Click "Lưu"

**Xóa size:**
1. Click nút "Xóa" trên hàng size cần xóa
2. Xác nhận xóa
3. Nếu size đang được sử dụng, hệ thống sẽ cảnh báo

---

## 📊 Database Schema

### Colors Table
```sql
CREATE TABLE Colors (
    ColorID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(50) NOT NULL,
    HexCode NVARCHAR(7) NOT NULL
)
```

### Sizes Table
```sql
CREATE TABLE Sizes (
    SizeID INT PRIMARY KEY IDENTITY(1,1),
    Value NVARCHAR(10) NOT NULL
)
```

### Relationships
- `ProductVariants.ColorID` → `Colors.ColorID`
- `ProductVariants.SizeID` → `Sizes.SizeID`

---

## 🔒 Security

- Tất cả endpoints thêm/sửa/xóa đều yêu cầu **JWT Authentication**
- Sử dụng `[BAuthorize]` attribute
- Token được tự động thêm vào header bởi `AuthorizationMessageHandler`

---

## 🎯 Best Practices

### Backend
✅ Validation ở cả DTO và Service layer
✅ Kiểm tra ràng buộc trước khi xóa
✅ Trả về message rõ ràng cho từng trường hợp
✅ Sử dụng async/await
✅ Error handling đầy đủ

### Frontend
✅ Loading states
✅ Toast notifications
✅ Confirm dialogs cho hành động nguy hiểm
✅ Real-time preview
✅ Responsive design
✅ Accessibility (aria-labels)

---

## 🐛 Troubleshooting

### Lỗi thường gặp:

**1. "Không thể xóa màu/size đang được sử dụng"**
- Nguyên nhân: Có sản phẩm đang sử dụng màu/size này
- Giải pháp: Xóa hoặc cập nhật các sản phẩm liên quan trước

**2. "Tên màu/size đã tồn tại"**
- Nguyên nhân: Trùng tên với màu/size khác
- Giải pháp: Sử dụng tên khác

**3. "Mã màu hex không hợp lệ"**
- Nguyên nhân: Format mã Hex sai
- Giải pháp: Sử dụng format `#RRGGBB` (ví dụ: `#FF0000`)

---

## 📝 TODO / Future Enhancements

- [ ] Bulk import Colors/Sizes từ CSV/Excel
- [ ] Export danh sách ra Excel
- [ ] Sorting và advanced filtering
- [ ] Color palette suggestions
- [ ] Size chart management
- [ ] Audit log (lịch sử thay đổi)
- [ ] Soft delete thay vì hard delete

---

## 📞 Support

Nếu có vấn đề, vui lòng liên hệ team phát triển hoặc tạo issue trên repository.

---

**Version:** 1.0.0  
**Last Updated:** 2025-11-28  
**Author:** Asion Shop Development Team
