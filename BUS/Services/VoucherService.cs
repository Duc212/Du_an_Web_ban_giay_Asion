using DAL.DTOs.Vouchers.Req;
using DAL.DTOs.Vouchers.Res;
using DAL.Entities;
using DAL.Models;
using DAL.Repositories;
using DAL.RepositoryAsyns;
using Microsoft.EntityFrameworkCore;

namespace BUS.Services
{
    public interface IVoucherService
    {
        Task<CommonResponse<List<GetVoucherRes>>> GetAllVouchers();
        Task<CommonResponse<GetVoucherRes>> GetVoucherById(int id);
        Task<CommonResponse<string>> CreateVoucher(CreateVoucherReq request);
        Task<CommonResponse<string>> UpdateVoucher(UpdateVoucherReq request);
        Task<CommonResponse<string>> DeleteVoucher(int id);
        Task<CommonResponse<ValidateVoucherRes>> ValidateVoucher(ValidateVoucherReq request);
    }

    public class VoucherService : IVoucherService
    {
        private readonly IRepositoryAsync<Voucher> _voucherRepository;
        private readonly VoucherRepository _voucherHelper;

        public VoucherService(IRepositoryAsync<Voucher> voucherRepository, VoucherRepository voucherHelper)
        {
            _voucherRepository = voucherRepository;
            _voucherHelper = voucherHelper;
        }

        public async Task<CommonResponse<List<GetVoucherRes>>> GetAllVouchers()
        {
            try
            {
                var vouchers = await _voucherRepository.AsNoTrackingQueryable()
                    .OrderByDescending(v => v.StartDate)
                    .ToListAsync();
                
                var result = new List<GetVoucherRes>();

                foreach (var voucher in vouchers)
                {
                    var usedCount = await _voucherHelper.GetUsedCountAsync(voucher.VoucherID);
                    result.Add(new GetVoucherRes
                    {
                        VoucherID = voucher.VoucherID,
                        VoucherCode = voucher.VoucherCode,
                        Name = voucher.Name,
                        DiscountValue = voucher.DiscountValue,
                        DiscountType = voucher.DiscountType,
                        MinOrderAmount = voucher.MinOrderAmount,
                        MaxDiscountAmount = voucher.MaxDiscountAmount,
                        Quantity = voucher.Quantity,
                        UsedCount = usedCount,
                        StartDate = voucher.StartDate,
                        EndDate = voucher.EndDate,
                        Status = voucher.Status
                    });
                }

                return new CommonResponse<List<GetVoucherRes>>
                {
                    Success = true,
                    Message = "Lấy danh sách voucher thành công",
                    Data = result
                };
            }
            catch (Exception ex)
            {
                return new CommonResponse<List<GetVoucherRes>>
                {
                    Success = false,
                    Message = $"Lỗi: {ex.Message}",
                    Data = null
                };
            }
        }

        public async Task<CommonResponse<GetVoucherRes>> GetVoucherById(int id)
        {
            try
            {
                var voucher = await _voucherRepository.AsNoTrackingQueryable()
                    .FirstOrDefaultAsync(v => v.VoucherID == id);
                
                if (voucher == null)
                {
                    return new CommonResponse<GetVoucherRes>
                    {
                        Success = false,
                        Message = "Không tìm thấy voucher",
                        Data = null
                    };
                }

                var usedCount = await _voucherHelper.GetUsedCountAsync(voucher.VoucherID);
                var result = new GetVoucherRes
                {
                    VoucherID = voucher.VoucherID,
                    VoucherCode = voucher.VoucherCode,
                    Name = voucher.Name,
                    DiscountValue = voucher.DiscountValue,
                    DiscountType = voucher.DiscountType,
                    MinOrderAmount = voucher.MinOrderAmount,
                    MaxDiscountAmount = voucher.MaxDiscountAmount,
                    Quantity = voucher.Quantity,
                    UsedCount = usedCount,
                    StartDate = voucher.StartDate,
                    EndDate = voucher.EndDate,
                    Status = voucher.Status
                };

                return new CommonResponse<GetVoucherRes>
                {
                    Success = true,
                    Message = "Lấy thông tin voucher thành công",
                    Data = result
                };
            }
            catch (Exception ex)
            {
                return new CommonResponse<GetVoucherRes>
                {
                    Success = false,
                    Message = $"Lỗi: {ex.Message}",
                    Data = null
                };
            }
        }

