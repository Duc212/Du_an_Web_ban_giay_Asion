using BUS.Services.Interfaces;
using DAL;
using DAL.DTOs;
using DAL.Entities;
using DAL.Models;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BUS.Services
{
    public class SizeServices : ISizeServices
    {
        private readonly SizeRepository _sizeRepository;

        public SizeServices(SizeRepository sizeRepository)
        {
            _sizeRepository = sizeRepository;
        }

        public async Task<CommonResponse<List<Size>>> GetAllSizesAsync()
        {
            try
            {
                var sizes = await _sizeRepository.GetAllAsync();
                return new CommonResponse<List<Size>>
                {
                    Success = true,
                    Message = "Sizes retrieved successfully",
                    Data = sizes
                };
            }
            catch (Exception ex)
            {
                return new CommonResponse<List<Size>>
                {
                    Success = false,
                    Message = $"Error retrieving sizes: {ex.Message}",
                    Data = null
                };
            }
        }

        public async Task<CommonResponse<Size>> GetSizeByIdAsync(int id)
        {
            try
            {
                var size = await _sizeRepository.GetByIdAsync(id);
                if (size == null)
                {
                    return new CommonResponse<Size>
                    {
                        Success = false,
                        Message = "Size not found",
                        Data = null
                    };
                }

                return new CommonResponse<Size>
                {
                    Success = true,
                    Message = "Size retrieved successfully",
                    Data = size
                };
            }
            catch (Exception ex)
            {
                return new CommonResponse<Size>
                {
                    Success = false,
                    Message = $"Error retrieving size: {ex.Message}",
                    Data = null
                };
            }
        }

        public async Task<CommonResponse<Size>> CreateSizeAsync(Size size)
        {
            try
            {
                // Validate size value
                if (string.IsNullOrWhiteSpace(size.Value))
                {
                    return new CommonResponse<Size>
                    {
                        Success = false,
                        Message = "Size value is required",
                        Data = null
                    };
                }

                // Check if size value already exists
                if (await SizeExistsByValueAsync(size.Value))
                {
                    return new CommonResponse<Size>
                    {
                        Success = false,
                        Message = "A size with this value already exists",
                        Data = null
                    };
                }

                await _sizeRepository.AddAsync(size);

                return new CommonResponse<Size>
                {
                    Success = true,
                    Message = "Size created successfully",
                    Data = size
                };
            }
            catch (Exception ex)
            {
                return new CommonResponse<Size>
                {
                    Success = false,
                    Message = $"Error creating size: {ex.Message}",
                    Data = null
                };
            }
        }

        public async Task<CommonResponse<Size>> UpdateSizeAsync(int id, Size size)
        {
            try
            {
                var existingSize = await _sizeRepository.GetByIdAsync(id);
                if (existingSize == null)
                {
                    return new CommonResponse<Size>
                    {
                        Success = false,
                        Message = "Size not found",
                        Data = null
                    };
                }

                // Validate size value
                if (string.IsNullOrWhiteSpace(size.Value))
                {
                    return new CommonResponse<Size>
                    {
                        Success = false,
                        Message = "Size value is required",
                        Data = null
                    };
                }

                // Check if size value already exists (excluding current size)
                if (await SizeExistsByValueAsync(size.Value, id))
                {
                    return new CommonResponse<Size>
                    {
                        Success = false,
                        Message = "A size with this value already exists",
                        Data = null
                    };
                }

                existingSize.Value = size.Value;

                await _sizeRepository.UpdateAsync(existingSize);

                return new CommonResponse<Size>
                {
                    Success = true,
                    Message = "Size updated successfully",
                    Data = existingSize
                };
            }
            catch (Exception ex)
            {
                return new CommonResponse<Size>
                {
                    Success = false,
                    Message = $"Error updating size: {ex.Message}",
                    Data = null
                };
            }
        }

        public async Task<CommonResponse<bool>> DeleteSizeAsync(int id)
        {
            try
            {
                var size = await _sizeRepository.GetByIdAsync(id);
                if (size == null)
                {
                    return new CommonResponse<bool>
                    {
                        Success = false,
                        Message = "Size not found",
                        Data = false
                    };
                }

                await _sizeRepository.DeleteAsync(size);

                return new CommonResponse<bool>
                {
                    Success = true,
                    Message = "Size deleted successfully",
                    Data = true
                };
            }
            catch (DbUpdateException)
            {
                return new CommonResponse<bool>
                {
                    Success = false,
                    Message = "Cannot delete size. It is being used by products.",
                    Data = false
                };
            }
            catch (Exception ex)
            {
                return new CommonResponse<bool>
                {
                    Success = false,
                    Message = $"Error deleting size: {ex.Message}",
                    Data = false
                };
            }
        }

        public async Task<bool> SizeExistsByValueAsync(string value, int? excludeId = null)
        {
            var sizes = await _sizeRepository.GetAllAsync();
            var query = sizes.Where(s => s.Value.ToLower() == value.ToLower());

            if (excludeId.HasValue)
            {
                query = query.Where(s => s.SizeID != excludeId.Value);
            }

            return query.Any();
        }
    }
}
