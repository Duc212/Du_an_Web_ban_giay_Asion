using DAL.DTOs.Orders.Res;

namespace AdminWeb.Services;

public class OrderService
{
    private readonly List<GetOrderRes> _orders;

    public OrderService()
    {
        // Status codes: 0 Pending, 1 Processing, 2 Shipping, 3 Delivered, 4 Cancelled
        _orders = new List<GetOrderRes>
        {
            new GetOrderRes
            {
                OrderId = "ORD001",
                OrderNumber = "ORD001",
                UserId = "USR001",
                ReceiverName = "Nguyễn Văn A",
                ReceiverPhone = "0901234567",
                ReceiverEmail = "a@example.com",
                ShippingAddress = "123 Đường ABC, Phường XYZ, Quận 1, TP. HCM",
                Ward = "XYZ", District = "Quận 1", City = "TP. HCM",
                Status = 0, PaymentMethod = 1, PaymentStatus = 1,
                CreatedAt = DateTime.Now.AddHours(-30),
                Items = new List<GetOrderItemRes>
                {
                    new GetOrderItemRes{ OrderItemId="IT001", ProductId=101, ProductName="Nike Air Max 2024", Brand="Nike", Quantity=2, Price=2500000, SelectedSize="42", SelectedColor="Trắng", ImageUrl="/assets/img/team-2.jpg"},
                    new GetOrderItemRes{ OrderItemId="IT002", ProductId=102, ProductName="Adidas Ultraboost", Brand="Adidas", Quantity=1, Price=3200000, SelectedSize="40", SelectedColor="Đen", ImageUrl="/assets/img/team-3.jpg"}
                }
            },
            new GetOrderRes
            {
                OrderId = "ORD002",
                OrderNumber = "ORD002",
                UserId = "USR002",
                ReceiverName = "Trần Thị B",
                ReceiverPhone = "0912345678",
                ReceiverEmail = "b@example.com",
                ShippingAddress = "45 Pasteur, Quận 3, TP. HCM",
                District="Quận 3", City="TP. HCM",
                Status = 1, PaymentMethod = 2, PaymentStatus = 1,
                CreatedAt = DateTime.Now.AddHours(-10),
                Items = new List<GetOrderItemRes>
                {
                    new GetOrderItemRes{ OrderItemId="IT003", ProductId=103, ProductName="Puma Runner Pro", Brand="Puma", Quantity=1, Price=1800000, SelectedSize="41", SelectedColor="Xám", ImageUrl="/assets/img/team-4.jpg"}
                }
            },
            new GetOrderRes
            {
                OrderId = "ORD003",
                OrderNumber = "ORD003",
                UserId = "USR003",
                ReceiverName = "Lê Văn C",
                ReceiverPhone = "0923456789",
                ReceiverEmail = "c@example.com",
                ShippingAddress = "22 Lê Lợi, Đà Nẵng",
                City="Đà Nẵng",
                Status = 2, PaymentMethod = 1, PaymentStatus = 1,
                CreatedAt = DateTime.Now.AddHours(-70),
                Items = new List<GetOrderItemRes>
                {
                    new GetOrderItemRes{ OrderItemId="IT004", ProductId=104, ProductName="Converse Classic", Brand="Converse", Quantity=3, Price=950000, SelectedSize="39", SelectedColor="Đỏ", ImageUrl="/assets/img/team-1.jpg"}
                }
            },
            new GetOrderRes
            {
                OrderId = "ORD004",
                OrderNumber = "ORD004",
                UserId = "USR004",
                ReceiverName = "Phạm Thị D",
                ReceiverPhone = "0934567890",
                ReceiverEmail = "d@example.com",
                ShippingAddress = "56 Hai Bà Trưng, Hà Nội",
                City="Hà Nội",
                Status = 3, PaymentMethod = 1, PaymentStatus = 1,
                CreatedAt = DateTime.Now.AddHours(-120),
                Items = new List<GetOrderItemRes>
                {
                    new GetOrderItemRes{ OrderItemId="IT005", ProductId=105, ProductName="Vans Old Skool", Brand="Vans", Quantity=1, Price=1450000, SelectedSize="42", SelectedColor="Đen", ImageUrl="/assets/img/team-5.jpg"}
                }
            },
            new GetOrderRes
            {
                OrderId = "ORD005",
                OrderNumber = "ORD005",
                UserId = "USR005",
                ReceiverName = "Hoàng Văn E",
                ReceiverPhone = "0945678901",
                ReceiverEmail = "e@example.com",
                ShippingAddress = "90 Phan Xích Long, Phú Nhuận, TP. HCM",
                District="Phú Nhuận", City="TP. HCM",
                Status = 0, PaymentMethod = 1, PaymentStatus = 0,
                CreatedAt = DateTime.Now.AddHours(-5),
                Items = new List<GetOrderItemRes>
                {
                    new GetOrderItemRes{ OrderItemId="IT006", ProductId=106, ProductName="New Balance 574", Brand="New Balance", Quantity=2, Price=2100000, SelectedSize="43", SelectedColor="Xanh", ImageUrl="/assets/img/team-6.jpg"}
                }
            }
        };

        // Calculate totals
        foreach (var o in _orders)
        {
            o.SubTotal = o.Items.Sum(i => i.Price * i.Quantity);
            o.ShippingFee = 30000; // fake flat fee
            o.Discount = o.SubTotal > 5000000 ? 50000 : 0;
            o.TotalAmount = o.SubTotal + o.ShippingFee - o.Discount;
        }
    }

    public Task<List<GetOrderRes>> GetOrdersAsync() => Task.FromResult(_orders.OrderByDescending(o => o.CreatedAt).ToList());

    public Task<GetOrderRes?> GetOrderAsync(string orderId) => Task.FromResult(_orders.FirstOrDefault(o => o.OrderId == orderId));

    public Task<bool> UpdateStatusAsync(string orderId, int newStatus)
    {
        var order = _orders.FirstOrDefault(o => o.OrderId == orderId);
        if (order == null) return Task.FromResult(false);
        order.Status = newStatus;
        return Task.FromResult(true);
    }
}
