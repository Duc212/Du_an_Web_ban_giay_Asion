using BUS.Services.Interfaces;
using DAL;
using DAL.DTOs;
using DAL.Entities;
using DAL.Models;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BUS.Services
{
    public class ColorServices : IColorServices
    {
        private readonly ColorRepository _colorRepository;

        public ColorServices(ColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }

        public async Task<CommonResponse<List<Color>>> GetAllColorsAsync()
        {
            try
            {
                var colors = await _colorRepository.GetAllAsync();
                return new CommonResponse<List<Color>>
                {
                    Success = true,
                    Message = "Colors retrieved successfully",
                    Data = colors
                };
            }
            catch (Exception ex)
            {
                return new CommonResponse<List<Color>>
                {
                    Success = false,
                    Message = $"Error retrieving colors: {ex.Message}",
                    Data = null
                };
            }
        }

        public async Task<CommonResponse<Color>> GetColorByIdAsync(int id)
        {
            try
            {
                var color = await _colorRepository.GetByIdAsync(id);
                if (color == null)
                {
                    return new CommonResponse<Color>
                    {
                        Success = false,
                        Message = "Color not found",
                        Data = null
                    };
                }

                return new CommonResponse<Color>
                {
                    Success = true,
                    Message = "Color retrieved successfully",
                    Data = color
                };
            }
            catch (Exception ex)
            {
                return new CommonResponse<Color>
                {
                    Success = false,
                    Message = $"Error retrieving color: {ex.Message}",
                    Data = null
                };
            }
        }

        public async Task<CommonResponse<Color>> CreateColorAsync(Color color)
        {
            try
            {
                // Validate color name
                if (string.IsNullOrWhiteSpace(color.Name))
                {
                    return new CommonResponse<Color>
                    {
                        Success = false,
                        Message = "Color name is required",
                        Data = null
                    };
                }

                // Validate hex code
                if (string.IsNullOrWhiteSpace(color.HexCode))
                {
                    return new CommonResponse<Color>
                    {
                        Success = false,
                        Message = "Hex code is required",
                        Data = null
                    };
                }

                // Check if hex code format is valid
                if (!System.Text.RegularExpressions.Regex.IsMatch(color.HexCode, "^#[0-9A-Fa-f]{6}$"))
                {
                    return new CommonResponse<Color>
                    {
                        Success = false,
                        Message = "Invalid hex code format. Use format: #RRGGBB",
                        Data = null
                    };
                }

                // Check if color name already exists
                if (await ColorExistsByNameAsync(color.Name))
                {
                    return new CommonResponse<Color>
                    {
                        Success = false,
                        Message = "A color with this name already exists",
                        Data = null
                    };
                }

                // Check if hex code already exists
                if (await ColorExistsByHexCodeAsync(color.HexCode))
                {
                    return new CommonResponse<Color>
                    {
                        Success = false,
                        Message = "A color with this hex code already exists",
                        Data = null
                    };
                }

                await _colorRepository.AddAsync(color);

                return new CommonResponse<Color>
                {
                    Success = true,
                    Message = "Color created successfully",
                    Data = color
                };
            }
            catch (Exception ex)
            {
                return new CommonResponse<Color>
                {
                    Success = false,
                    Message = $"Error creating color: {ex.Message}",
                    Data = null
                };
            }
        }

        public async Task<CommonResponse<Color>> UpdateColorAsync(int id, Color color)
        {
            try
            {
                var existingColor = await _colorRepository.GetByIdAsync(id);
                if (existingColor == null)
                {
                    return new CommonResponse<Color>
                    {
                        Success = false,
                        Message = "Color not found",
                        Data = null
                    };
                }

                // Validate color name
                if (string.IsNullOrWhiteSpace(color.Name))
                {
                    return new CommonResponse<Color>
                    {
                        Success = false,
                        Message = "Color name is required",
                        Data = null
                    };
                }

                // Validate hex code
                if (string.IsNullOrWhiteSpace(color.HexCode))
                {
                    return new CommonResponse<Color>
                    {
                        Success = false,
                        Message = "Hex code is required",
                        Data = null
                    };
                }

                // Check if hex code format is valid
                if (!System.Text.RegularExpressions.Regex.IsMatch(color.HexCode, "^#[0-9A-Fa-f]{6}$"))
                {
                    return new CommonResponse<Color>
                    {
                        Success = false,
                        Message = "Invalid hex code format. Use format: #RRGGBB",
                        Data = null
                    };
                }

                // Check if color name already exists (excluding current color)
                if (await ColorExistsByNameAsync(color.Name, id))
                {
                    return new CommonResponse<Color>
                    {
                        Success = false,
                        Message = "A color with this name already exists",
                        Data = null
                    };
                }

                // Check if hex code already exists (excluding current color)
                if (await ColorExistsByHexCodeAsync(color.HexCode, id))
                {
                    return new CommonResponse<Color>
                    {
                        Success = false,
                        Message = "A color with this hex code already exists",
                        Data = null
                    };
                }

                existingColor.Name = color.Name;
                existingColor.HexCode = color.HexCode.ToUpper();

                await _colorRepository.UpdateAsync(existingColor);

                return new CommonResponse<Color>
                {
                    Success = true,
                    Message = "Color updated successfully",
                    Data = existingColor
                };
            }
            catch (Exception ex)
            {
                return new CommonResponse<Color>
                {
                    Success = false,
                    Message = $"Error updating color: {ex.Message}",
                    Data = null
                };
            }
        }

        public async Task<CommonResponse<bool>> DeleteColorAsync(int id)
        {
            try
            {
                var color = await _colorRepository.GetByIdAsync(id);
                if (color == null)
                {
                    return new CommonResponse<bool>
                    {
                        Success = false,
                        Message = "Color not found",
                        Data = false
                    };
                }

                await _colorRepository.DeleteAsync(color);

                return new CommonResponse<bool>
                {
                    Success = true,
                    Message = "Color deleted successfully",
                    Data = true
                };
            }
            catch (DbUpdateException)
            {
                return new CommonResponse<bool>
                {
                    Success = false,
                    Message = "Cannot delete color. It is being used by products.",
                    Data = false
                };
            }
            catch (Exception ex)
            {
                return new CommonResponse<bool>
                {
                    Success = false,
                    Message = $"Error deleting color: {ex.Message}",
                    Data = false
                };
            }
        }

        public async Task<bool> ColorExistsByNameAsync(string name, int? excludeId = null)
        {
            var colors = await _colorRepository.GetAllAsync();
            var query = colors.Where(c => c.Name.ToLower() == name.ToLower());

            if (excludeId.HasValue)
            {
                query = query.Where(c => c.ColorID != excludeId.Value);
            }

            return query.Any();
        }

        public async Task<bool> ColorExistsByHexCodeAsync(string hexCode, int? excludeId = null)
        {
            var colors = await _colorRepository.GetAllAsync();
            var query = colors.Where(c => c.HexCode.ToLower() == hexCode.ToLower());

            if (excludeId.HasValue)
            {
                query = query.Where(c => c.ColorID != excludeId.Value);
            }

            return query.Any();
        }
    }
}
