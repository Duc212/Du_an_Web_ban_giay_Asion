using BUS.Services.Interfaces;
using DAL;
using DAL.DTOs.Colors.Req;
using DAL.DTOs.Colors.Res;
using DAL.Entities;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BUS.Services
{
    public class ColorService : IColorService
    {
        private readonly AppDbContext _context;

        public ColorService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CommonPagination<GetColorRes>> GetColorsPaged(int pageIndex, int pageSize, string? keyword)
        {
            try
            {
                var query = _context.Colors.AsQueryable();

                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    query = query.Where(c => c.Name.Contains(keyword) || c.HexCode.Contains(keyword));
                }

                var totalRecords = await query.CountAsync();

                var colors = await query
                    .OrderBy(c => c.Name)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .Select(c => new GetColorRes
                    {
                        ColorID = c.ColorID,
                        Name = c.Name,
                        HexCode = c.HexCode,
                        ProductCount = _context.ProductVariants.Count(pv => pv.ColorID == c.ColorID)
                    })
                    .ToListAsync();

                return new CommonPagination<GetColorRes>
                {
                    Success = true,
                    Message = "Lấy danh sách màu sắc thành công",
                    Data = colors,
                    TotalRecords = totalRecords
                };
            }
            catch (Exception ex)
            {
                return new CommonPagination<GetColorRes>
                {
                    Success = false,
                    Message = $"Lỗi: {ex.Message}",
                    Data = new List<GetColorRes>(),
                    TotalRecords = 0
                };
            }
        }

        public async Task<CommonResponse<GetColorRes>> GetColorById(int colorId)
        {
            try
            {
                var color = await _context.Colors
                    .Where(c => c.ColorID == colorId)
                    .Select(c => new GetColorRes
                    {
                        ColorID = c.ColorID,
                        Name = c.Name,
                        HexCode = c.HexCode,
                        ProductCount = _context.ProductVariants.Count(pv => pv.ColorID == c.ColorID)
                    })
                    .FirstOrDefaultAsync();

                if (color == null)
                {
                    return new CommonResponse<GetColorRes>
                    {
                        Success = false,
                        Message = "Không tìm thấy màu sắc",
                        Data = null
                    };
                }

                return new CommonResponse<GetColorRes>
                {
                    Success = true,
                    Message = "Lấy thông tin màu sắc thành công",
                    Data = color
                };
            }
            catch (Exception ex)
            {
                return new CommonResponse<GetColorRes>
                {
                    Success = false,
                    Message = $"Lỗi: {ex.Message}",
                    Data = null
                };
            }
        }

        public async Task<CommonResponse<bool>> AddColor(AddColorReq req)
        {
            try
            {
                // Kiểm tra trùng tên
                var existingByName = await _context.Colors
                    .AnyAsync(c => c.Name.ToLower() == req.Name.ToLower());

                if (existingByName)
                {
                    return new CommonResponse<bool>
                    {
                        Success = false,
                        Message = "Tên màu đã tồn tại",
                        Data = false
                    };
                }

                // Kiểm tra trùng mã hex
                var existingByHex = await _context.Colors
                    .AnyAsync(c => c.HexCode.ToLower() == req.HexCode.ToLower());

                if (existingByHex)
                {
                    return new CommonResponse<bool>
                    {
                        Success = false,
                        Message = "Mã màu hex đã tồn tại",
                        Data = false
                    };
                }

                var color = new Color
                {
                    Name = req.Name.Trim(),
                    HexCode = req.HexCode.ToUpper()
                };

                _context.Colors.Add(color);
                await _context.SaveChangesAsync();

                return new CommonResponse<bool>
                {
                    Success = true,
                    Message = "Thêm màu sắc thành công",
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

        public async Task<CommonResponse<bool>> UpdateColor(UpdateColorReq req)
        {
            try
            {
                var color = await _context.Colors.FindAsync(req.ColorID);

                if (color == null)
                {
                    return new CommonResponse<bool>
                    {
                        Success = false,
                        Message = "Không tìm thấy màu sắc",
                        Data = false
                    };
                }

                // Kiểm tra trùng tên (ngoại trừ chính nó)
                var existingByName = await _context.Colors
                    .AnyAsync(c => c.Name.ToLower() == req.Name.ToLower() && c.ColorID != req.ColorID);

                if (existingByName)
                {
                    return new CommonResponse<bool>
                    {
                        Success = false,
                        Message = "Tên màu đã tồn tại",
                        Data = false
                    };
                }

                // Kiểm tra trùng mã hex (ngoại trừ chính nó)
                var existingByHex = await _context.Colors
                    .AnyAsync(c => c.HexCode.ToLower() == req.HexCode.ToLower() && c.ColorID != req.ColorID);

                if (existingByHex)
                {
                    return new CommonResponse<bool>
                    {
                        Success = false,
                        Message = "Mã màu hex đã tồn tại",
                        Data = false
                    };
                }

                color.Name = req.Name.Trim();
                color.HexCode = req.HexCode.ToUpper();

                await _context.SaveChangesAsync();

                return new CommonResponse<bool>
                {
                    Success = true,
                    Message = "Cập nhật màu sắc thành công",
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

        public async Task<CommonResponse<bool>> DeleteColor(int colorId)
        {
            try
            {
                var color = await _context.Colors.FindAsync(colorId);

                if (color == null)
                {
                    return new CommonResponse<bool>
                    {
                        Success = false,
                        Message = "Không tìm thấy màu sắc",
                        Data = false
                    };
                }

                // Kiểm tra xem có sản phẩm nào đang sử dụng màu này không
                var hasProducts = await _context.ProductVariants
                    .AnyAsync(pv => pv.ColorID == colorId);

                if (hasProducts)
                {
                    return new CommonResponse<bool>
                    {
                        Success = false,
                        Message = "Không thể xóa màu sắc đang được sử dụng bởi sản phẩm",
                        Data = false
                    };
                }

                _context.Colors.Remove(color);
                await _context.SaveChangesAsync();

                return new CommonResponse<bool>
                {
                    Success = true,
                    Message = "Xóa màu sắc thành công",
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
