using BUS.Services.Interfaces;
using DAL.DTOs;
using DAL.Entities;
using DAL.Models;
using DAL.RepositoryAsyns;
using Microsoft.EntityFrameworkCore;

namespace BUS.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly IRepositoryAsync<Order> _orderRepository;
        private readonly IRepositoryAsync<OrderDetail> _orderDetailRepository;
        private readonly IRepositoryAsync<ProductVariant> _variantRepository;
        private readonly IRepositoryAsync<Shipment> _shipmentRepository;

        public OrderServices(
            IRepositoryAsync<Order> orderRepository,
            IRepositoryAsync<OrderDetail> orderDetailRepository,
            IRepositoryAsync<ProductVariant> variantRepository,
            IRepositoryAsync<Shipment> shipmentRepository)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _variantRepository = variantRepository;
            _shipmentRepository = shipmentRepository;
        }

        public async Task<CommonResponse<bool>> CreateOrder(CreateOrderDTO createOrder)
        {
            using var transaction = await _orderRepository.DbContext.Database.BeginTransactionAsync();

            try
            {
                int? shipmentId = null;

                if (createOrder.Shipment != null)
                {
                    var shipment = new Shipment
                    {
                        ShippingProvider = createOrder.Shipment.ShippingProvider,
                        TrackingNumber = createOrder.Shipment.TrackingNumber,
                        ShippedDate = createOrder.Shipment.ShippedDate,
                        DeliveryStatus = createOrder.Shipment.DeliveryStatus ?? "Pending"
                    };

                    await _shipmentRepository.AddAsync(shipment);
                    await _shipmentRepository.SaveChangesAsync();

                    shipmentId = shipment.ShipmentID;
                }

                var order = new Order
                {
                    UserID = createOrder.UserID,
                    ShipmentID = shipmentId,
                    VoucherID = createOrder.VoucherID ?? 0,
                    OrderType = createOrder.OrderType,
                    Address = createOrder.Address,
                    Note = createOrder.Note,
                    OrderDate = DateTime.Now,
                    Status = "Pending"
                };

                await _orderRepository.AddAsync(order);
                await _orderRepository.SaveChangesAsync(); // để có OrderID

                decimal totalAmount = 0;
                var orderDetails = new List<OrderDetail>();

                foreach (var item in createOrder.OrderDetails)
                {
                    var variant = await _variantRepository.AsQueryable()
                        .FirstOrDefaultAsync(v => v.VariantID == item.VariantID);

                    if (variant == null)
                    {
                        await transaction.RollbackAsync();
                        return new CommonResponse<bool>
                        {
                            Success = false,
                            Message = $"VariantID {item.VariantID} không tồn tại.",
                        };
                    }

                    if (variant.StockQuantity < item.Quantity)
                    {
                        await transaction.RollbackAsync();
                        return new CommonResponse<bool>
                        {
                            Success = false,
                            Message = $"Sản phẩm {variant.VariantID} không đủ hàng.",
                        };
                    }

                    variant.StockQuantity -= item.Quantity;
                    await _variantRepository.UpdateAsync(variant);

                    orderDetails.Add(new OrderDetail
                    {
                        OrderID = order.OrderID,
                        VariantID = item.VariantID,
                        Quantity = item.Quantity
                    });

                    totalAmount += variant.SellingPrice * item.Quantity;
                }

                await _orderDetailRepository.AddRangeAsync(orderDetails);

                order.TotalAmount = totalAmount;
                await _orderRepository.UpdateAsync(order);

                await _variantRepository.SaveChangesAsync();
                await _orderDetailRepository.SaveChangesAsync();
                await _orderRepository.SaveChangesAsync();

                await transaction.CommitAsync();

                return new CommonResponse<bool>
                {
                    Success = true,
                    Message = "Tạo đơn hàng thành công.",
                };
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return new CommonResponse<bool>
                {
                    Success = false,
                    Message = $"Lỗi khi tạo đơn hàng: {ex.Message}",
                };
            }
        }
    }
}
