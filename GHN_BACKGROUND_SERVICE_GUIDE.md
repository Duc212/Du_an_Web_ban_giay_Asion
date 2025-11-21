# 🔄 GHN Background Service - Hướng dẫn sử dụng

## 📌 Tổng quan

**GhnStatusUpdateBackgroundService** là Background Service tự động cập nhật trạng thái đơn hàng từ GHN API.

### Tính năng chính:
- ✅ Tự động chạy **mỗi 5 phút**
- ✅ Chỉ cập nhật orders **đang vận chuyển** (có GhnOrderCode)
- ✅ Tự động **đồng bộ GhnStatus** từ GHN API
- ✅ Tự động **update Order Status** theo GHN Status
- ✅ Logging chi tiết để theo dõi
- ✅ Tránh rate limit (delay 500ms giữa các request)

---

## 🚀 Cách hoạt động

```
┌─────────────────────────────────────────────────────────┐
│ App Start                                               │
│   ↓                                                     │
│ Đợi 1 phút                                              │
│   ↓                                                     │
│ ┌─────────────────────────────────┐                    │
│ │ Lặp mỗi 5 phút:                  │                    │
│ │                                  │                    │
│ │ 1. Query orders có GhnOrderCode  │                    │
│ │    WHERE GhnStatus NOT IN        │                    │
│ │    ('delivered','cancel','return')│                    │
│ │                                  │                    │
│ │ 2. Foreach order:                │                    │
│ │    - Gọi GHN API GetDetail       │                    │
│ │    - So sánh status cũ/mới       │                    │
│ │    - Nếu khác → Update DB        │                    │
│ │    - Delay 500ms                 │                    │
│ │                                  │                    │
│ │ 3. Log kết quả                   │                    │
│ │    - Success count               │                    │
│ │    - Fail count                  │                    │
│ │                                  │                    │
│ │ 4. Đợi 5 phút → Lặp lại          │                    │
│ └─────────────────────────────────┘                    │
└─────────────────────────────────────────────────────────┘
```

---

## 📝 Mapping GHN Status → Order Status

| GHN Status | Order Status | Mô tả |
|-----------|-------------|-------|
| `pending`, `ready_to_pick` | `Confirmed` (1) | Chờ shipper lấy hàng |
| `picking`, `picked` | `Processing` (2) | Đang lấy hàng |
| `storing`, `transporting`, `delivering` | `Shipping` (3) | Đang vận chuyển |
| `delivered` | `Delivered` (4) | Đã giao thành công |
| `cancel`, `returned`, `return` | `Returned` (6) | Hoàn trả/Hủy |
| `exception`, `damage`, `lost` | *(Log warning)* | Ngoại lệ |

---

## 🔧 Configuration

### Thay đổi interval (thời gian chạy)

**File**: `API/Services/GhnStatusUpdateBackgroundService.cs`

```csharp
// Mặc định: 5 phút
private readonly TimeSpan _interval = TimeSpan.FromMinutes(5);

// Đổi thành 10 phút:
private readonly TimeSpan _interval = TimeSpan.FromMinutes(10);

// Đổi thành 30 giây (test):
private readonly TimeSpan _interval = TimeSpan.FromSeconds(30);
```

### Thay đổi delay khởi động

```csharp
// Mặc định: Đợi 1 phút sau khi app start
await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);

// Đổi thành chạy ngay:
await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
```

### Thay đổi delay giữa các request

```csharp
// Mặc định: 500ms
await Task.Delay(500, cancellationToken);

// Tăng lên 1 giây nếu GHN rate limit:
await Task.Delay(1000, cancellationToken);
```

---

## 📊 Logs

### Log khi service start
```
[09:00:00] Information: GHN Status Update Background Service started at 2024-11-21 09:00:00
[09:01:00] Information: GHN Status Update job triggered at 2024-11-21 09:01:00
```

### Log khi tìm thấy orders
```
[09:01:01] Information: Found 12 orders to update from GHN
```

### Log khi update thành công
```
[09:01:02] Information: Updating order 456 with GHN code GHNA1B2C3
[09:01:03] Information: Order 456 updated: GhnStatus changed from 'picking' to 'delivering'
```

### Log khi không có thay đổi
```
[09:01:03] Debug: Order 789: No status change (still 'delivering')
```

### Log tổng kết
```
[09:01:15] Information: GHN Status Update completed: 8 succeeded, 2 failed out of 12 orders
[09:01:15] Information: GHN Status Update job completed at 2024-11-21 09:01:15. Next run in 5 minutes
```

---

## 🧪 Testing

### Test 1: Kiểm tra service có chạy không

**Xem logs khi start app**:
```bash
dotnet run --project API
```

**Expected logs**:
```
GHN Status Update Background Service started at ...
```

### Test 2: Tạo đơn GHN và đợi update

