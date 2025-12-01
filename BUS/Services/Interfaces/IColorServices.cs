using DAL.DTOs;
using DAL.Entities;
using DAL.Models;

namespace BUS.Services.Interfaces
{
    public interface IColorServices
    {
        Task<CommonResponse<List<Color>>> GetAllColorsAsync();
        Task<CommonResponse<Color>> GetColorByIdAsync(int id);
        Task<CommonResponse<Color>> CreateColorAsync(Color color);
        Task<CommonResponse<Color>> UpdateColorAsync(int id, Color color);
        Task<CommonResponse<bool>> DeleteColorAsync(int id);
        Task<bool> ColorExistsByNameAsync(string name, int? excludeId = null);
        Task<bool> ColorExistsByHexCodeAsync(string hexCode, int? excludeId = null);
    }
}
