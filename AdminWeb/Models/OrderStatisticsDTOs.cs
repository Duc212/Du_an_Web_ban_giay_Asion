namespace AdminWeb.Models;

public class GetOrderStatisticsRes
{
    public int TotalOrders { get; set; }
    public int PendingOrders { get; set; }
    public int ConfirmedOrders { get; set; }
    public int ShippingOrders { get; set; }
    public int DeliveredOrders { get; set; }
    public int CancelledOrders { get; set; }
    public decimal TotalRevenue { get; set; }
    public decimal AverageOrderValue { get; set; }
    public PaymentStatsInfo PaymentStats { get; set; } = new();
    public List<DailyOrderInfo> DailyOrders { get; set; } = new();
    public List<TopProductInfo> TopProducts { get; set; } = new();
    public List<CustomerGrowthInfo> CustomerGrowth { get; set; } = new();
}

public class PaymentStatsInfo
{
    public PaymentMethodStat COD { get; set; } = new();
    public PaymentMethodStat VNPAY { get; set; } = new();
    public PaymentMethodStat GPAY { get; set; } = new();
    public PaymentMethodStat PAYPAL { get; set; } = new();
}

public class PaymentMethodStat
{
    public int Count { get; set; }
    public decimal Total { get; set; }
}

public class DailyOrderInfo
{
    public DateTime Date { get; set; }
    public int OrderCount { get; set; }
    public decimal Revenue { get; set; }
}

public class TopProductInfo
{
    public int ProductID { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public int OrderCount { get; set; }
    public int TotalQuantity { get; set; }
    public decimal Revenue { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
}

public class CustomerGrowthInfo
{
    public DateTime Date { get; set; }
    public int NewCustomers { get; set; }
    public int ReturningCustomers { get; set; }
    public int TotalCustomers { get; set; }
}
