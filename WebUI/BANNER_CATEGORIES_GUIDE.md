# 🎨 MainBanner & CategoriesBar - Hướng Dẫn

## ✨ Đã Thêm Mới

### 1. **MainBanner Component** - Hero Banner Chính
Banner hero đẹp mắt với gradient background, animations và visual cards.

### 2. **CategoriesBar Component** - Danh Mục Dễ Dùng  
Categories bar với grid layout hiện đại, icons rõ ràng và interactive.

---

## 🎯 MainBanner Component

### Đặc Điểm

✅ **Gradient Background** - Tím/xanh bắt mắt  
✅ **Badge với Pulse Animation** - "Hot Deals" với chấm đỏ nhấp nháy  
✅ **Typography Lớn** - Tiêu đề 56px với gradient text  
✅ **CTA Button** - "Mua Sắm Ngay" với hover effect  
✅ **Statistics Display** - Hiển thị 1000+ sản phẩm, 50+ thương hiệu  
✅ **Floating Cards** - 3 cards với icons (Sale, Shipping, Quality)  
✅ **Fully Responsive** - Tự động điều chỉnh trên mobile/tablet  

### Visual Cards

1. **💰 Flash Sale** - Giảm -50%
2. **🚚 Free Ship** - Đơn hàng 500K+
3. **⭐ Chính hãng** - 100% authentic

### Animations

- `float` - Background gradient movement
- `floatCard` - Cards floating effect  
- `pulse` - Badge pulse animation

---

## 🗂️ CategoriesBar Component

### Đặc Điểm

✅ **6 Categories Mặc Định** - Running, Basketball, Lifestyle, Football, Gym, Kids  
✅ **Grid Layout** - Auto-fit responsive grid  
✅ **Icon + Name + Count** - Hiển thị rõ ràng thông tin  
✅ **Hover Effects** - Transform, shadow khi hover  
✅ **Active State** - Gradient background khi được chọn  
✅ **Click to Select/Deselect** - Toggle functionality  
✅ **Event Callback** - `OnCategorySelected` để xử lý logic  

### Categories Mặc Định

| Icon | Category | Count |
|------|----------|-------|
| 🏃 | Giày Chạy Bộ | 250+ |
| 🏀 | Giày Bóng Rổ | 180+ |
| 👟 | Giày Lifestyle | 320+ |
| ⚽ | Giày Bóng Đá | 150+ |
| 💪 | Giày Gym | 200+ |
| 👶 | Giày Trẻ Em | 280+ |

---

## 📍 Cách Sử Dụng

### Đã Tích Hợp Sẵn trong Index.razor

```razor
<!-- Main Banner -->
<MainBanner />

<!-- Categories Bar -->
<CategoriesBar OnCategorySelected="OnCategorySelected" />
```

### Handler trong @code

```csharp
private void OnCategorySelected(CategoriesBar.CategoryModel category)
{
    Console.WriteLine($"Category selected: {category.Name}");
    // TODO: Filter products by category
}
```

---

## 🎨 Customization

### Thay Đổi Màu MainBanner

Trong `MainBanner.razor`, tìm dòng:
```css
background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
```

Thay bằng gradient khác:
- **Blue**: `#4facfe 0%, #00f2fe 100%`
- **Red**: `#ff6b6b 0%, #ee5a6f 100%`
- **Green**: `#43e97b 0%, #38f9d7 100%`

### Thêm/Sửa Categories

Trong `CategoriesBar.razor` → `@code` section:

```csharp
private List<CategoryModel> Categories = new()
{
    new CategoryModel { Id = 1, Name = "Tên Mới", Icon = "fas fa-icon", Count = 100 },
    // Thêm categories khác...
};
```

### Icons Font Awesome

- Running: `fas fa-running`
- Basketball: `fas fa-basketball-ball`
- Shoe: `fas fa-shoe-prints`
- Football: `fas fa-futbol`
- Gym: `fas fa-dumbbell`
- Child: `fas fa-child`

Xem thêm icons tại: https://fontawesome.com/icons

---

## 📱 Responsive Design

### Desktop (>1024px)
- MainBanner: Content left, Cards right
- CategoriesBar: Auto-fit grid (4-6 columns)

### Tablet (768-1024px)
- MainBanner: Cards below content
- CategoriesBar: 3-4 columns

### Mobile (<768px)
- MainBanner: Stacked layout, 36px heading
- CategoriesBar: 2 columns grid
- Icons và text nhỏ hơn

---

## 🚀 Tính Năng Nổi Bật

### MainBanner
1. **Gradient Background** với animation
2. **Badge nhấp nháy** thu hút attention
3. **Large Typography** dễ đọc
4. **Statistics** build trust
5. **Floating Cards** interactive và thú vị

### CategoriesBar
1. **Visual Icons** dễ nhận biết
2. **Product Count** hiển thị inventory
3. **Active State** rõ ràng
4. **Hover Animation** smooth
5. **Click to Filter** intuitive

---

## 💡 Best Practices

### MainBanner
- ✅ Giữ text ngắn gọn, dễ hiểu
- ✅ CTA button phải rõ ràng
- ✅ Stats nên accurate
- ✅ Floating cards không quá nhiều (3-4 cards)

### CategoriesBar
- ✅ Tối đa 6-8 categories
- ✅ Icons phải relevant
- ✅ Count nên realistic
- ✅ Sort theo popularity

---

## 🎯 Flow Người Dùng

1. **Landing** → Thấy MainBanner với Hot Deals
2. **Read** → Đọc offers (Sale, Free Ship, Quality)
3. **Click CTA** → "Mua Sắm Ngay" scroll to products
4. **Browse** → Xem CategoriesBar
5. **Select** → Click category để filter
6. **Shop** → Xem products theo category

---

## 🐛 Troubleshooting

### MainBanner không hiển thị cards?
- Check viewport width (cards ẩn trên mobile <1024px)
- Verify CSS animations

### CategoriesBar không click được?
- Check `OnCategorySelected` handler
- Verify EventCallback binding

### Responsive không đúng?
- Clear browser cache
- Test với DevTools
- Check CSS media queries (@@media)

---

## 🔄 Tương Lai

### MainBanner
- [ ] Add background image option
- [ ] Video background
- [ ] Countdown timer cho flash sales
- [ ] Carousel cho multiple banners

### CategoriesBar
- [ ] Filter products theo category
- [ ] Subcategories dropdown
- [ ] Search trong categories
- [ ] Lazy load categories

---

## 📊 Performance

- ✅ **CSS-only animations** (GPU accelerated)
- ✅ **No heavy images** (icons only)
- ✅ **Optimized rendering**
- ✅ **Fast load time**

---

## ✅ Kết Luận

**MainBanner** và **CategoriesBar** đã được tích hợp sẵn vào trang chủ, tạo nên một homepage:

- 🎨 **Đẹp mắt** - Modern design
- 🧭 **Dễ dùng** - Clear navigation
- 📱 **Responsive** - Works on all devices
- ⚡ **Fast** - Optimized performance

Chạy `dotnet run` để xem kết quả!