        public async Task<CommonResponse<string>> CreateVoucher(CreateVoucherReq request)
        {
            try
            {
                // Validate dates
                if (request.StartDate >= request.EndDate)
                {
                    return new CommonResponse<string>
                    {
                        Success = false,
                        Message = "Ngày kết thúc phải sau ngày bắt đầu",
                        Data = null
                    };
                }

                // Check if voucher code already exists
                var codeExists = await _voucherHelper.IsCodeExistsAsync(request.VoucherCode);
                if (codeExists)
                {
                    return new CommonResponse<string>
                    {
                        Success = false,
                        Message = "Mã voucher đã tồn tại",
                        Data = null
                    };
                }

                // Validate discount type
                if (request.DiscountType != "Percentage" && request.DiscountType != "FixedAmount")
                {
                    return new CommonResponse<string>
                    {
                        Success = false,
                        Message = "Loại giảm giá không hợp lệ. Chỉ chấp nhận 'Percentage' hoặc 'FixedAmount'",
                        Data = null
                    };
                }

                // Validate percentage discount
                if (request.DiscountType == "Percentage" && (request.DiscountValue < 0 || request.DiscountValue > 100))
                {
                    return new CommonResponse<string>
                    {
                        Success = false,
                        Message = "Giá trị giảm giá phần trăm phải từ 0 đến 100",
                        Data = null
                    };
                }

                var voucher = new Voucher
                {
                    VoucherCode = request.VoucherCode.ToUpper().Trim(),
                    Name = request.Name.Trim(),
                    DiscountValue = request.DiscountValue,
                    DiscountType = request.DiscountType,
                    MinOrderAmount = request.MinOrderAmount,
                    MaxDiscountAmount = request.MaxDiscountAmount,
                    Quantity = request.Quantity,
                    StartDate = request.StartDate,
                    EndDate = request.EndDate,
                    Status = request.Status
                };

                await _voucherRepository.AddAsync(voucher);
                await _voucherRepository.SaveChangesAsync();

                return new CommonResponse<string>
                {
                    Success = true,
                    Message = "Tạo voucher thành công",
                    Data = voucher.VoucherCode
                };
            }
            catch (Exception ex)
            {
                return new CommonResponse<string>
                {
                    Success = false,
                    Message = $"Lỗi: {ex.Message}",
                    Data = null
                };
            }
        }

        public async Task<CommonResponse<string>> UpdateVoucher(UpdateVoucherReq request)
        {
            try
            {
                var voucher = await _voucherRepository.AsQueryable()
                    .FirstOrDefaultAsync(v => v.VoucherID == request.VoucherID);
                
                if (voucher == null)
                {
                    return new CommonResponse<string>
                    {
                        Success = false,
                        Message = "Không tìm thấy voucher",
                        Data = null
                    };
                }

                // Validate dates
                if (request.StartDate >= request.EndDate)
                {
                    return new CommonResponse<string>
                    {
                        Success = false,
                        Message = "Ngày kết thúc phải sau ngày bắt đầu",
                        Data = null
                    };
                }

                // Check if voucher code exists (excluding current voucher)
                var codeExists = await _voucherHelper.IsCodeExistsAsync(request.VoucherCode, request.VoucherID);
                if (codeExists)
                {
                    return new CommonResponse<string>
                    {
                        Success = false,
                        Message = "Mã voucher đã tồn tại",
                        Data = null
                    };
                }

                // Validate discount type
                if (request.DiscountType != "Percentage" && request.DiscountType != "FixedAmount")
                {
                    return new CommonResponse<string>
                    {
                        Success = false,
                        Message = "Loại giảm giá không hợp lệ",
                        Data = null
                    };
                }

                // Validate percentage discount
                if (request.DiscountType == "Percentage" && (request.DiscountValue < 0 || request.DiscountValue > 100))
                {
                    return new CommonResponse<string>
                    {
                        Success = false,
                        Message = "Giá trị giảm giá phần trăm phải từ 0 đến 100",
                        Data = null
                    };
                }

                voucher.VoucherCode = request.VoucherCode.ToUpper().Trim();
                voucher.Name = request.Name.Trim();
                voucher.DiscountValue = request.DiscountValue;
                voucher.DiscountType = request.DiscountType;
                voucher.MinOrderAmount = request.MinOrderAmount;
                voucher.MaxDiscountAmount = request.MaxDiscountAmount;
                voucher.Quantity = request.Quantity;
                voucher.StartDate = request.StartDate;
                voucher.EndDate = request.EndDate;
                voucher.Status = request.Status;

                await _voucherRepository.UpdateAsync(voucher);
                await _voucherRepository.SaveChangesAsync();

                return new CommonResponse<string>
                {
                    Success = true,
                    Message = "Cập nhật voucher thành công",
                    Data = voucher.VoucherCode
                };
            }
            catch (Exception ex)
            {
                return new CommonResponse<string>
                {
                    Success = false,
                    Message = $"Lỗi: {ex.Message}",
                    Data = null
                };
            }
        }

        public async Task<CommonResponse<string>> DeleteVoucher(int id)
        {
            try
            {
                var voucher = await _voucherRepository.AsQueryable()
                    .FirstOrDefaultAsync(v => v.VoucherID == id);
                
                if (voucher == null)
                {
                    return new CommonResponse<string>
                    {
                        Success = false,
                        Message = "Không tìm thấy voucher",
                        Data = null
                    };
                }

                // Check if voucher has been used
                var usedCount = await _voucherHelper.GetUsedCountAsync(id);
                if (usedCount > 0)
                {
                    return new CommonResponse<string>
                    {
                        Success = false,
                        Message = $"Không thể xóa voucher đã được sử dụng {usedCount} lần",
                        Data = null
                    };
                }

                await _voucherRepository.RemoveAsync(voucher);
                await _voucherRepository.SaveChangesAsync();

                return new CommonResponse<string>
                {
                    Success = true,
                    Message = "Xóa voucher thành công",
                    Data = voucher.VoucherCode
                };
            }
            catch (Exception ex)
            {
                return new CommonResponse<string>
                {
                    Success = false,
                    Message = $"Lỗi: {ex.Message}",
                    Data = null
                };
            }
        }

