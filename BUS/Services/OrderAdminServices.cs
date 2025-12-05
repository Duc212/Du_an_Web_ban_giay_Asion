using BUS.Services.Interfaces;
using DAL;
using DAL.DTOs.Orders.Res;
using DAL.Entities;
using DAL.Enums;
using DAL.Models;
using DAL.RepositoryAsyns;
using DAL.UnitOfWork;
using Helper.Utils;
using Microsoft.EntityFrameworkCore;

namespace BUS.Services
{
    public class OrderAdminServices : IOrderAdminServices
    {
        private readonly IRepositoryAsync<Order> _orderRepository;
        private readonly IRepositoryAsync<OrderDetail> _orderDetailRepository;
        private readonly IRepositoryAsync<ProductVariant> _variantRepository;
        private readonly IRepositoryAsync<Shipment> _shipmentRepository;
        private readonly IRepositoryAsync<User> _userRepository;
        private readonly IRepositoryAsync<Address> _addressRepository;
        private readonly IRepositoryAsync<Voucher> _voucherRepository;
        private readonly IRepositoryAsync<Payment> _paymentRepository;
        private readonly IRepositoryAsync<OrderPayment> _orderPaymentRepository;
        private readonly IUnitOfWork<AppDbContext> _unitOfWork;
        private readonly IGhnService _ghnService;

        public OrderAdminServices(
            IRepositoryAsync<Order> orderRepository,
            IRepositoryAsync<OrderDetail> orderDetailRepository,
            IRepositoryAsync<ProductVariant> variantRepository,
            IRepositoryAsync<Shipment> shipmentRepository,
            IRepositoryAsync<User> userRepository,
            IRepositoryAsync<Address> addressRepository,
            IRepositoryAsync<Voucher> voucherRepository,
            IRepositoryAsync<Payment> paymentRepository,
            IRepositoryAsync<OrderPayment> orderPaymentRepository,
            IUnitOfWork<AppDbContext> unitOfWork,
            IGhnService ghnService)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _variantRepository = variantRepository;
            _shipmentRepository = shipmentRepository;
            _userRepository = userRepository;
            _addressRepository = addressRepository;
            _voucherRepository = voucherRepository;
            _paymentRepository = paymentRepository;
            _orderPaymentRepository = orderPaymentRepository;
            _unitOfWork = unitOfWork;
            _ghnService = ghnService;
        }

        public async Task<CommonResponse<List<AdminOrderListItem>>> GetAllOrders(
            int pageIndex,
            int pageSize,
            string? keyword,
            int? status,
            int? paymentStatus,
            int? paymentMethod,
            DateTime? fromDate,
            DateTime? toDate,
            string sortBy,
            string sortOrder)
        {
            try
            {
                var query = _orderRepository.AsQueryable()
                    .Include(o => o.User)
                    .Include(o => o.OrderPayments)
                    .ThenInclude(op => op.Payment)
                    .AsQueryable();

                // Apply filters
                if (!string.IsNullOrEmpty(keyword))
                {
                    query = query.Where(o => o.OrderCode.Contains(keyword) ||
                                            (o.User != null && (o.User.FullName.Contains(keyword) ||
                                                               o.User.Phone.Contains(keyword) ||
                                                               o.User.Email.Contains(keyword))));
                }

                if (status.HasValue)
                {
                    query = query.Where(o => o.Status == status.Value);
                }

                if (fromDate.HasValue)
                {
                    query = query.Where(o => o.OrderDate >= fromDate.Value.Date);
                }

                if (toDate.HasValue)
                {
                    query = query.Where(o => o.OrderDate <= toDate.Value.Date.AddDays(1).AddTicks(-1));
                }

                // Apply sorting
                query = sortBy.ToLower() switch
                {
                    "orderdate" => sortOrder.ToLower() == "asc" 
                        ? query.OrderBy(o => o.OrderDate) 
                        : query.OrderByDescending(o => o.OrderDate),
                    "totalamount" => sortOrder.ToLower() == "asc" 
                        ? query.OrderBy(o => o.TotalAmount) 
                        : query.OrderByDescending(o => o.TotalAmount),
                    "status" => sortOrder.ToLower() == "asc" 
                        ? query.OrderBy(o => o.Status) 
                        : query.OrderByDescending(o => o.Status),
                    _ => query.OrderByDescending(o => o.OrderDate)
                };

                // Get total count before pagination
                var totalRecords = await query.CountAsync();

                // Apply pagination
                var orders = await query
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                // Get order details count
                var orderIds = orders.Select(o => o.OrderID).ToList();
                var itemCounts = await _orderDetailRepository.AsQueryable()
                    .Where(od => orderIds.Contains(od.OrderID))
                    .GroupBy(od => od.OrderID)
                    .Select(g => new { OrderID = g.Key, Count = g.Count() })
                    .ToListAsync();

                var result = orders.Select(o =>
                {
                    var orderPayment = o.OrderPayments.FirstOrDefault();
                    var payment = orderPayment?.Payment;
                    var itemCount = itemCounts.FirstOrDefault(ic => ic.OrderID == o.OrderID)?.Count ?? 0;

                    return new AdminOrderListItem
                    {
                        OrderID = o.OrderID,
                        OrderCode = o.OrderCode,
                        CustomerName = o.User?.FullName ?? "Khách vãng lai",
                        CustomerPhone = o.User?.Phone ?? "",
                        CustomerEmail = o.User?.Email ?? "",
                        TotalAmount = o.TotalAmount,
                        Status = o.Status,
                        StatusText = GetStatusText(o.Status),
                        PaymentMethod = payment != null ? GetPaymentMethodInt(payment.PaymentMethod) : (int)PaymentMethodEnums.COD,
                        PaymentMethodText = payment?.PaymentMethod ?? "COD",
                        PaymentStatus = orderPayment?.Status ?? 0,
                        PaymentStatusText = GetPaymentStatusText(orderPayment?.Status ?? 0),
                        OrderDate = o.OrderDate,
                        ItemCount = itemCount,
                        ShippingAddress = o.Address ?? ""
                    };
                }).ToList();

                return new CommonResponse<List<AdminOrderListItem>>
                {
                    Success = true,
                    Message = "Lấy danh sách đơn hàng thành công",
                    Data = result
                };
            }
            catch (Exception ex)
            {
                return new CommonResponse<List<AdminOrderListItem>>
                {
                    Success = false,
                    Message = $"Lỗi: {ex.Message}",
                    Data = new List<AdminOrderListItem>()
                };
            }
        }

