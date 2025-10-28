using BUS.Services.Interfaces;
using DAL;
using DAL.DTOs.Orders.Req;
using DAL.DTOs.Orders.Res;
using DAL.Entities;
using DAL.Enums;
using DAL.Models;
using DAL.Repositories;
using DAL.RepositoryAsyns;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace BUS.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly IRepositoryAsync<Order> _orderRepository;
        private readonly IRepositoryAsync<OrderDetail> _orderDetailRepository;
        private readonly IRepositoryAsync<ProductVariant> _variantRepository;
        private readonly IRepositoryAsync<Shipment> _shipmentRepository;
        private readonly IRepositoryAsync<User> _userRepository;
        private readonly IRepositoryAsync<Address> _addressRepository;
        private readonly IUnitOfWork<AppDbContext> _unitOfWork;
        public OrderServices(
            IRepositoryAsync<Order> orderRepository,
            IRepositoryAsync<OrderDetail> orderDetailRepository,
            IRepositoryAsync<ProductVariant> variantRepository,
            IRepositoryAsync<Shipment> shipmentRepository,
            IUnitOfWork<AppDbContext> unitOfWork,
            IRepositoryAsync<User> userRepository,
            IRepositoryAsync<Address> addressRepository)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _variantRepository = variantRepository;
            _shipmentRepository = shipmentRepository;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _addressRepository = addressRepository;
        }

        public async Task<CommonResponse<bool>> CreateOrder(CreateOrderReq req)
        {
            try
            {
                await _unitOfWork.ExecuteInTransactionAsync(async () =>
                {
                    int? shipmentId = null;

                    if (req.Shipment != null)
                    {
                        var shipment = new Shipment
                        {
                            ShippingProvider = req.Shipment.ShippingProvider,
                            TrackingNumber = req.Shipment.TrackingNumber,
                            ShippedDate = req.Shipment.ShippedDate,
                            DeliveryStatus = (int)OrderStatusEnums.Pending
                        };

                        await _shipmentRepository.AddAsync(shipment);
                        await _shipmentRepository.SaveChangesAsync();

                        shipmentId = shipment.ShipmentID;
                    }

                    var order = new Order
                    {
                        UserID = req.UserID,
                        ShipmentID = shipmentId,
                        VoucherID = req.VoucherID ?? 0,
                        OrderType = req.OrderType,
                        Address = req.Address,
                        Note = req.Note,
                        OrderDate = DateTime.Now,
                        Status = (int)OrderStatusEnums.Pending,
                        OrderCode = GenerateOrderCode()
                    };

                    await _orderRepository.AddAsync(order);
                    await _orderRepository.SaveChangesAsync();

                    decimal totalAmount = 0;
                    var orderDetails = new List<OrderDetail>();

                    foreach (var item in req.OrderDetails)
                    {
                        var variant = await _variantRepository.AsQueryable()
                            .FirstOrDefaultAsync(v => v.VariantID == item.VariantID);

                        if (variant == null)
                            throw new Exception($"VariantID {item.VariantID} không tồn tại.");

                        if (variant.StockQuantity < item.Quantity)
                            throw new Exception($"Sản phẩm {variant.VariantID} không đủ hàng.");

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
                });

                return new CommonResponse<bool>
                {
                    Success = true,
                    Message = "Tạo đơn hàng thành công."
                };
            }
            catch (Exception ex)
            {
                return new CommonResponse<bool>
                {
                    Success = false,
                    Message = $"Lỗi khi tạo đơn hàng: {ex.Message}"
                };
            }
        }

        public async Task<CommonPagination<GetListOrderRes>> GetListOrder(string? FullName, string? OrderCode, int? Status, DateTime? CreatedDate, int CurrentPage, int RecordPerPage)
        {
            var orders = _orderRepository.AsNoTrackingQueryable();
            var users = _userRepository.AsNoTrackingQueryable();

            var query = from o in orders
                        join u in users on o.UserID equals u.UserID
                        select new GetListOrderRes
                        {
                            OrderID = o.OrderID,
                            OrderCode = o.OrderCode,
                            FullName = u.FullName,
                            Email = u.Email,
                            Phone = u.Phone,
                            OrderType = o.OrderType,
                            OrderDate = o.OrderDate,
                            Status = o.Status,
                            Address = o.Address,
                            TotalAmount = o.TotalAmount
                        };

            if (!string.IsNullOrEmpty(FullName))
                query = query.Where(x => x.FullName.Contains(FullName));

            if (!string.IsNullOrEmpty(OrderCode))
                query = query.Where(x => x.OrderCode.Contains(OrderCode));

            if (Status.HasValue)
                query = query.Where(x => x.Status == Status.Value);

            if (CreatedDate.HasValue)
                query = query.Where(x => x.OrderDate.Date == CreatedDate.Value.Date);

            var totalRecords = await query.CountAsync();

            var data = await query
                .OrderByDescending(x => x.OrderDate)
                .Skip((CurrentPage - 1) * RecordPerPage)
                .Take(RecordPerPage)
                .ToListAsync();

            return new CommonPagination<GetListOrderRes>
            {
                Success = true,
                Message = "Lấy danh sách đơn hàng thành công.",
                Data = data,
                TotalRecord = totalRecords
            };
        }


        public async Task<CommonResponse<bool>> UpdateStatusOrder(UpdateStatusOrderReq req)
        {
            try
            {
                var order = await _orderRepository.AsQueryable()
                    .FirstOrDefaultAsync(o => o.OrderID == req.OrderID);

                if (order == null)
                {
                    return new CommonResponse<bool>
                    {
                        Success = false,
                        Message = $"Không tìm thấy đơn hàng có ID = {req.OrderID}."
                    };
                }

                if (!Enum.IsDefined(typeof(OrderStatusEnums), req.Status))
                {
                    return new CommonResponse<bool>
                    {
                        Success = false,
                        Message = "Trạng thái đơn hàng không hợp lệ."
                    };
                }

                if (order.Status == (int)OrderStatusEnums.Delivered || order.Status == (int)OrderStatusEnums.Cancelled)
                {
                    return new CommonResponse<bool>
                    {
                        Success = false,
                        Message = $"Không thể thay đổi trạng thái đơn hàng đã {order.Status}."
                    };
                }
                order.Status = (int)req.Status;

                await _orderRepository.UpdateAsync(order);
                await _orderRepository.SaveChangesAsync();

                return new CommonResponse<bool>
                {
                    Success = true,
                    Message = $"Cập nhật trạng thái đơn hàng #{req.OrderID} thành công: {req.Status}."
                };
            }
            catch (Exception ex)
            {
                return new CommonResponse<bool>
                {
                    Success = false,
                    Message = $"Lỗi khi cập nhật trạng thái đơn hàng: {ex.Message}"
                };
            }
        }

        private string GenerateOrderCode()
        {
            return $"ORD-{Guid.NewGuid().ToString("N")[..10].ToUpper()}";
        }

    }
}
