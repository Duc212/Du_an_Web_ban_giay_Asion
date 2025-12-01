using BUS.Services.Interfaces;
using DAL;
using DAL.DTOs.Sizes.Req;
using DAL.DTOs.Sizes.Res;
using DAL.Entities;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BUS.Services
{
    public class SizeService : ISizeService
    {
        private readonly AppDbContext _context;

        public SizeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CommonPagination<GetSizeRes>> GetSizesPaged(int pageIndex, int pageSize, string? keyword)
        {
            try
            {
                var query = _context.Sizes.AsQueryable();

                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    query = query.Where(s => s.Value.Contains(keyword));
                }

                var totalRecords = await query.CountAsync();

                var sizes = await query
                    .OrderBy(s => s.Value)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .Select(s => new GetSizeRes
                    {
                        SizeID = s.SizeID,
                        Value = s.Value,
                        ProductCount = _context.ProductVariants.Count(pv => pv.SizeID == s.SizeID)
                    })
                    .ToListAsync();

                return new CommonPagination<GetSizeRes>
                {
                    Success = true,
                    Message = "Lấy danh sách size thành công",
                    Data = sizes,
                    TotalRecords = totalRecords
                };
            }
            catch (Exception ex)
            {
                return new CommonPagination<GetSizeRes>
                {
                    Success = false,
                    Message = $"Lỗi: {ex.Message}",
                    Data = new List<GetSizeRes>(),
                    TotalRecords = 0
                };
            }
        }

        public async Task<CommonResponse<GetSizeRes>> GetSizeById(int sizeId)
        {
            try
            {
                var size = await _context.Sizes
                    .Where(s => s.SizeID == sizeId)
                    .Select(s => new GetSizeRes
                    {
                        SizeID = s.SizeID,
                        Value = s.Value,
                        ProductCount = _context.ProductVariants.Count(pv => pv.SizeID == s.SizeID)
                    })
                    .FirstOrDefaultAsync();

                if (size == null)
                {
                    return new CommonResponse<GetSizeRes>
                    {
                        Success = false,
                        Message = "Không tìm thấy size",
                        Data = null
                    };
                }

                return new CommonResponse<GetSizeRes>
                {
                    Success = true,
                    Message = "Lấy thông tin size thành công",
                    Data = size
                };
            }
            catch (Exception ex)
            {
                return new CommonResponse<GetSizeRes>
                {
                    Success = false,
                    Message = $"Lỗi: {ex.Message}",
                    Data = null
                };
            }
        }

        public async Task<CommonResponse<bool>> AddSize(AddSizeReq req)
        {
            try
            {
                // Kiểm tra trùng giá trị
                var existing = await _context.Sizes
                    .AnyAsync(s => s.Value.ToLower() == req.Value.ToLower());

                if (existing)
                {
                    return new CommonResponse<bool>
                    {
                        Success = false,
                        Message = "Size đã tồn tại",
                        Data = false
                    };
                }

                var size = new Size
                {
                    Value = req.Value.Trim()
                };

                _context.Sizes.Add(size);
                await _context.SaveChangesAsync();

                return new CommonResponse<bool>
                {
                    Success = true,
                    Message = "Thêm size thành công",
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

        public async Task<CommonResponse<bool>> UpdateSize(UpdateSizeReq req)
        {
            try
            {
                var size = await _context.Sizes.FindAsync(req.SizeID);

                if (size == null)
                {
                    return new CommonResponse<bool>
                    {
                        Success = false,
                        Message = "Không tìm thấy size",
                        Data = false
                    };
                }

                // Kiểm tra trùng giá trị (ngoại trừ chính nó)
                var existing = await _context.Sizes
                    .AnyAsync(s => s.Value.ToLower() == req.Value.ToLower() && s.SizeID != req.SizeID);

                if (existing)
                {
                    return new CommonResponse<bool>
                    {
                        Success = false,
                        Message = "Size đã tồn tại",
                        Data = false
                    };
                }

                size.Value = req.Value.Trim();

                await _context.SaveChangesAsync();

                return new CommonResponse<bool>
                {
                    Success = true,
                    Message = "Cập nhật size thành công",
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

        public async Task<CommonResponse<bool>> DeleteSize(int sizeId)
        {
            try
            {
                var size = await _context.Sizes.FindAsync(sizeId);

                if (size == null)
                {
                    return new CommonResponse<bool>
                    {
                        Success = false,
                        Message = "Không tìm thấy size",
                        Data = false
                    };
                }

                // Kiểm tra xem có sản phẩm nào đang sử dụng size này không
                var hasProducts = await _context.ProductVariants
                    .AnyAsync(pv => pv.SizeID == sizeId);

                if (hasProducts)
                {
                    return new CommonResponse<bool>
                    {
                        Success = false,
                        Message = "Không thể xóa size đang được sử dụng bởi sản phẩm",
                        Data = false
                    };
                }

                _context.Sizes.Remove(size);
                await _context.SaveChangesAsync();

                return new CommonResponse<bool>
                {
                    Success = true,
                    Message = "Xóa size thành công",
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
    }
}