        public async Task<CommonResponse<List<AdminOrderListItem>>> GetPendingOrders(int pageIndex, int pageSize)
        {
            return await GetAllOrders(pageIndex, pageSize, null, (int)OrderStatusEnums.Pending, null, null, null, null, "orderDate", "asc");
        }

        public async Task<CommonResponse<AdminOrderDetail>> GetOrderDetail(int orderId)
        {
            try
            {
                var order = await _orderRepository.AsQueryable()
                    .Include(o => o.User)
                    .Include(o => o.Shipment)
                    .Include(o => o.Voucher)
                    .Include(o => o.OrderPayments)
                    .ThenInclude(op => op.Payment)
                    .FirstOrDefaultAsync(o => o.OrderID == orderId);

                if (order == null)
                {
                    return new CommonResponse<AdminOrderDetail>
                    {
                        Success = false,
                        Message = "Không tìm thấy đơn hàng"
                    };
                }

                // Get order details with product info
                var orderDetails = await _orderDetailRepository.AsQueryable()
                    .Where(od => od.OrderID == orderId)
                    .ToListAsync();

                var variantIds = orderDetails.Select(od => od.VariantID).ToList();
                var variants = await _variantRepository.AsQueryable()
                    .Include(v => v.Product)
                    .ThenInclude(p => p.Brand)
                    .Include(v => v.Color)
                    .Include(v => v.Size)
                    .Where(v => variantIds.Contains(v.VariantID))
                    .ToListAsync();

                // Create simple status history from order
                var statusHistory = new List<OrderStatusHistory>
                {
                    new OrderStatusHistory
                    {
                        Status = order.Status,
                        StatusText = GetStatusText(order.Status),
                        ChangedAt = order.OrderDate,
                        Note = order.Note,
                        UpdatedBy = "System"
                    }
                };

                // Get address info
                var address = order.UserID.HasValue 
                    ? await _addressRepository.AsQueryable()
                        .FirstOrDefaultAsync(a => a.UserID == order.UserID.Value)
                    : null;

                var orderPayment = order.OrderPayments.FirstOrDefault();
                var payment = orderPayment?.Payment;

                var items = orderDetails.Select(od =>
                {
                    var variant = variants.FirstOrDefault(v => v.VariantID == od.VariantID);
                    return new OrderItemDetail
                    {
                        OrderDetailID = od.OrderDetailID,
                        ProductID = variant?.Product?.ProductID ?? 0,
                        ProductName = variant?.Product?.Name ?? "",
                        BrandName = variant?.Product?.Brand?.Name ?? "",
                        ImageUrl = variant?.Product?.ImageUrl ?? "",
                        ColorName = variant?.Color?.Name ?? "",
                        SizeName = variant?.Size?.Value ?? "",
                        Quantity = od.Quantity,
                        UnitPrice = od.UnitPrice, // Sử dụng giá đã snapshot
                        Subtotal = od.Quantity * od.UnitPrice // Tính từ giá đã snapshot
                    };
                }).ToList();

                decimal subtotal = items.Sum(i => i.Subtotal);
                decimal shippingFee = 30000; // Default shipping fee
                decimal discount = order.Voucher?.DiscountValue ?? 0;

                var detail = new AdminOrderDetail
                {
                    OrderID = order.OrderID,
                    OrderCode = order.OrderCode,
                    OrderDate = order.OrderDate,
                    Status = order.Status,
                    StatusText = GetStatusText(order.Status),
                    StatusHistory = statusHistory,
                    Customer = new OrderCustomerInfo
                    {
                        UserID = order.User?.UserID ?? 0,
                        FullName = order.User?.FullName ?? "Khách vãng lai",
                        Username = order.User?.Username ?? "",
                        Email = order.User?.Email ?? "",
                        Phone = order.User?.Phone ?? ""
                    },
                    ShippingInfo = new OrderShippingInfo
                    {
                        ReceiverName = order.User?.FullName ?? "",
                        ReceiverPhone = order.User?.Phone ?? "",
                        Address = address?.Street ?? order.Address ?? "",
                        Ward = address?.Ward ?? "",
                        District = address?.District ?? "",
                        City = address?.City ?? "",
                        FullAddress = address != null 
                            ? $"{address.Street}, {address.Ward}, {address.District}, {address.City}" 
                            : order.Address ?? "",
                        Note = order.Note
                    },
                    Payment = new OrderPaymentInfo
                    {
                        PaymentMethod = payment != null ? GetPaymentMethodInt(payment.PaymentMethod) : (int)PaymentMethodEnums.COD,
                        PaymentMethodText = payment?.PaymentMethod ?? "COD",
                        PaymentStatus = orderPayment?.Status ?? 0,
                        PaymentStatusText = GetPaymentStatusText(orderPayment?.Status ?? 0),
                        PaidAt = orderPayment?.Status == 1 ? order.OrderDate : null
                    },
                    Shipment = new OrderShipmentInfo
                    {
                        ShippingProvider = order.Shipment?.ShippingProvider,
                        TrackingNumber = order.Shipment?.TrackingNumber,
                        ShippedDate = order.Shipment?.ShippedDate,
                        EstimatedDelivery = order.Shipment?.ShippedDate?.AddDays(3),
                        DeliveryStatus = order.Shipment?.DeliveryStatus ?? 0,
                        // GHN Integration
                        GhnOrderCode = order.GhnOrderCode,
                        GhnStatus = order.GhnStatus,
                        GhnFee = order.GhnFee,
                        CodCollected = order.CodCollected,
                        GhnCreatedAt = order.GhnCreatedAt,
                        GhnUpdatedAt = order.GhnUpdatedAt
                    },
                    Voucher = order.Voucher != null 
                        ? new OrderVoucherInfo
                        {
                            VoucherCode = order.Voucher.VoucherCode,
                            DiscountValue = order.Voucher.DiscountValue
                        } 
                        : null,
                    Items = items,
                    Summary = new OrderSummary
                    {
                        Subtotal = subtotal,
                        ShippingFee = shippingFee,
                        Discount = discount,
                        TotalAmount = order.TotalAmount
                    },
                    Note = order.Note
                };

                return new CommonResponse<AdminOrderDetail>
                {
                    Success = true,
                    Message = "Lấy chi tiết đơn hàng thành công",
                    Data = detail
                };
            }
            catch (Exception ex)
            {
                return new CommonResponse<AdminOrderDetail>
                {
                    Success = false,
                    Message = $"Lỗi: {ex.Message}"
                };
            }
        }