        public async Task<CommonResponse<ValidateVoucherRes>> ValidateVoucher(ValidateVoucherReq request)
        {
            try
            {
                var voucherCode = request.VoucherCode.ToUpper().Trim();
                var voucher = await _voucherRepository.AsNoTrackingQueryable()
                    .FirstOrDefaultAsync(v => v.VoucherCode == voucherCode);

                if (voucher == null)
                {
                    return new CommonResponse<ValidateVoucherRes>
                    {
                        Success = false,
                        Message = "Mã voucher không tồn tại",
                        Data = new ValidateVoucherRes { IsValid = false, Message = "Mã voucher không tồn tại" }
                    };
                }

                // Check if voucher is active
                if (voucher.Status != "Active")
                {
                    return new CommonResponse<ValidateVoucherRes>
                    {
                        Success = false,
                        Message = "Voucher không còn hiệu lực",
                        Data = new ValidateVoucherRes { IsValid = false, Message = "Voucher không còn hiệu lực" }
                    };
                }

                // Check date validity
                var now = DateTime.Now;
                if (now < voucher.StartDate)
                {
                    return new CommonResponse<ValidateVoucherRes>
                    {
                        Success = false,
                        Message = "Voucher chưa đến ngày sử dụng",
                        Data = new ValidateVoucherRes { IsValid = false, Message = $"Voucher có hiệu lực từ {voucher.StartDate:dd/MM/yyyy}" }
                    };
                }

                if (now > voucher.EndDate)
                {
                    return new CommonResponse<ValidateVoucherRes>
                    {
                        Success = false,
                        Message = "Voucher đã hết hạn",
                        Data = new ValidateVoucherRes { IsValid = false, Message = "Voucher đã hết hạn sử dụng" }
                    };
                }

                // Check quantity
                var usedCount = await _voucherHelper.GetUsedCountAsync(voucher.VoucherID);
                if (usedCount >= voucher.Quantity)
                {
                    return new CommonResponse<ValidateVoucherRes>
                    {
                        Success = false,
                        Message = "Voucher đã hết lượt sử dụng",
                        Data = new ValidateVoucherRes { IsValid = false, Message = "Voucher đã hết lượt sử dụng" }
                    };
                }

                // Check minimum order amount
                if (voucher.MinOrderAmount.HasValue && request.OrderAmount < voucher.MinOrderAmount.Value)
                {
                    return new CommonResponse<ValidateVoucherRes>
                    {
                        Success = false,
                        Message = $"Đơn hàng tối thiểu {voucher.MinOrderAmount.Value:N0}đ để sử dụng voucher này",
                        Data = new ValidateVoucherRes 
                        { 
                            IsValid = false, 
                            Message = $"Đơn hàng tối thiểu {voucher.MinOrderAmount.Value:N0}đ",
                            MinOrderAmount = voucher.MinOrderAmount
                        }
                    };
                }

                // Calculate discount
                decimal calculatedDiscount = 0;
                if (voucher.DiscountType == "Percentage")
                {
                    calculatedDiscount = request.OrderAmount * (voucher.DiscountValue / 100);
                    // Apply max discount limit if specified
                    if (voucher.MaxDiscountAmount.HasValue && calculatedDiscount > voucher.MaxDiscountAmount.Value)
                    {
                        calculatedDiscount = voucher.MaxDiscountAmount.Value;
                    }
                }
                else if (voucher.DiscountType == "FixedAmount")
                {
                    calculatedDiscount = voucher.DiscountValue;
                }

                // Ensure discount doesn't exceed order amount
                if (calculatedDiscount > request.OrderAmount)
                {
                    calculatedDiscount = request.OrderAmount;
                }

                return new CommonResponse<ValidateVoucherRes>
                {
                    Success = true,
                    Message = "Áp dụng voucher thành công",
                    Data = new ValidateVoucherRes
                    {
                        IsValid = true,
                        Message = $"Giảm giá {calculatedDiscount:N0}đ",
                        VoucherID = voucher.VoucherID,
                        VoucherCode = voucher.VoucherCode,
                        Name = voucher.Name,
                        DiscountValue = voucher.DiscountValue,
                        DiscountType = voucher.DiscountType,
                        CalculatedDiscount = calculatedDiscount,
                        MinOrderAmount = voucher.MinOrderAmount,
                        MaxDiscountAmount = voucher.MaxDiscountAmount
                    }
                };
            }
            catch (Exception ex)
            {
                return new CommonResponse<ValidateVoucherRes>
                {
                    Success = false,
                    Message = $"Lỗi: {ex.Message}",
                    Data = new ValidateVoucherRes { IsValid = false, Message = "Có lỗi xảy ra khi kiểm tra voucher" }
                };
            }
        }
    }
}
