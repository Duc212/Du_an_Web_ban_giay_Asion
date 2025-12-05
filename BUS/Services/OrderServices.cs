using BUS.Services.Interfaces;
using DAL;
using DAL.DTOs.Orders.Req;
using DAL.DTOs.Orders.Res;
using DAL.DTOs.Payments.Req;
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
        private readonly IRepositoryAsync<Voucher> _voucherRepository;
        private readonly IRepositoryAsync<Payment> _paymentRepository;
        private readonly IRepositoryAsync<OrderPayment> _orderPaymentRepository;
        private readonly IRepositoryAsync<Color> _colorRepository;
        private readonly IRepositoryAsync<Size> _sizeRepository;
        public OrderServices(
            IRepositoryAsync<Order> orderRepository,
            IRepositoryAsync<OrderDetail> orderDetailRepository,
            IRepositoryAsync<ProductVariant> variantRepository,
            IRepositoryAsync<Shipment> shipmentRepository,
            IUnitOfWork<AppDbContext> unitOfWork,
            IRepositoryAsync<User> userRepository,
            IRepositoryAsync<Address> addressRepository,
            IRepositoryAsync<Voucher> voucherRepository,
            IRepositoryAsync<Payment> paymentRepository,
            IRepositoryAsync<OrderPayment> orderPaymentRepository,
            IRepositoryAsync<Color> colorRepository,
            IRepositoryAsync<Size> sizeRepository)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _variantRepository = variantRepository;
            _shipmentRepository = shipmentRepository;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _addressRepository = addressRepository;
            _voucherRepository = voucherRepository;
            _paymentRepository = paymentRepository;
            _orderPaymentRepository = orderPaymentRepository;
            _colorRepository = colorRepository;
            _sizeRepository = sizeRepository;
        }
        public async Task<CommonPagination<List<GetOrderRes>>> GetOrdersByUserId(int userId, int CurrentPage, int RecordPerPage)
        {
            // Phân trang trước khi join để tối ưu hiệu năng
            var ordersPage = await _orderRepository.AsQueryable()
                .Where(o => o.UserID == userId)
                .OrderByDescending(o => o.OrderDate)
                .Skip((CurrentPage -1) * RecordPerPage)
                .Take(RecordPerPage)
                .ToListAsync();

            var orderIds = ordersPage.Select(o => o.OrderID).ToList();

            var orderDetails = await _orderDetailRepository.AsQueryable()
                .Where(od => orderIds.Contains(od.OrderID))
                .ToListAsync();

            var variantIds = orderDetails.Select(od => od.VariantID).Distinct().ToList();
            var variants = await _variantRepository.AsQueryable()
                .Where(v => variantIds.Contains(v.VariantID))
                .ToListAsync();

            var productIds = variants.Select(v => v.ProductID).Distinct().ToList();
            var products = await _variantRepository.DbContext.Set<Product>()
                .Where(p => productIds.Contains(p.ProductID))
                .ToListAsync();

            var brandIds = products.Select(p => p.BrandId).Distinct().ToList();
            var brands = await _variantRepository.DbContext.Set<Brand>()
                .Where(b => brandIds.Contains(b.BrandID))
                .ToListAsync();

            var sizeIds = variants.Where(v => v.SizeID.HasValue).Select(v => v.SizeID.Value).Distinct().ToList();
            var sizes = await _variantRepository.DbContext.Set<Size>()
                .Where(s => sizeIds.Contains(s.SizeID))
                .ToListAsync();

            var colorIds = variants.Where(v => v.ColorID.HasValue).Select(v => v.ColorID.Value).Distinct().ToList();
            var colors = await _variantRepository.DbContext.Set<Color>()
                .Where(c => colorIds.Contains(c.ColorID))
                .ToListAsync();

            var userIds = ordersPage.Select(o => o.UserID).Distinct().ToList();
            var users = await _userRepository.AsQueryable()
                .Where(u => userIds.Contains(u.UserID))
                .ToListAsync();

            var voucherIds = ordersPage.Where(o => o.VoucherID.HasValue).Select(o => o.VoucherID.Value).Distinct().ToList();
            var vouchers = voucherIds.Count >0
                ? await _voucherRepository.AsQueryable().Where(v => voucherIds.Contains(v.VoucherID)).ToListAsync()
                : new List<Voucher>();

            var addresses = await _addressRepository.AsQueryable()
                .Where(a => userIds.Contains(a.UserID))
                .ToListAsync();

            var orderPayments = await _orderPaymentRepository.AsQueryable()
                .Where(op => orderIds.Contains(op.OrderID))
                .ToListAsync();

            var paymentIds = orderPayments.Select(op => op.PaymentID).Distinct().ToList();
            var payments = await _paymentRepository.AsQueryable()
                .Where(p => paymentIds.Contains(p.PaymentID))
                .ToListAsync();

            var shipmentIds = ordersPage.Where(o => o.ShipmentID.HasValue).Select(o => o.ShipmentID.Value).Distinct().ToList();
            var shipments = shipmentIds.Count > 0
                ? await _shipmentRepository.AsQueryable().Where(s => shipmentIds.Contains(s.ShipmentID)).ToListAsync()
                : new List<Shipment>();

            var data = ordersPage.Select(o => {
                var user = users.FirstOrDefault(u => u.UserID == o.UserID);
                var address = addresses.FirstOrDefault(a => a.UserID == o.UserID);
                var voucher = o.VoucherID.HasValue ? vouchers.FirstOrDefault(v => v.VoucherID == o.VoucherID.Value) : null;
                var orderPayment = orderPayments.FirstOrDefault(op => op.OrderID == o.OrderID);
                var payment = orderPayment != null ? payments.FirstOrDefault(p => p.PaymentID == orderPayment.PaymentID) : null;
                var shipment = o.ShipmentID.HasValue ? shipments.FirstOrDefault(s => s.ShipmentID == o.ShipmentID.Value) : null;

                var orderItems = orderDetails.Where(od => od.OrderID == o.OrderID).ToList();
                decimal subTotal = orderItems.Sum(od => {
                    var variant = variants.FirstOrDefault(v => v.VariantID == od.VariantID);
                    return (variant?.SellingPrice ?? 0) * od.Quantity;
                });

                decimal shippingFee = 30000;
                decimal discount = voucher?.DiscountValue ?? 0;

                int paymentMethodInt = payment != null ? GetPaymentMethodInt(payment.PaymentMethod) : (int)PaymentMethodEnums.COD;

                return new GetOrderRes
                {
                    OrderId = o.OrderID.ToString(),
                    OrderNumber = o.OrderCode,
                    UserId = o.UserID?.ToString() ?? string.Empty,
                    ReceiverName = user?.FullName ?? string.Empty,
                    ReceiverPhone = user?.Phone ?? string.Empty,
                    ReceiverEmail = user?.Email ?? string.Empty,
                    ShippingAddress = address?.Street ?? o.Address ?? string.Empty,
                    Ward = address?.Ward,
                    District = address?.District,
                    City = address?.City,
                    Status = o.Status,
                    PaymentMethod = paymentMethodInt,
                    PaymentStatus = orderPayment?.Status ?? 0,
                    SubTotal = subTotal,
                    ShippingFee = shippingFee,
                    Discount = discount,
                    TotalAmount = o.TotalAmount,
                    CreatedAt = o.OrderDate,
                    Note = o.Note,
                    Items = orderItems.Select(od => {
                        var variant = variants.FirstOrDefault(v => v.VariantID == od.VariantID);
                        var product = products.FirstOrDefault(p => p.ProductID == variant?.ProductID);
                        var brand = brands.FirstOrDefault(b => b.BrandID == product?.BrandId);
                        var size = sizes.FirstOrDefault(s => s.SizeID == variant?.SizeID);
                        var color = colors.FirstOrDefault(c => c.ColorID == variant?.ColorID);
                        return new GetOrderItemRes
                        {
                            OrderItemId = od.OrderDetailID.ToString(),
                            ProductId = product?.ProductID ?? 0,
                            ProductName = product?.Name ?? string.Empty,
                            Brand = brand?.Name ?? string.Empty,
                            Quantity = od.Quantity,
                            Price = variant?.SellingPrice ?? 0,
                            SelectedSize = size?.Value ?? string.Empty,
                            SelectedColor = color?.Name ?? string.Empty,
                            ImageUrl = product?.ImageUrl ?? string.Empty
                        };
                    }).ToList()
                };
            }).ToList();

            return new CommonPagination<List<GetOrderRes>>
            {
                Success = true,
                Message = "Lấy danh sách đơn hàng thành công.",
                Data = new List<List<GetOrderRes>> { data },
                TotalRecords = await _orderRepository.AsQueryable().CountAsync(o => o.UserID == userId)
            };
        }

        // Helper methods để convert enum sang string
        private string GetOrderStatusString(int status)
        {
            return status switch
            {
                0 => "pending",
                1 => "confirmed",
                2 => "processing",
                3 => "shipping",
                4 => "delivered",
                5 => "cancelled",
                6 => "returned",
                _ => "pending"
            };
        }

        private string GetPaymentMethodString(string paymentMethod)
        {
            return paymentMethod.ToLower() switch
            {
                "cod" => "cod",
                "vnpay" => "vnpay",
                "gpay" => "wallet",
                "paypal" => "card",
                _ => "cod"
            };
        }

        private string GetPaymentStatusString(int status)
        {
            return status switch
            {
                0 => "pending",
                1 => "paid",
                2 => "refunded",
                3 => "failed",
                _ => "pending"
            };
        }

        private int GetPaymentMethodInt(string paymentMethod)
        {
            if (string.IsNullOrEmpty(paymentMethod))
                return (int)PaymentMethodEnums.COD;

            return paymentMethod.ToUpper() switch
            {
                "COD" => (int)PaymentMethodEnums.COD,
                "VNPAY" => (int)PaymentMethodEnums.VNPAY,
                "GPAY" => (int)PaymentMethodEnums.GPAY,
                "PAYPAL" => (int)PaymentMethodEnums.PAYPAL,
                _ => (int)PaymentMethodEnums.COD
            };
        }



        public async Task<CommonResponse<int>> CreateOrder(CreateOrderReq req)
        {
            try
            {
                Console.WriteLine($"[OrderServices.CreateOrder] Starting order creation - UserID={req.UserID}, OrderDetails count={req.OrderDetails?.Count ?? 0}");
                
                if (req.OrderDetails != null && req.OrderDetails.Any())
                {
                    foreach (var item in req.OrderDetails)
                    {
                        Console.WriteLine($"[OrderServices.CreateOrder] Request OrderDetail: VariantID={item.VariantID}, Qty={item.Quantity}");
                    }
                }
                
                int orderId = 0;
                await _unitOfWork.ExecuteInTransactionAsync(async () =>
                {
                    var order = new Order
                    {
                        UserID = req.UserID > 0 ? req.UserID : null,
                        VoucherID = req.VoucherID > 0 ? req.VoucherID : null,
                        OrderType = req.OrderType,
                        Address = req.Address,
                        Note = req.Note,
                        OrderDate = DateTime.Now,
                        Status = (int)OrderStatusEnums.Pending,
                        OrderCode = GenerateOrderCode(),
                        // GHN Address Fields
                        GhnProvinceId = req.GhnProvinceId,
                        GhnDistrictId = req.GhnDistrictId,
                        GhnWardCode = req.GhnWardCode,
                        GhnFullAddress = req.GhnFullAddress
                    };

                    await _orderRepository.AddAsync(order);
                    await _orderRepository.SaveChangesAsync();

                    decimal totalAmount = 0;
                    var orderDetails = new List<OrderDetail>();

                    foreach (var item in req.OrderDetails)
                    {
                        ProductVariant? variant = null;
                        
                        // Tìm variant theo VariantID (user đã login)
                        if (item.VariantID > 0)
                        {
                            variant = await _variantRepository.AsQueryable()
                                .Include(v => v.Product)
                                .Include(v => v.Color)
                                .Include(v => v.Size)
                                .FirstOrDefaultAsync(v => v.VariantID == item.VariantID);
                                
                            Console.WriteLine($"[CreateOrder] Looking for VariantID={item.VariantID}, Found={variant != null}");
                        }
                        // Tìm variant theo ProductID + Color + Size (guest user)
                        else if (item.ProductID.HasValue && !string.IsNullOrEmpty(item.SelectedColor) && !string.IsNullOrEmpty(item.SelectedSize))
                        {
                            variant = await (from v in _variantRepository.AsQueryable()
                                           join c in _colorRepository.AsQueryable() on v.ColorID equals c.ColorID
                                           join s in _sizeRepository.AsQueryable() on v.SizeID equals s.SizeID
                                           where v.ProductID == item.ProductID.Value &&
                                                 (c.HexCode == item.SelectedColor || c.Name == item.SelectedColor) &&
                                                 s.Value == item.SelectedSize
                                           select v)
                                .Include(v => v.Product)
                                .Include(v => v.Color)
                                .Include(v => v.Size)
                                .FirstOrDefaultAsync();
                                
                            Console.WriteLine($"[CreateOrder] Looking for ProductID={item.ProductID}, Color={item.SelectedColor}, Size={item.SelectedSize}, Found={variant != null}");
                        }

                        if (variant == null)
                            throw new Exception($"Không tìm thấy sản phẩm với thông tin: VariantID={item.VariantID}, ProductID={item.ProductID}, Color={item.SelectedColor}, Size={item.SelectedSize}");

                        if (variant.StockQuantity < item.Quantity)
                            throw new Exception($"Sản phẩm {variant.VariantID} không đủ hàng.");

                        // LOG: Debug thông tin variant
                        Console.WriteLine($"[CreateOrder] VariantID: {variant.VariantID}, Product: {variant.Product?.Name}, Color: {variant.Color?.Name}, Size: {variant.Size?.Value}, Price: {variant.SellingPrice}, Qty: {item.Quantity}");

                        variant.StockQuantity -= item.Quantity;
                        await _variantRepository.UpdateAsync(variant);

                        orderDetails.Add(new OrderDetail
                        {
                            OrderID = order.OrderID,
                            VariantID = variant.VariantID, // Dùng VariantID từ variant tìm được
                            Quantity = item.Quantity,
                            UnitPrice = variant.SellingPrice // Snapshot giá tại thời điểm đặt hàng
                        });

                        totalAmount += variant.SellingPrice * item.Quantity;
                    }

                    await _orderDetailRepository.AddRangeAsync(orderDetails);

                    order.TotalAmount = totalAmount;
                    await _orderRepository.UpdateAsync(order);

                    if (req.PaymentID.HasValue && req.PaymentID.Value > 0)
                    {
                        var payment = await _paymentRepository.AsQueryable()
                            .FirstOrDefaultAsync(p => p.PaymentID == req.PaymentID.Value);
                        if (payment == null)
                            throw new Exception($"PaymentID {req.PaymentID.Value} không tồn tại.");

                        var orderPayment = new OrderPayment
                        {
                            OrderID = order.OrderID,
                            PaymentID = payment.PaymentID,
                            Amount = totalAmount,
                            Status = (int)PaymentStatus.Unpaid,
                            Note = null
                        };
                        await _orderPaymentRepository.AddAsync(orderPayment);
                    }

                    await _variantRepository.SaveChangesAsync();
                    await _orderDetailRepository.SaveChangesAsync();
                    await _orderRepository.SaveChangesAsync();
                    await _orderPaymentRepository.SaveChangesAsync();

                    orderId = order.OrderID;
                });

                return new CommonResponse<int>
                {
                    Success = true,
                    Message = "Tạo đơn hàng thành công.",
                    Data = orderId
                };
            }
            catch (Exception ex)
            {
                return new CommonResponse<int>
                {
                    Success = false,
                    Message = $"Lỗi khi tạo đơn hàng: {ex.Message}",
                    Data = 0
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
                TotalRecords = totalRecords
            };
        }
        public async Task<CommonResponse<GetOrderDetailRes>> GetOrderDetail(int OrderID)
        {
            try
            {
                var query = from o in _orderRepository.Entities
                            join u in _userRepository.Entities on o.UserID equals u.UserID
                            join s in _shipmentRepository.Entities on o.ShipmentID equals s.ShipmentID into sh
                            from shipment in sh.DefaultIfEmpty()
                            join a in _addressRepository.Entities on o.UserID equals a.UserID into ad
                            from address in ad.DefaultIfEmpty()
                            join od in _orderDetailRepository.Entities on o.OrderID equals od.OrderID
                            join pv in _variantRepository.Entities on od.VariantID equals pv.VariantID
                            where o.OrderID == OrderID
                            select new { o, u, shipment, address, od, pv };

                var data = await query.ToListAsync();

                if (!data.Any())
                    return new CommonResponse<GetOrderDetailRes> { Success = false, Message = "Order not found" };

                var first = data.First();
                
                // L?y payment method t? OrderPayment n?u có
                var paymentMethod = await (from op in _orderRepository.DbContext.Set<OrderPayment>()
                                           join p in _orderRepository.DbContext.Set<Payment>() on op.PaymentID equals p.PaymentID
                                           where op.OrderID == OrderID
                                           select p.PaymentMethod)
                                           .FirstOrDefaultAsync();

                var orderRes = new GetOrderDetailRes
                {
                    OrderID = first.o.OrderID,
                    OrderCode = first.o.OrderCode,
                    UserName = first.u.Username,
                    FullName = first.u.FullName,
                    PhoneNumber = first.u.Phone,
                    PaymentMethod = paymentMethod ?? "Chua thanh toán",
                    ShippingProvider = first.shipment?.ShippingProvider,
                    TrackingNumber = first.shipment?.TrackingNumber,
                    ShippedDate = first.shipment?.ShippedDate,
                    VoucherCode = first.o.Voucher != null ? first.o.Voucher.VoucherCode : string.Empty,
                    OrderType = first.o.OrderType,
                    OrderDate = first.o.OrderDate,
                    Status = first.o.Status,
                    TotalAmount = first.o.TotalAmount,
                    Address = first.address != null ? $"{first.address.Street}, {first.address.Ward}, {first.address.City}" : null,
                    Note = first.o.Note,
                    ListProduct = data.Select(d => new GetProductDetailRes
                    {
                        ProductID = d.pv.Product.ProductID,
                        ProductName = d.pv.Product.Name,
                        imageUrl = d.pv.Product.ImageUrl,
                        GendersName = d.pv.Product.Gender.Name,
                        BrandName = d.pv.Product.Brand.Name,
                        ImportPrice = d.pv.ImportPrice,
                        SellingPrice = d.pv.SellingPrice,
                        Quantity = d.od.Quantity,
                        Value = d.pv.Size != null ? d.pv.Size.Value : ""
                    }).ToList()
                };

                return new CommonResponse<GetOrderDetailRes> { Success = true, Data = orderRes };
            }
            catch (Exception ex)
            {
                return new CommonResponse<GetOrderDetailRes> { Success = false, Message = ex.Message };
            }
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
                        Message = $"Không thể thay đổi trạng thái đơn hàng đã {(order.Status == (int)OrderStatusEnums.Delivered ? "Giao hàng" : "Hủy")}."
                    };
                }

                // Kiểm tra nếu hủy đơn hàng đã thanh toán -> tự động hoàn tiền
                if (req.Status == OrderStatusEnums.Cancelled)
                {
                    var orderPayment = await _orderPaymentRepository.AsQueryable()
                        .FirstOrDefaultAsync(op => op.OrderID == req.OrderID);

                    if (orderPayment != null && orderPayment.Status == (int)PaymentStatus.Paid)
                    {
                        // Cập nhật trạng thái thanh toán thành Refunded
                        orderPayment.Status = (int)PaymentStatus.Refunded;
                        orderPayment.Note = $"Đã hoàn tiền do hủy đơn hàng lúc {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
                        
                        await _orderPaymentRepository.UpdateAsync(orderPayment);
                        
                        // TODO: Tích hợp API hoàn tiền thực tế cho VNPay/PayPal/GPay tại đây
                        // Ví dụ: await _paymentService.ProcessRefundAsync(orderPayment);
                    }
                }

                order.Status = (int)req.Status;

                await _orderRepository.UpdateAsync(order);
                await _orderRepository.SaveChangesAsync();

                return new CommonResponse<bool>
                {
                    Success = true,
                    Message = req.Status == OrderStatusEnums.Cancelled && order != null
                        ? $"Đã hủy đơn hàng #{req.OrderID} và hoàn tiền (nếu đã thanh toán)."
                        : $"Cập nhật trạng thái đơn hàng #{req.OrderID} thành công: {req.Status}."
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
        public async Task<CommonResponse<DAL.DTOs.Orders.Res.ConfirmOrderResponse>> ConfirmOrderAsync(ConfirmOrderReq req)
        {
            try
            {
                var order = await _orderRepository.AsQueryable()
                    .FirstOrDefaultAsync(o => o.OrderID == req.OrderID);

                if (order == null)
                    return new CommonResponse<DAL.DTOs.Orders.Res.ConfirmOrderResponse> 
                    { 
                        Success = false, 
                        Message = "Không tìm thấy đơn hàng", 
                        Data = null 
                    };

                if (order.Status != (int)OrderStatusEnums.Pending)
                    return new CommonResponse<DAL.DTOs.Orders.Res.ConfirmOrderResponse> 
                    { 
                        Success = false, 
                        Message = "Đơn hàng không ở trạng thái chờ xác nhận", 
                        Data = null 
                    };

                await _unitOfWork.ExecuteInTransactionAsync(async () =>
                {
                    // Cập nhật trạng thái đơn hàng
                    order.Status = (int)OrderStatusEnums.Confirmed;
                    
                    // Thêm ghi chú nếu có
                    if (!string.IsNullOrEmpty(req.Note))
                    {
                        order.Note = string.IsNullOrEmpty(order.Note) 
                            ? $"[{DateTime.Now:dd/MM/yyyy HH:mm}] {req.Note}" 
                            : $"{order.Note}\n[{DateTime.Now:dd/MM/yyyy HH:mm}] {req.Note}";
                    }

                    Shipment shipment;
                    if (order.ShipmentID.HasValue)
                    {
                        // Cập nhật shipment hiện tại
                        shipment = await _shipmentRepository.AsQueryable()
                            .FirstOrDefaultAsync(s => s.ShipmentID == order.ShipmentID.Value);
                        
                        if (shipment != null)
                        {
                            shipment.ShippingProvider = req.ShippingProvider ?? shipment.ShippingProvider;
                            shipment.DeliveryStatus = 1; // Đã xác nhận
                            await _shipmentRepository.UpdateAsync(shipment);
                        }
                    }
                    else
                    {
                        // Tạo shipment mới
                        shipment = new Shipment
                        {
                            ShippingProvider = req.ShippingProvider ?? "Default Provider",
                            TrackingNumber = GenerateTrackingNumber(),
                            DeliveryStatus = 1, // Đã xác nhận
                            ShippedDate = null
                        };

                        await _shipmentRepository.AddAsync(shipment);
                        await _shipmentRepository.SaveChangesAsync();

                        order.ShipmentID = shipment.ShipmentID;
                    }

                    await _orderRepository.UpdateAsync(order);
                    await _orderRepository.SaveChangesAsync();
                    await _shipmentRepository.SaveChangesAsync();
                });

                // Lấy lại shipment để trả về tracking number
                var finalShipment = await _shipmentRepository.AsQueryable()
                    .FirstOrDefaultAsync(s => s.ShipmentID == order.ShipmentID);

                return new CommonResponse<DAL.DTOs.Orders.Res.ConfirmOrderResponse>
                {
                    Success = true,
                    Message = "Xác nhận đơn hàng thành công",
                    Data = new DAL.DTOs.Orders.Res.ConfirmOrderResponse
                    {
                        TrackingNumber = finalShipment?.TrackingNumber ?? "",
                        ShipmentID = finalShipment?.ShipmentID ?? 0
                    }
                };
            }
            catch (Exception ex)
            {
                return new CommonResponse<DAL.DTOs.Orders.Res.ConfirmOrderResponse>
                {
                    Success = false,
                    Message = $"Lỗi: {ex.Message}",
                    Data = null
                };
            }
        }

        private string GenerateTrackingNumber()
        {
            return $"TRK-{Guid.NewGuid().ToString("N")[..12].ToUpper()}";
        }

        private string GenerateOrderCode()
        {
            return $"ORD-{Guid.NewGuid().ToString("N")[..10].ToUpper()}";
        }

        public async Task<CommonResponse<bool>> UpdateStatusPayment(UpdatePaymentReq req)
        {
            try
            {
                var order = await _orderRepository.AsQueryable()
                    .FirstOrDefaultAsync(x => x.OrderID == req.OrderId);
                if (order == null)
                {
                    return new CommonResponse<bool>
                    {
                        Success = false,
                        Message = $"Không tìm thấy đơn hàng với ID = {req.OrderId}.",
                        Data = false
                    };
                }

                var orderPayment = await _orderPaymentRepository.AsQueryable()
                    .FirstOrDefaultAsync(op => op.OrderID == req.OrderId);
                if (orderPayment == null)
                {
                    return new CommonResponse<bool>
                    {
                        Success = false,
                        Message = $"Không tìm thấy thông tin thanh toán cho đơn hàng với ID = {req.OrderId}.",
                        Data = false
                    };
                }

                if (!Enum.IsDefined(typeof(PaymentStatus), req.Status))
                {
                    return new CommonResponse<bool>
                    {
                        Success = false,
                        Message = "Trạng thái thanh toán không hợp lệ.",
                        Data = false
                    };
                }

                orderPayment.Status = (int)req.Status;
                await _orderPaymentRepository.UpdateAsync(orderPayment);
                await _orderPaymentRepository.SaveChangesAsync();

                return new CommonResponse<bool>
                {
                    Success = true,
                    Message = "Cập nhật trạng thái thanh toán thành công.",
                    Data = true
                };
            }
            catch (Exception ex)
            {
                return new CommonResponse<bool>
                {
                    Success = false,
                    Message = $"Lỗi khi cập nhật trạng thái thanh toán: {ex.Message}",
                    Data = false
                };
            }
        }

        public async Task<CommonResponse<GetOrderStatisticsRes>> GetOrderStatistics(DateTime? fromDate = null, DateTime? toDate = null)
        {
            var response = new CommonResponse<GetOrderStatisticsRes>();

            try
            {
                // Set default date range if not provided
                if (!fromDate.HasValue)
                    fromDate = DateTime.Now.AddMonths(-1);
                if (!toDate.HasValue)
                    toDate = DateTime.Now;

                // Ensure fromDate is start of day and toDate is end of day
                fromDate = fromDate.Value.Date;
                toDate = toDate.Value.Date.AddDays(1).AddTicks(-1);

                // Get all orders in date range
                var orders = await _orderRepository.AsNoTrackingQueryable()
                    .Where(o => o.OrderDate >= fromDate && o.OrderDate <= toDate)
                    .ToListAsync();

                var totalOrders = orders.Count;

                // Count by status
                var pendingOrders = orders.Count(o => o.Status == (int)OrderStatusEnums.Pending);
                var confirmedOrders = orders.Count(o => o.Status == (int)OrderStatusEnums.Confirmed);
                var shippingOrders = orders.Count(o => o.Status == (int)OrderStatusEnums.Shipped);
                var deliveredOrders = orders.Count(o => o.Status == (int)OrderStatusEnums.Delivered);
                var cancelledOrders = orders.Count(o => o.Status == (int)OrderStatusEnums.Cancelled);

                // Calculate revenue (only from delivered orders)
                var deliveredOrderIds = orders.Where(o => o.Status == (int)OrderStatusEnums.Delivered)
                    .Select(o => o.OrderID)
                    .ToList();

                var totalRevenue = orders.Where(o => o.Status == (int)OrderStatusEnums.Delivered)
                    .Sum(o => o.TotalAmount);

                var averageOrderValue = deliveredOrders > 0 ? totalRevenue / deliveredOrders : 0;

                // Payment statistics
                var orderPayments = await _orderPaymentRepository.AsNoTrackingQueryable()
                    .Where(op => deliveredOrderIds.Contains(op.OrderID))
                    .ToListAsync();

                var paymentIds = orderPayments.Select(op => op.PaymentID).Distinct().ToList();
                var payments = await _paymentRepository.AsNoTrackingQueryable()
                    .Where(p => paymentIds.Contains(p.PaymentID))
                    .ToListAsync();

                var paymentStats = new PaymentStatsInfo();

                foreach (var op in orderPayments)
                {
                    var payment = payments.FirstOrDefault(p => p.PaymentID == op.PaymentID);
                    if (payment != null)
                    {
                        var order = orders.FirstOrDefault(o => o.OrderID == op.OrderID);
                        if (order != null && order.Status == (int)OrderStatusEnums.Delivered)
                        {
                            switch (payment.PaymentMethod.ToUpper())
                            {
                                case "COD":
                                    paymentStats.COD.Count++;
                                    paymentStats.COD.Total += order.TotalAmount;
                                    break;
                                case "VNPAY":
                                    paymentStats.VNPAY.Count++;
                                    paymentStats.VNPAY.Total += order.TotalAmount;
                                    break;
                                case "GPAY":
                                    paymentStats.GPAY.Count++;
                                    paymentStats.GPAY.Total += order.TotalAmount;
                                    break;
                                case "PAYPAL":
                                    paymentStats.PAYPAL.Count++;
                                    paymentStats.PAYPAL.Total += order.TotalAmount;
                                    break;
                            }
                        }
                    }
                }

                // Daily orders statistics
                var dailyOrders = orders
                    .Where(o => o.Status == (int)OrderStatusEnums.Delivered)
                    .GroupBy(o => o.OrderDate.Date)
                    .Select(g => new DailyOrderInfo
                    {
                        Date = g.Key,
                        OrderCount = g.Count(),
                        Revenue = g.Sum(o => o.TotalAmount)
                    })
                    .OrderBy(d => d.Date)
                    .ToList();

                // Top products statistics
                var orderIds = orders.Select(o => o.OrderID).ToList();
                var orderDetails = await _orderDetailRepository.AsNoTrackingQueryable()
                    .Where(od => orderIds.Contains(od.OrderID))
                    .ToListAsync();

                var variantIds = orderDetails.Select(od => od.VariantID).Distinct().ToList();
                var variants = await _variantRepository.AsNoTrackingQueryable()
                    .Where(v => variantIds.Contains(v.VariantID))
                    .ToListAsync();

                var productIds = variants.Select(v => v.ProductID).Distinct().ToList();
                var products = await _variantRepository.DbContext.Set<Product>()
                    .Where(p => productIds.Contains(p.ProductID))
                    .ToListAsync();

                var topProducts = orderDetails
                    .GroupBy(od => od.VariantID)
                    .Select(g =>
                    {
                        var variant = variants.FirstOrDefault(v => v.VariantID == g.Key);
                        var product = products.FirstOrDefault(p => p.ProductID == variant.ProductID);
                        
                        return new
                        {
                            ProductID = product?.ProductID ?? 0,
                            ProductName = product?.Name ?? "",
                            ImageUrl = product?.ImageUrl ?? "",
                            OrderCount = g.Select(od => od.OrderID).Distinct().Count(),
                            TotalQuantity = g.Sum(od => od.Quantity),
                            Revenue = g.Sum(od => od.Quantity * (variant?.SellingPrice ?? 0))
                        };
                    })
                    .GroupBy(x => x.ProductID)
                    .Select(g => new TopProductInfo
                    {
                        ProductID = g.Key,
                        ProductName = g.First().ProductName,
                        ImageUrl = g.First().ImageUrl,
                        OrderCount = g.Sum(x => x.OrderCount),
                        TotalQuantity = g.Sum(x => x.TotalQuantity),
                        Revenue = g.Sum(x => x.Revenue)
                    })
                    .OrderByDescending(p => p.Revenue)
                    .Take(10)
                    .ToList();

                // Customer Growth statistics
                var customerGrowth = new List<CustomerGrowthInfo>();
                var allUsers = await _userRepository.AsNoTrackingQueryable()
                    .Where(u => u.CreatedAt >= fromDate && u.CreatedAt <= toDate)
                    .ToListAsync();

                // Get all customer IDs who have placed orders
                var customerIdsWithOrders = orders.Select(o => o.UserID).Distinct().ToList();
                
                // Group by date to calculate daily customer growth
                var dailyStats = new List<CustomerGrowthInfo>();
                var currentDate = fromDate.Value.Date;
                var cumulativeCustomers = await _userRepository.AsNoTrackingQueryable()
                    .Where(u => u.CreatedAt < fromDate)
                    .CountAsync();

                while (currentDate <= toDate.Value.Date)
                {
                    // New customers registered on this date
                    var newCustomersOnDate = allUsers.Count(u => u.CreatedAt.Date == currentDate);
                    
                    // Returning customers (placed order on this date but registered before)
                    var ordersOnDate = orders.Where(o => o.OrderDate.Date == currentDate).ToList();
                    var customersOrderedOnDate = ordersOnDate.Select(o => o.UserID).Distinct().ToList();
                    var returningCustomers = customersOrderedOnDate
                        .Count(cId => cId.HasValue && allUsers.All(u => u.UserID != cId.Value || u.CreatedAt.Date < currentDate));
                    
                    cumulativeCustomers += newCustomersOnDate;
                    
                    dailyStats.Add(new CustomerGrowthInfo
                    {
                        Date = currentDate,
                        NewCustomers = newCustomersOnDate,
                        ReturningCustomers = returningCustomers,
                        TotalCustomers = cumulativeCustomers
                    });
                    
                    currentDate = currentDate.AddDays(1);
                }

                customerGrowth = dailyStats;

                response.Success = true;
                response.Message = "Lấy thống kê đơn hàng thành công";
                response.Data = new GetOrderStatisticsRes
                {
                    TotalOrders = totalOrders,
                    PendingOrders = pendingOrders,
                    ConfirmedOrders = confirmedOrders,
                    ShippingOrders = shippingOrders,
                    DeliveredOrders = deliveredOrders,
                    CancelledOrders = cancelledOrders,
                    TotalRevenue = totalRevenue,
                    AverageOrderValue = averageOrderValue,
                    PaymentStats = paymentStats,
                    DailyOrders = dailyOrders,
                    TopProducts = topProducts,
                    CustomerGrowth = customerGrowth
                };
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Lỗi khi lấy thống kê: {ex.Message}";
                response.Data = null;
            }

            return response;
        }
    }
}