1. Tạo đơn hàng → Gửi lên GHN
2. GHN trả về `GhnOrderCode`
3. Đợi 5 phút
4. Check logs xem có update không
5. Refresh admin UI → Xem status mới

### Test 3: Thay đổi interval thành 30s để test nhanh

**File**: `GhnStatusUpdateBackgroundService.cs`
```csharp
private readonly TimeSpan _interval = TimeSpan.FromSeconds(30);
```

**Restart app** → Xem logs sau 30s

---

## 🚨 Troubleshooting

### Issue 1: Service không chạy

**Nguyên nhân**: Chưa register trong `Program.cs`

**Giải pháp**: Kiểm tra dòng này có trong `Program.cs`:
```csharp
builder.Services.AddHostedService<GhnStatusUpdateBackgroundService>();
```

### Issue 2: Service chạy nhưng không update

**Check logs**:
```
No orders to update from GHN
```

**Nguyên nhân**: 
- Không có orders nào có `GhnOrderCode`
- Hoặc tất cả orders đã `delivered`/`cancelled`

**Giải pháp**: Tạo đơn mới và gửi lên GHN

### Issue 3: GHN API rate limit

**Error log**:
```
Failed to get GHN detail for order 456
```

**Giải pháp**: Tăng delay giữa các request:
```csharp
await Task.Delay(1000, cancellationToken); // 500ms → 1000ms
```

### Issue 4: Service crash app

**Nguyên nhân**: Exception trong `ExecuteAsync`

**Giải pháp**: Đã wrap toàn bộ code trong `try-catch`, check logs để xem lỗi gì

---

## 🎯 Best Practices

### 1. Monitoring
- Check logs định kỳ
- Theo dõi success/fail rate
- Alert nếu fail rate > 50%

### 2. Performance
- Interval 5 phút là hợp lý
- Không nên < 1 phút (tránh spam GHN API)
- Delay 500ms giữa các request để tránh rate limit

### 3. Database
- Service chỉ update orders **đang vận chuyển**
- Không touch orders đã `delivered` hoặc `cancelled`
- Dùng `ExecuteUpdate` nếu cần optimize (EF Core 7+)

### 4. Error Handling
- Log tất cả errors
- Service tự động retry sau 5 phút
- Không crash app nếu có lỗi

---

## 📈 Performance Metrics

**Với 100 orders đang vận chuyển**:
- Query time: ~100ms
- GHN API calls: 100 requests x 500ms = 50s
- Total time: ~51s
- Memory: ~10MB

**Với 1000 orders** (production):
- Total time: ~8.5 phút
- Recommend: Tăng interval lên 10 phút
- Hoặc dùng batch processing (100 orders/lần)

---

## 🔄 Alternative: Webhook vs Background Job

### Webhook (Realtime) ✅ **Recommended**
- Update **ngay lập tức** khi GHN có thay đổi
- Không tốn CPU/Memory
- Cần public URL

### Background Job (Polling)
- Update **mỗi 5 phút**
- Không cần public URL
- Tốn CPU/Memory
- Có delay

### Best Solution: **Dùng cả 2!**
- **Webhook**: Update realtime khi GHN gửi callback
- **Background Job**: Backup nếu webhook miss hoặc GHN không gửi

---

## 📚 Code Flow

### ExecuteAsync()
```
1. Start service
2. Delay 1 phút
3. While (not cancelled):
   - UpdateGhnOrderStatusAsync()
   - Delay 5 phút
4. Stop service
```

### UpdateGhnOrderStatusAsync()
```
1. Query orders cần update
2. Foreach order:
   - GetOrderDetailAsync(ghnCode)
   - Compare old/new status
   - If changed → Update DB
   - UpdateOrderStatusByGhnStatus()
   - Delay 500ms
3. Log summary
```

### UpdateOrderStatusByGhnStatus()
```
Switch (ghnStatus):
  case "pending" → Confirmed
  case "picking" → Processing
  case "delivering" → Shipping
  case "delivered" → Delivered
  case "cancel" → Returned
```

---

## 🛑 Tắt Background Service

### Tạm thời (development)
**Comment trong `Program.cs`**:
```csharp
// builder.Services.AddHostedService<GhnStatusUpdateBackgroundService>();
```

### Vĩnh viễn (production)
**Xóa file** `GhnStatusUpdateBackgroundService.cs` và xóa dòng trong `Program.cs`

---

## ✅ Checklist triển khai

- [x] Tạo file `GhnStatusUpdateBackgroundService.cs`
- [x] Register trong `Program.cs`
- [x] Config GHN Token/ShopId trong `appsettings.json`
- [ ] Test với interval = 30s
- [ ] Restart app và check logs
- [ ] Tạo đơn GHN và đợi update
- [ ] Set interval = 5 phút cho production
- [ ] Deploy và monitor logs

---

**Version**: 1.0.0  
**Author**: Senior .NET Dev Team  
**Last Updated**: 21/11/2024