        public async Task<CommonResponse<bool>> UpdateOrderStatus(int orderId, int newStatus, string? note, string? updatedBy)
        {
            try
            {
                var order = await _orderRepository.AsQueryable()
                    .FirstOrDefaultAsync(o => o.OrderID == orderId);

                if (order == null)
                {
                    return new CommonResponse<bool>
                    {
                        Success = false,
                        Message = "Không tìm thấy đơn hàng"
                    };
                }

                // Validate status transition
                if (!IsValidStatusTransition(order.Status, newStatus))
                {
                    return new CommonResponse<bool>
                    {
                        Success = false,
                        Message = $"Không thể chuyển từ trạng thái '{GetStatusText(order.Status)}' sang '{GetStatusText(newStatus)}'"
                    };
                }

                await _unitOfWork.ExecuteInTransactionAsync(async () =>
                {
                    // Debug log
                    Console.WriteLine($"🔍 UpdateOrderStatus - OrderID: {orderId}, NewStatus: {newStatus}, CurrentGhnOrderCode: '{order.GhnOrderCode}'");
                    
                    // Auto-create GHN order when shipping (if not exists)
                    if (newStatus == (int)OrderStatusEnums.Shipped && string.IsNullOrEmpty(order.GhnOrderCode))
                    {
                        Console.WriteLine($"✅ Điều kiện đúng! Bắt đầu tạo đơn GHN...");
                        try
                        {
                            // ✅ LẤY ĐỊA CHỈ TỪ ORDER DATABASE (không hardcode)
                            var ghnResult = await _ghnService.CreateOrderAsync(new DAL.DTOs.Shipping.CreateGhnOrderRequest 
                            { 
                                OrderId = orderId
                                // Không truyền ToWardCode/ToDistrictId → GhnService sẽ tự lấy từ Order.GhnWardCode/GhnDistrictId
                            });
                            
                            Console.WriteLine($"📦 GHN API Response - Success: {ghnResult.Success}, OrderCode: '{ghnResult.GhnOrderCode}', Message: '{ghnResult.Message}'");
                            
                            if (ghnResult.Success && !string.IsNullOrEmpty(ghnResult.GhnOrderCode))
                            {
                                order.GhnOrderCode = ghnResult.GhnOrderCode;
                                order.GhnStatus = "ready_to_pick";
                                order.GhnFee = ghnResult.TotalFee;
                                order.GhnCreatedAt = DateTime.Now;
                                
                                Console.WriteLine($"✅ Đã cập nhật Order với GhnOrderCode: {ghnResult.GhnOrderCode}");
                                
                                var ghnNote = $"Tự động tạo đơn GHN: {ghnResult.GhnOrderCode}";
                                note = string.IsNullOrEmpty(note) ? ghnNote : $"{note}. {ghnNote}";
                            }
                            else
                            {
                                // Log lỗi chi tiết
                                var errorMsg = $"⚠️ Không thể tạo đơn GHN: {ghnResult.Message}";
                                Console.WriteLine(errorMsg);
                                
                                var errorNote = $"[GHN Error] {ghnResult.Message}";
                                note = string.IsNullOrEmpty(note) ? errorNote : $"{note}. {errorNote}";
                            }
                        }
                        catch (Exception ex)
                        {
                            // Log exception chi tiết
                            var errorMsg = $"❌ Exception khi tạo GHN order: {ex.Message}\nStackTrace: {ex.StackTrace}";
                            Console.WriteLine(errorMsg);
                            
                            var errorNote = $"[GHN Exception] {ex.Message}";
                            note = string.IsNullOrEmpty(note) ? errorNote : $"{note}. {errorNote}";
                        }
                    }
                    else
                    {
                        Console.WriteLine($"⏭️ Skip tạo GHN - Lý do: newStatus={newStatus} (cần 3), GhnOrderCode='{order.GhnOrderCode}' (cần null/empty)");
                    }
                    
                    // Update order status
                    order.Status = newStatus;
                    
                    // Append note to existing note
                    if (!string.IsNullOrEmpty(note))
                    {
                        order.Note = string.IsNullOrEmpty(order.Note) 
                            ? $"[{DateTime.Now:dd/MM/yyyy HH:mm}] {note}" 
                            : $"{order.Note}\n[{DateTime.Now:dd/MM/yyyy HH:mm}] {note}";
                    }
                    
                    await _orderRepository.UpdateAsync(order);

                    // If status is Delivered and payment method is COD, update payment status
                    if (newStatus == (int)OrderStatusEnums.Delivered)
                    {
                        var orderPayment = await _orderPaymentRepository.AsQueryable()
                            .Include(op => op.Payment)
                            .FirstOrDefaultAsync(op => op.OrderID == orderId);

                        if (orderPayment != null && orderPayment.Payment.PaymentMethod.ToUpper() == "COD")
                        {
                            orderPayment.Status = (int)PaymentStatus.Paid;
                            await _orderPaymentRepository.UpdateAsync(orderPayment);
                        }
                    }

                    // If status is Cancelled or Returned, restore stock
                    if (newStatus == (int)OrderStatusEnums.Cancelled || newStatus == (int)OrderStatusEnums.Returned)
                    {
                        var orderDetails = await _orderDetailRepository.AsQueryable()
                            .Where(od => od.OrderID == orderId)
                            .ToListAsync();

                        foreach (var detail in orderDetails)
                        {
                            var variant = await _variantRepository.AsQueryable()
                                .FirstOrDefaultAsync(v => v.VariantID == detail.VariantID);

                            if (variant != null)
                            {
                                variant.StockQuantity += detail.Quantity;
                                await _variantRepository.UpdateAsync(variant);
                            }
                        }
                    }

                    await _orderRepository.SaveChangesAsync();
                    await _orderPaymentRepository.SaveChangesAsync();
                    await _variantRepository.SaveChangesAsync();
                });

                return new CommonResponse<bool>
                {
                    Success = true,
                    Message = "Cập nhật trạng thái đơn hàng thành công",
                    Data = true
                };
            }
            catch (Exception ex)
            {
                return new CommonResponse<bool>
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }

        // Overload with int? updatedBy
        public async Task<CommonResponse<bool>> UpdateOrderStatus(int orderId, int newStatus, string? note, int? updatedBy)
        {
            return await UpdateOrderStatus(orderId, newStatus, note, updatedBy?.ToString());
        }

        public async Task<CommonResponse<DAL.DTOs.Orders.Res.ConfirmOrderResponse>> ConfirmOrder(int orderId, string shippingProvider, DateTime estimatedDelivery, string? note)
        {
            try
            {
                var order = await _orderRepository.AsQueryable()
                    .FirstOrDefaultAsync(o => o.OrderID == orderId);

                if (order == null)
                {
                    return new CommonResponse<DAL.DTOs.Orders.Res.ConfirmOrderResponse>
                    {
                        Success = false,
                        Message = "Không tìm thấy đơn hàng"
                    };
                }

                if (order.Status != (int)OrderStatusEnums.Pending)
                {
                    return new CommonResponse<DAL.DTOs.Orders.Res.ConfirmOrderResponse>
                    {
                        Success = false,
                        Message = "Chỉ có thể xác nhận đơn hàng ở trạng thái 'Chờ xác nhận'"
                    };
                }

                string trackingNumber = GenerateTrackingNumber();

                await _unitOfWork.ExecuteInTransactionAsync(async () =>
                {
                    // Create or update shipment
                    Shipment shipment;
                    if (order.ShipmentID.HasValue)
                    {
                        shipment = await _shipmentRepository.AsQueryable()
                            .FirstOrDefaultAsync(s => s.ShipmentID == order.ShipmentID.Value);
                        
                        if (shipment != null)
                        {
                            shipment.ShippingProvider = shippingProvider;
                            shipment.TrackingNumber = trackingNumber;
                            await _shipmentRepository.UpdateAsync(shipment);
                        }
                    }
                    else
                    {
                        shipment = new Shipment
                        {
                            ShippingProvider = shippingProvider,
                            TrackingNumber = trackingNumber,
                            DeliveryStatus = 0,
                            ShippedDate = null
                        };
                        await _shipmentRepository.AddAsync(shipment);
                        await _shipmentRepository.SaveChangesAsync();
                        
                        order.ShipmentID = shipment.ShipmentID;
                    }

                    // Update order status
                    order.Status = (int)OrderStatusEnums.Confirmed;
                    
                    // Add note
                    if (!string.IsNullOrEmpty(note))
                    {
                        order.Note = string.IsNullOrEmpty(order.Note) 
                            ? $"[{DateTime.Now:dd/MM/yyyy HH:mm}] Admin xác nhận: {note}" 
                            : $"{order.Note}\n[{DateTime.Now:dd/MM/yyyy HH:mm}] Admin xác nhận: {note}";
                    }
                    
                    await _orderRepository.UpdateAsync(order);
                    await _orderRepository.SaveChangesAsync();
                    await _shipmentRepository.SaveChangesAsync();
                });

                return new CommonResponse<DAL.DTOs.Orders.Res.ConfirmOrderResponse>
                {
                    Success = true,
                    Message = "Xác nhận đơn hàng thành công",
                    Data = new DAL.DTOs.Orders.Res.ConfirmOrderResponse
                    {
                        TrackingNumber = trackingNumber,
                        ShipmentID = order.ShipmentID ?? 0
                    }
                };
            }
            catch (Exception ex)
            {
                return new CommonResponse<DAL.DTOs.Orders.Res.ConfirmOrderResponse>
                {
                    Success = false,
                    Message = $"Lỗi: {ex.Message}"
                };
            }
        }

        public async Task<CommonResponse<bool>> CancelOrder(int orderId, string cancelReason, bool refundRequired)
        {
            try
            {
                var order = await _orderRepository.AsQueryable()
                    .Include(o => o.OrderPayments)
                    .ThenInclude(op => op.Payment)
                    .FirstOrDefaultAsync(o => o.OrderID == orderId);

                if (order == null)
                {
                    return new CommonResponse<bool>
                    {
                        Success = false,
                        Message = "Không tìm thấy đơn hàng"
                    };
                }

                if (order.Status == (int)OrderStatusEnums.Delivered)
                {
                    return new CommonResponse<bool>
                    {
                        Success = false,
                        Message = "Không thể hủy đơn hàng đã giao"
                    };
                }

                await _unitOfWork.ExecuteInTransactionAsync(async () =>
                {
                    // Update order status
                    order.Status = (int)OrderStatusEnums.Cancelled;
                    order.Note = $"{order.Note}\n[{DateTime.Now:dd/MM/yyyy HH:mm}] HỦY: {cancelReason}";
                    await _orderRepository.UpdateAsync(order);

                    // Restore stock
                    var orderDetails = await _orderDetailRepository.AsQueryable()
                        .Where(od => od.OrderID == orderId)
                        .ToListAsync();

                    foreach (var detail in orderDetails)
                    {
                        var variant = await _variantRepository.AsQueryable()
                            .FirstOrDefaultAsync(v => v.VariantID == detail.VariantID);

                        if (variant != null)
                        {
                            variant.StockQuantity += detail.Quantity;
                            await _variantRepository.UpdateAsync(variant);
                        }
                    }

                    // Update payment status if refund required
                    if (refundRequired)
                    {
                        var orderPayment = order.OrderPayments.FirstOrDefault();
                        if (orderPayment != null && orderPayment.Status == (int)PaymentStatus.Paid)
                        {
                            orderPayment.Status = (int)PaymentStatus.Refunded;
                            orderPayment.Note = $"{orderPayment.Note}\n[{DateTime.Now:dd/MM/yyyy HH:mm}] Hoàn tiền: {cancelReason}";
                            await _orderPaymentRepository.UpdateAsync(orderPayment);
                        }
                    }

                    await _orderRepository.SaveChangesAsync();
                    await _variantRepository.SaveChangesAsync();
                    await _orderPaymentRepository.SaveChangesAsync();
                });

                return new CommonResponse<bool>
                {
                    Success = true,
                    Message = "Hủy đơn hàng thành công",
                    Data = true
                };
            }
            catch (Exception ex)
            {
                return new CommonResponse<bool>
                {
                    Success = false,
                    Message = $"Lỗi: {ex.Message}",
                    Data = false
                };
            }
        }

        public async Task<CommonResponse<bool>> UpdatePaymentStatus(int orderId, int paymentStatus, string? note)
        {
            try
            {
                var orderPayment = await _orderPaymentRepository.AsQueryable()
                    .FirstOrDefaultAsync(op => op.OrderID == orderId);

                if (orderPayment == null)
                {
                    return new CommonResponse<bool>
                    {
                        Success = false,
                        Message = "Không tìm thấy thông tin thanh toán"
                    };
                }

                orderPayment.Status = paymentStatus;
                if (!string.IsNullOrEmpty(note))
                {
                    orderPayment.Note = string.IsNullOrEmpty(orderPayment.Note)
                        ? $"[{DateTime.Now:dd/MM/yyyy HH:mm}] {note}"
                        : $"{orderPayment.Note}\n[{DateTime.Now:dd/MM/yyyy HH:mm}] {note}";
                }

                await _orderPaymentRepository.UpdateAsync(orderPayment);
                await _orderPaymentRepository.SaveChangesAsync();

                return new CommonResponse<bool>
                {
                    Success = true,
                    Message = "Cập nhật trạng thái thanh toán thành công",
                    Data = true
                };
            }
            catch (Exception ex)
            {
                return new CommonResponse<bool>
                {
                    Success = false,
                    Message = $"Lỗi: {ex.Message}",
                    Data = false
                };
            }
        }

        public async Task<CommonResponse<bool>> UpdateShippingInfo(int orderId, string shippingProvider, string trackingNumber, DateTime? shippedDate, DateTime? estimatedDelivery, string? note)
        {
            try
            {
                var order = await _orderRepository.AsQueryable()
                    .Include(o => o.Shipment)
                    .FirstOrDefaultAsync(o => o.OrderID == orderId);

                if (order == null)
                {
                    return new CommonResponse<bool>
                    {
                        Success = false,
                        Message = "Không tìm thấy đơn hàng"
                    };
                }

                if (order.Shipment == null)
                {
                    return new CommonResponse<bool>
                    {
                        Success = false,
                        Message = "Đơn hàng chưa có thông tin vận chuyển"
                    };
                }

                order.Shipment.ShippingProvider = shippingProvider;
                order.Shipment.TrackingNumber = trackingNumber;
                if (shippedDate.HasValue)
                {
                    order.Shipment.ShippedDate = shippedDate.Value;
                }

                await _shipmentRepository.UpdateAsync(order.Shipment);

                // Update order status and note if shipped date is provided
                if (shippedDate.HasValue && order.Status < (int)OrderStatusEnums.Shipped)
                {
                    order.Status = (int)OrderStatusEnums.Shipped;
                    if (!string.IsNullOrEmpty(note))
                    {
                        order.Note = string.IsNullOrEmpty(order.Note)
                            ? $"[{DateTime.Now:dd/MM/yyyy HH:mm}] {note}"
                            : $"{order.Note}\n[{DateTime.Now:dd/MM/yyyy HH:mm}] {note}";
                    }
                    await _orderRepository.UpdateAsync(order);
                }

                await _shipmentRepository.SaveChangesAsync();
                await _orderRepository.SaveChangesAsync();

                return new CommonResponse<bool>
                {
                    Success = true,
                    Message = "Cập nhật thông tin vận chuyển thành công",
                    Data = true
                };
            }
            catch (Exception ex)
            {
                return new CommonResponse<bool>
                {
                    Success = false,
                    Message = $"Lỗi: {ex.Message}",
                    Data = false
                };
            }
        }

        public async Task<CommonResponse<OrderStatistics>> GetOrderStatistics(DateTime? fromDate, DateTime? toDate)
        {
            try
            {
                if (!fromDate.HasValue)
                    fromDate = DateTime.Now.AddMonths(-1).Date;
                if (!toDate.HasValue)
                    toDate = DateTime.Now.Date.AddDays(1).AddTicks(-1);

                var orders = await _orderRepository.AsQueryable()
                    .Where(o => o.OrderDate >= fromDate && o.OrderDate <= toDate)
                    .ToListAsync();

                var deliveredOrders = orders.Where(o => o.Status == (int)OrderStatusEnums.Delivered).ToList();

                var stats = new OrderStatistics
                {
                    TotalOrders = orders.Count,
                    PendingOrders = orders.Count(o => o.Status == (int)OrderStatusEnums.Pending),
                    ConfirmedOrders = orders.Count(o => o.Status == (int)OrderStatusEnums.Confirmed),
                    ProcessingOrders = orders.Count(o => o.Status == (int)OrderStatusEnums.Processing),
                    ShippingOrders = orders.Count(o => o.Status == (int)OrderStatusEnums.Shipped),
                    DeliveredOrders = deliveredOrders.Count,
                    CancelledOrders = orders.Count(o => o.Status == (int)OrderStatusEnums.Cancelled),
                    ReturnedOrders = orders.Count(o => o.Status == (int)OrderStatusEnums.Returned),
                    TotalRevenue = deliveredOrders.Sum(o => o.TotalAmount),
                    AverageOrderValue = deliveredOrders.Any() ? deliveredOrders.Average(o => o.TotalAmount) : 0
                };

                return new CommonResponse<OrderStatistics>
                {
                    Success = true,
                    Message = "Lấy thống kê đơn hàng thành công",
                    Data = stats
                };
            }
            catch (Exception ex)
            {
                return new CommonResponse<OrderStatistics>
                {
                    Success = false,
                    Message = $"Lỗi: {ex.Message}"
                };
            }
        }

        public async Task<CommonResponse<OrderStatisticsSummary>> GetOrderStatisticsSummary()
        {
            try
            {
                // Lấy tất cả orders và include OrderPayments để tính revenue chính xác
                var allOrders = await _orderRepository.AsQueryable()
                    .Include(o => o.OrderPayments)
                    .ToListAsync();

                // Chỉ tính revenue cho orders đã giao + đã thanh toán
                var deliveredOrders = allOrders
                    .Where(o => o.Status == (int)OrderStatusEnums.Delivered)
                    .ToList();

                var paidDeliveredOrders = deliveredOrders
                    .Where(o => o.OrderPayments.Any(op => op.Status == (int)PaymentStatus.Paid))
                    .ToList();

                var summary = new OrderStatisticsSummary
                {
                    TotalOrders = allOrders.Count,
                    PendingOrders = allOrders.Count(o => o.Status == (int)OrderStatusEnums.Pending),
                    ProcessingOrders = allOrders.Count(o => 
                        o.Status == (int)OrderStatusEnums.Confirmed || 
                        o.Status == (int)OrderStatusEnums.Processing),
                    ShippingOrders = allOrders.Count(o => o.Status == (int)OrderStatusEnums.Shipped),
                    DeliveredOrders = deliveredOrders.Count,
                    TotalRevenue = paidDeliveredOrders.Sum(o => o.TotalAmount),
                    AverageOrderValue = allOrders.Any() ? allOrders.Average(o => o.TotalAmount) : 0
                };

                return new CommonResponse<OrderStatisticsSummary>
                {
                    Success = true,
                    Message = "Lấy thống kê tổng quan thành công",
                    Data = summary
                };
            }
            catch (Exception ex)
            {
                return new CommonResponse<OrderStatisticsSummary>
                {
                    Success = false,
                    Message = $"Lỗi: {ex.Message}"
                };
            }
        }

        public async Task<CommonResponse<RevenueReportRes>> GetRevenueReport(DateTime? fromDate, DateTime? toDate, string groupBy)
        {
            try
            {
                if (!fromDate.HasValue)
                    fromDate = DateTime.Now.AddMonths(-1).Date;
                if (!toDate.HasValue)
                    toDate = DateTime.Now.Date.AddDays(1).AddTicks(-1);

                var orders = await _orderRepository.AsQueryable()
                    .Include(o => o.OrderPayments)
                    .ThenInclude(op => op.Payment)
                    .Where(o => o.OrderDate >= fromDate && o.OrderDate <= toDate && o.Status == (int)OrderStatusEnums.Delivered)
                    .ToListAsync();

                var totalRevenue = orders.Sum(o => o.TotalAmount);
                var totalOrdersCount = orders.Count;
                var avgOrderValue = totalOrdersCount > 0 ? totalRevenue / totalOrdersCount : 0;

                // Revenue by date
                var revenueByDate = orders
                    .GroupBy(o => o.OrderDate.Date)
                    .Select(g => new RevenueByDateRes
                    {
                        Date = g.Key,
                        Revenue = g.Sum(o => o.TotalAmount),
                        OrderCount = g.Count()
                    })
                    .OrderBy(r => r.Date)
                    .ToList();

                // Revenue by status
                var revenueByStatus = orders
                    .GroupBy(o => o.Status)
                    .Select(g => new RevenueByStatusRes
                    {
                        Status = g.Key,
                        StatusText = GetStatusText(g.Key),
                        Revenue = g.Sum(o => o.TotalAmount),
                        OrderCount = g.Count()
                    })
                    .ToList();

                // Payment method stats
                var paymentStats = orders
                    .Where(o => o.OrderPayments.Any())
                    .Select(o => new { Order = o, Payment = o.OrderPayments.First().Payment })
                    .GroupBy(x => x.Payment.PaymentMethod)
                    .Select(g => new PaymentMethodStatsRes
                    {
                        PaymentMethod = GetPaymentMethodInt(g.Key),
                        PaymentMethodText = g.Key,
                        Revenue = g.Sum(x => x.Order.TotalAmount),
                        OrderCount = g.Count()
                    })
                    .ToList();

                var report = new RevenueReportRes
                {
                    TotalRevenue = totalRevenue,
                    TotalOrders = totalOrdersCount,
                    AverageOrderValue = avgOrderValue,
                    RevenueByDate = revenueByDate,
                    RevenueByStatus = revenueByStatus,
                    PaymentMethodStats = paymentStats
                };

                return new CommonResponse<RevenueReportRes>
                {
                    Success = true,
                    Message = "Lấy báo cáo doanh thu thành công",
                    Data = report
                };
            }
            catch (Exception ex)
            {
                return new CommonResponse<RevenueReportRes>
                {
                    Success = false,
                    Message = $"Lỗi: {ex.Message}"
                };
            }
        }

        public async Task<CommonResponse<List<AdminOrderListItem>>> SearchOrders(string keyword, int pageIndex, int pageSize)
        {
            return await GetAllOrders(pageIndex, pageSize, keyword, null, null, null, null, null, "orderDate", "desc");
        }

        public async Task<CommonResponse<List<AdminOrderListItem>>> GetOrdersByStatus(int status, int pageIndex, int pageSize)
        {
            return await GetAllOrders(pageIndex, pageSize, null, status, null, null, null, null, "orderDate", "desc");
        }

        public async Task<CommonResponse<List<AdminOrderListItem>>> GetOrdersByDateRange(DateTime fromDate, DateTime toDate, int pageIndex, int pageSize)
        {
            return await GetAllOrders(pageIndex, pageSize, null, null, null, null, fromDate, toDate, "orderDate", "desc");
        }

        public async Task<CommonResponse<BulkUpdateResult>> BulkUpdateStatus(List<int> orderIds, int newStatus, string? note)
        {
            var result = new BulkUpdateResult
            {
                SuccessCount = 0,
                FailedCount = 0,
                Details = new List<BulkUpdateDetail>()
            };

            foreach (var orderId in orderIds)
            {
                var updateResult = await UpdateOrderStatus(orderId, newStatus, note, HttpContextHelper.GetUserId().ToString());
                
                result.Details.Add(new BulkUpdateDetail
                {
                    OrderID = orderId,
                    Success = updateResult.Success,
                    ErrorMessage = updateResult.Success ? null : updateResult.Message
                });

                if (updateResult.Success)
                    result.SuccessCount++;
                else
                    result.FailedCount++;
            }

            return new CommonResponse<BulkUpdateResult>
            {
                Success = true,
                Message = $"Cập nhật thành công {result.SuccessCount}/{orderIds.Count} đơn hàng",
                Data = result
            };
        }

        // Helper methods
        private string GetStatusText(int status)
        {
            return status switch
            {
                0 => "Chờ xác nhận",
                1 => "Đã xác nhận",
                2 => "Đang xử lý",
                3 => "Đang giao",
                4 => "Đã giao",
                5 => "Đã hủy",
                6 => "Đã trả hàng",
                _ => "Không xác định"
            };
        }

        private string GetPaymentStatusText(int status)
        {
            return status switch
            {
                0 => "Chưa thanh toán",
                1 => "Đã thanh toán",
                2 => "Đã hoàn tiền",
                3 => "Thất bại",
                _ => "Không xác định"
            };
        }

        private int GetPaymentMethodInt(string paymentMethod)
        {
            return paymentMethod.ToUpper() switch
            {
                "COD" => (int)PaymentMethodEnums.COD,
                "VNPAY" => (int)PaymentMethodEnums.VNPAY,
                "GPAY" => (int)PaymentMethodEnums.GPAY,
                "PAYPAL" => (int)PaymentMethodEnums.PAYPAL,
                _ => (int)PaymentMethodEnums.COD
            };
        }

        private bool IsValidStatusTransition(int currentStatus, int newStatus)
        {
            // Pending can go to Confirmed or Cancelled
            if (currentStatus == (int)OrderStatusEnums.Pending)
                return newStatus == (int)OrderStatusEnums.Confirmed || newStatus == (int)OrderStatusEnums.Cancelled;

            // Confirmed can go to Processing, Shipped, or Cancelled
            if (currentStatus == (int)OrderStatusEnums.Confirmed)
                return newStatus == (int)OrderStatusEnums.Processing || 
                       newStatus == (int)OrderStatusEnums.Shipped || 
                       newStatus == (int)OrderStatusEnums.Cancelled;

            // Processing can go to Shipped only
            if (currentStatus == (int)OrderStatusEnums.Processing)
                return newStatus == (int)OrderStatusEnums.Shipped;

            // Shipped can go to Delivered only
            if (currentStatus == (int)OrderStatusEnums.Shipped)
                return newStatus == (int)OrderStatusEnums.Delivered;

            // Delivered can go to Returned
            if (currentStatus == (int)OrderStatusEnums.Delivered)
                return newStatus == (int)OrderStatusEnums.Returned;

            // Cancelled and Returned are final states
            return false;
        }

        private string GenerateTrackingNumber()
        {
            return $"TRK{DateTime.Now:yyyyMMddHHmmss}{new Random().Next(1000, 9999)}";
        }
    }
}
