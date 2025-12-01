using DAL.DTOs;
using DAL.Entities;
using DAL.Models;

namespace BUS.Services.Interfaces
{
    public interface ISizeServices
    {
        Task<CommonResponse<List<Size>>> GetAllSizesAsync();
        Task<CommonResponse<Size>> GetSizeByIdAsync(int id);
        Task<CommonResponse<Size>> CreateSizeAsync(Size size);
        Task<CommonResponse<Size>> UpdateSizeAsync(int id, Size size);
        Task<CommonResponse<bool>> DeleteSizeAsync(int id);
        Task<bool> SizeExistsByValueAsync(string value, int? excludeId = null);
    }
}
