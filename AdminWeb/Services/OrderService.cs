using DAL.DTOs.Orders.Res;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text;

namespace AdminWeb.Services;

public class OrderService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl = "https://localhost:7134/api/OrderAdmin";

    public OrderService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // Get all orders with filters
    public async Task<(List<AdminOrderListItem> Orders, int TotalRecords)> GetAllOrdersAsync(
        int pageIndex = 1,
        int pageSize = 20,
        string? keyword = null,
        int? status = null,
        int? paymentStatus = null,
        int? paymentMethod = null,
        DateTime? fromDate = null,
        DateTime? toDate = null,
        string sortBy = "orderDate",
        string sortOrder = "desc")
    {
        try
        {
            var queryParams = new List<string>
            {
                $"pageIndex={pageIndex}",
                $"pageSize={pageSize}",
                $"sortBy={sortBy}",
                $"sortOrder={sortOrder}"
            };

            if (!string.IsNullOrEmpty(keyword))
                queryParams.Add($"keyword={Uri.EscapeDataString(keyword)}");
            if (status.HasValue)
                queryParams.Add($"status={status.Value}");
            if (paymentStatus.HasValue)
                queryParams.Add($"paymentStatus={paymentStatus.Value}");
            if (paymentMethod.HasValue)
                queryParams.Add($"paymentMethod={paymentMethod.Value}");
            if (fromDate.HasValue)
                queryParams.Add($"fromDate={fromDate.Value:yyyy-MM-dd}");
            if (toDate.HasValue)
                queryParams.Add($"toDate={toDate.Value:yyyy-MM-dd}");

            var queryString = string.Join("&", queryParams);
            var response = await _httpClient.GetAsync($"{_baseUrl}/GetAllOrders?{queryString}");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ApiResponse<List<AdminOrderListItem>>>();
                return (result?.Data ?? new List<AdminOrderListItem>(), result?.TotalRecords ?? 0);
            }

            return (new List<AdminOrderListItem>(), 0);
        }
        catch
        {
            // Fallback to mock data for development
            return GetMockOrders(pageIndex, pageSize, keyword, status);
        }
    }

    // Get order detail
    public async Task<AdminOrderDetail?> GetOrderDetailAsync(int orderId)
    {
        try
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/GetOrderDetail/{orderId}");
            
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ApiResponse<AdminOrderDetail>>();
                return result?.Data;
            }

            return null;
        }
        catch
        {
            return GetMockOrderDetail(orderId);
        }
    }

    // Update order status
    public async Task<bool> UpdateOrderStatusAsync(UpdateOrderStatusRequest request)
    {
        try
        {
            var json = JsonSerializer.Serialize(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            
            var response = await _httpClient.PutAsync($"{_baseUrl}/UpdateOrderStatus", content);
            
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ApiResponse<bool>>();
                return result?.Success ?? false;
            }
            
            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"UpdateOrderStatusAsync error: {ex.Message}");
            return false;
        }
    }

    // Confirm order
    public async Task<string?> ConfirmOrderAsync(ConfirmOrderRequest request)
    {
        try
        {
            var json = JsonSerializer.Serialize(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            
            var response = await _httpClient.PostAsync($"{_baseUrl}/ConfirmOrder", content);
            
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ApiResponse<ConfirmOrderResponse>>();
                return result?.Data?.TrackingNumber;
            }

            return null;
        }
        catch
        {
            return null;
        }
    }

    // Cancel order
    public async Task<bool> CancelOrderAsync(CancelOrderRequest request)
    {
        try
        {
            var json = JsonSerializer.Serialize(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            
            var response = await _httpClient.PostAsync($"{_baseUrl}/CancelOrder", content);
            return response.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }

    // Update payment status
    public async Task<bool> UpdatePaymentStatusAsync(UpdatePaymentStatusRequest request)
    {
        try
        {
            var json = JsonSerializer.Serialize(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            
            var response = await _httpClient.PutAsync($"{_baseUrl}/UpdatePaymentStatus", content);
            return response.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }

    // Update shipping info
    public async Task<bool> UpdateShippingInfoAsync(UpdateShippingInfoRequest request)
    {
        try
        {
            var json = JsonSerializer.Serialize(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            
            var response = await _httpClient.PutAsync($"{_baseUrl}/UpdateShippingInfo", content);
            return response.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }

    // Get order statistics
    public async Task<OrderStatistics?> GetOrderStatisticsAsync(DateTime? fromDate = null, DateTime? toDate = null)
    {
        try
        {
            var queryParams = new List<string>();
            if (fromDate.HasValue)
                queryParams.Add($"fromDate={fromDate.Value:yyyy-MM-dd}");
            if (toDate.HasValue)
                queryParams.Add($"toDate={toDate.Value:yyyy-MM-dd}");

            var queryString = queryParams.Count > 0 ? "?" + string.Join("&", queryParams) : "";
            var response = await _httpClient.GetAsync($"{_baseUrl}/GetOrderStatistics{queryString}");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ApiResponse<OrderStatistics>>();
                return result?.Data;
            }

            return null;
        }
        catch
        {
            return GetMockStatistics();
        }
    }

    // Get order statistics summary for dashboard
    public async Task<OrderStatisticsSummary?> GetOrderStatisticsSummaryAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/GetOrderStatisticsSummary");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ApiResponse<OrderStatisticsSummary>>();
                return result?.Data ?? new OrderStatisticsSummary
                {
                    TotalOrders = 0,
                    PendingOrders = 0,
                    ProcessingOrders = 0,
                    ShippingOrders = 0,
                    DeliveredOrders = 0,
                    TotalRevenue = 0,
                    AverageOrderValue = 0
                };
            }

            return new OrderStatisticsSummary
            {
                TotalOrders = 0,
                PendingOrders = 0,
                ProcessingOrders = 0,
                ShippingOrders = 0,
                DeliveredOrders = 0,
                TotalRevenue = 0,
                AverageOrderValue = 0
            };
        }
        catch (Exception ex)
        {
            Console.WriteLine($"GetOrderStatisticsSummaryAsync error: {ex.Message}");
            // Return mock data if API fails
            return new OrderStatisticsSummary
            {
                TotalOrders = 0,
                PendingOrders = 0,
                ProcessingOrders = 0,
                ShippingOrders = 0,
                DeliveredOrders = 0,
                TotalRevenue = 0,
                AverageOrderValue = 0
            };
        }
    }

    // Get order statistics for Home dashboard
    public async Task<AdminWeb.Models.GetOrderStatisticsRes?> GetOrderStatisticsForDashboardAsync(DateTime? fromDate = null, DateTime? toDate = null)
    {
        try
        {
            var queryParams = new List<string>();
            if (fromDate.HasValue)
                queryParams.Add($"fromDate={fromDate.Value:yyyy-MM-dd}");
            if (toDate.HasValue)
                queryParams.Add($"toDate={toDate.Value:yyyy-MM-dd}");

            var queryString = queryParams.Count > 0 ? "?" + string.Join("&", queryParams) : "";
            var response = await _httpClient.GetAsync($"https://localhost:7134/api/Orders/GetOrderStatistics{queryString}");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ApiResponse<AdminWeb.Models.GetOrderStatisticsRes>>();
                return result?.Data;
            }

            return null;
        }
        catch
        {
            return null;
        }
    }

    // Helper classes for API responses
    private class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
        public int TotalRecords { get; set; }
    }

    private class ConfirmOrderResponse
    {
        public string TrackingNumber { get; set; } = string.Empty;
    }

    // Mock data methods for development/fallback
    private (List<AdminOrderListItem>, int) GetMockOrders(int pageIndex, int pageSize, string? keyword, int? status)
    {
        var mockOrders = new List<AdminOrderListItem>
        {
            new() { OrderID = 1, OrderCode = "ORD-001", CustomerName = "Nguyễn Văn A", CustomerPhone = "0901234567", CustomerEmail = "a@example.com", TotalAmount = 5890000, Status = 0, StatusText = "Chờ xác nhận", PaymentMethod = 1, PaymentMethodText = "COD", PaymentStatus = 0, PaymentStatusText = "Chưa thanh toán", OrderDate = DateTime.Now.AddHours(-2), ItemCount = 3, ShippingAddress = "123 Đường ABC, Quận 1, TP.HCM" },
            new() { OrderID = 2, OrderCode = "ORD-002", CustomerName = "Trần Thị B", CustomerPhone = "0912345678", CustomerEmail = "b@example.com", TotalAmount = 3200000, Status = 1, StatusText = "Đã xác nhận", PaymentMethod = 2, PaymentMethodText = "VNPAY", PaymentStatus = 1, PaymentStatusText = "Đã thanh toán", OrderDate = DateTime.Now.AddHours(-5), ItemCount = 1, ShippingAddress = "45 Pasteur, Quận 3, TP.HCM" },
            new() { OrderID = 3, OrderCode = "ORD-003", CustomerName = "Lê Văn C", CustomerPhone = "0923456789", CustomerEmail = "c@example.com", TotalAmount = 2850000, Status = 2, StatusText = "Đang xử lý", PaymentMethod = 1, PaymentMethodText = "COD", PaymentStatus = 0, PaymentStatusText = "Chưa thanh toán", OrderDate = DateTime.Now.AddHours(-10), ItemCount = 3, ShippingAddress = "22 Lê Lợi, Đà Nẵng" },
            new() { OrderID = 4, OrderCode = "ORD-004", CustomerName = "Phạm Thị D", CustomerPhone = "0934567890", CustomerEmail = "d@example.com", TotalAmount = 1450000, Status = 3, StatusText = "Đang giao", PaymentMethod = 1, PaymentMethodText = "COD", PaymentStatus = 0, PaymentStatusText = "Chưa thanh toán", OrderDate = DateTime.Now.AddDays(-2), ItemCount = 1, ShippingAddress = "56 Hai Bà Trưng, Hà Nội" },
            new() { OrderID = 5, OrderCode = "ORD-005", CustomerName = "Hoàng Văn E", CustomerPhone = "0945678901", CustomerEmail = "e@example.com", TotalAmount = 4200000, Status = 4, StatusText = "Đã giao", PaymentMethod = 2, PaymentMethodText = "VNPAY", PaymentStatus = 1, PaymentStatusText = "Đã thanh toán", OrderDate = DateTime.Now.AddDays(-5), ItemCount = 2, ShippingAddress = "90 Phan Xích Long, Phú Nhuận, TP.HCM" }
        };

        var filtered = mockOrders.AsEnumerable();
        
        if (!string.IsNullOrEmpty(keyword))
            filtered = filtered.Where(o => o.OrderCode.Contains(keyword, StringComparison.OrdinalIgnoreCase) || o.CustomerName.Contains(keyword, StringComparison.OrdinalIgnoreCase));
        
        if (status.HasValue)
            filtered = filtered.Where(o => o.Status == status.Value);

        var total = filtered.Count();
        var paged = filtered.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        
        return (paged, total);
    }

    private AdminOrderDetail? GetMockOrderDetail(int orderId)
    {
        return new AdminOrderDetail
        {
            OrderID = orderId,
            OrderCode = $"ORD-{orderId:000}",
            OrderDate = DateTime.Now.AddHours(-5),
            Status = 1,
            StatusText = "Đã xác nhận",
            StatusHistory = new List<OrderStatusHistory>
            {
                new() { Status = 0, StatusText = "Chờ xác nhận", ChangedAt = DateTime.Now.AddHours(-5), Note = "Đơn hàng mới được tạo", UpdatedBy = "System" },
                new() { Status = 1, StatusText = "Đã xác nhận", ChangedAt = DateTime.Now.AddHours(-4), Note = "Admin đã xác nhận đơn hàng", UpdatedBy = "admin@example.com" }
            },
            Customer = new OrderCustomerInfo { UserID = 5, FullName = "Nguyễn Văn A", Username = "nguyenvana", Email = "nguyenvana@gmail.com", Phone = "0901234567" },
            ShippingInfo = new OrderShippingInfo { ReceiverName = "Nguyễn Văn A", ReceiverPhone = "0901234567", Address = "123 Đường ABC", Ward = "Phường 1", District = "Quận 1", City = "TP. Hồ Chí Minh", FullAddress = "123 Đường ABC, Phường 1, Quận 1, TP. Hồ Chí Minh", Note = "Giao giờ hành chính" },
            Payment = new OrderPaymentInfo { PaymentMethod = 1, PaymentMethodText = "COD", PaymentStatus = 0, PaymentStatusText = "Chưa thanh toán", PaidAt = null },
            Shipment = new OrderShipmentInfo { ShippingProvider = "Giao Hàng Nhanh", TrackingNumber = "GHN123456789", ShippedDate = null, EstimatedDelivery = DateTime.Now.AddDays(3), DeliveryStatus = 0 },
            Voucher = new OrderVoucherInfo { VoucherCode = "NEWYEAR2024", DiscountValue = 100000 },
            Items = new List<OrderItemDetail>
            {
                new() { OrderDetailID = 1, ProductID = 10, ProductName = "Nike Air Max 270", BrandName = "Nike", ImageUrl = "/assets/img/team-2.jpg", ColorName = "Đen", SizeName = "42", Quantity = 2, UnitPrice = 2890000, Subtotal = 5780000 },
                new() { OrderDetailID = 2, ProductID = 15, ProductName = "Adidas Ultraboost", BrandName = "Adidas", ImageUrl = "/assets/img/team-3.jpg", ColorName = "Trắng", SizeName = "40", Quantity = 1, UnitPrice = 3450000, Subtotal = 3450000 }
            },
            Summary = new OrderSummary { Subtotal = 9230000, ShippingFee = 30000, Discount = 100000, TotalAmount = 9160000 },
            Note = "Khách hàng yêu cầu gọi trước khi giao"
        };
    }

    private OrderStatistics GetMockStatistics()
    {
        return new OrderStatistics
        {
            TotalOrders = 150,
            PendingOrders = 12,
            ConfirmedOrders = 25,
            ProcessingOrders = 18,
            ShippingOrders = 15,
            DeliveredOrders = 75,
            CancelledOrders = 5,
            ReturnedOrders = 0,
            TotalRevenue = 345000000,
            AverageOrderValue = 2300000
        };
    }
}
