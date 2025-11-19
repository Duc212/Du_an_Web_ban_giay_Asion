namespace DAL.DTOs.Orders.Res
{
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
        public PaymentStatsInfo PaymentStats { get; set; } = new PaymentStatsInfo();
        public List<DailyOrderInfo> DailyOrders { get; set; } = new List<DailyOrderInfo>();
        public List<TopProductInfo> TopProducts { get; set; } = new List<TopProductInfo>();
        public List<CustomerGrowthInfo> CustomerGrowth { get; set; } = new List<CustomerGrowthInfo>();
    }

    public class PaymentStatsInfo
    {
        public PaymentMethodStat COD { get; set; } = new PaymentMethodStat();
        public PaymentMethodStat VNPAY { get; set; } = new PaymentMethodStat();
        public PaymentMethodStat GPAY { get; set; } = new PaymentMethodStat();
        public PaymentMethodStat PAYPAL { get; set; } = new PaymentMethodStat();
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
        public string ProductName { get; set; }
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

    public class OrderStatisticsSummary
    {
        public int TotalOrders { get; set; }
        public int PendingOrders { get; set; }
        public int ProcessingOrders { get; set; }
        public int ShippingOrders { get; set; }
        public int DeliveredOrders { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal AverageOrderValue { get; set; }
    }
}
