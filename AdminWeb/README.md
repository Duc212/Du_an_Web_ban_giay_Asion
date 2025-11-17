# AdminWeb - Blazor with Argon Dashboard Template

Dự án AdminWeb đã được chuyển đổi từ template HTML Argon Dashboard sang Blazor WebAssembly.

## Những gì đã thực hiện

### 1. Copy Assets
- Đã copy toàn bộ CSS, JS, fonts, và images từ `CodeMau/build/assets` sang `wwwroot/assets`
- Bao gồm:
  - Argon Dashboard Tailwind CSS
  - Nucleo Icons
  - Font Awesome Icons
  - Perfect Scrollbar
  - Chart.js
  - Các hình ảnh và logo

### 2. Tạo Components
Đã tạo các Blazor component tái sử dụng:

#### `Components/Sidebar.razor`
- Menu điều hướng bên trái
- Sử dụng NavLink để tự động highlight trang đang active
- Responsive cho mobile

#### `Components/Navbar.razor`
- Thanh navigation phía trên
- Có breadcrumb và search bar
- Thông báo dropdown

### 3. Cập nhật Layout
#### `Layout/MainLayout.razor`
- Sử dụng Argon Dashboard layout structure
- Tích hợp Sidebar và Navbar components
- Responsive design

### 4. Tạo Pages
Đã chuyển đổi các trang HTML sang Blazor:

#### `Pages/Home.razor` (Dashboard)
- 4 statistics cards (Today's Money, Users, Clients, Sales)
- Sales overview chart
- Image carousel
- Sales by Country table
- Categories list

#### `Pages/Tables.razor`
- Authors table với dữ liệu động
- Projects table với progress bars
- Sử dụng C# classes cho data models

#### `Pages/Billing.razor`, `Pages/Profile.razor`, `Pages/SignIn.razor`
- Các trang placeholder sẵn sàng để phát triển

### 5. Cập nhật Configuration
#### `wwwroot/index.html`
- Thêm Argon Dashboard CSS và JS
- Thêm Font Awesome
- Thêm Nucleo Icons
- Thêm Perfect Scrollbar và Chart.js

#### `_Imports.razor`
- Thêm `@using AdminWeb.Components`

## Cấu trúc Project

```
AdminWeb/
├── Components/
│   ├── Navbar.razor
│   └── Sidebar.razor
├── Layout/
│   ├── MainLayout.razor
│   ├── MainLayout.razor.css
│   └── NavMenu.razor (cũ - có thể xóa)
├── Pages/
│   ├── Home.razor (Dashboard)
│   ├── Tables.razor
│   ├── Billing.razor
│   ├── Profile.razor
│   └── SignIn.razor
├── wwwroot/
│   ├── assets/
│   │   ├── css/
│   │   ├── js/
│   │   ├── img/
│   │   └── fonts/
│   └── index.html
├── _Imports.razor
├── App.razor
└── Program.cs
```

## Chạy Project

1. Mở project trong Visual Studio hoặc VS Code
2. Build project:
   ```bash
   dotnet build
   ```
3. Chạy project:
   ```bash
   dotnet run
   ```
4. Truy cập: `https://localhost:5001` hoặc `http://localhost:5000`

## Navigation Routes

- `/` - Dashboard (Home)
- `/tables` - Tables
- `/billing` - Billing
- `/profile` - Profile
- `/sign-in` - Sign In

## Tính năng

✅ Responsive design (desktop, tablet, mobile)
✅ Dark mode support (đã có CSS, cần thêm toggle logic)
✅ Blazor routing với NavLink
✅ Component-based architecture
✅ Tailwind CSS styling
✅ Icons: Font Awesome + Nucleo Icons
✅ Charts với Chart.js
✅ Smooth animations và transitions

## Phát triển tiếp

### Cần thêm:
1. **Authentication**: Implement sign-in/sign-up logic
2. **API Integration**: Kết nối với backend API
3. **Data Management**: Thay thế dữ liệu mẫu bằng dữ liệu thực
4. **Dark Mode Toggle**: Thêm nút chuyển đổi dark/light mode
5. **Charts**: Implement chart functionality với Chart.js
6. **Carousel**: Thêm logic cho image carousel
7. **State Management**: Sử dụng Blazor state management hoặc Fluxor
8. **More Pages**: Thêm các trang còn lại (Virtual Reality, RTL, Sign Up)

## Credits

- **Template**: Argon Dashboard 2 Tailwind by Creative Tim
- **Framework**: Blazor WebAssembly (.NET 8)
- **CSS Framework**: Tailwind CSS
- **Icons**: Font Awesome + Nucleo Icons
