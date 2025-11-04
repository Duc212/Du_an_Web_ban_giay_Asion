using DAL.DTOs.Carts.Req;
using DAL.DTOs.Carts.Res;
using DAL.Entities;

namespace BUS.Services.Interfaces
{
    public interface ICartServices
    {
    Task<CommonResponse<CartSummaryRes>> AddToCartAsync(int userId, AddToCartReq request);
      Task<CommonResponse<CartSummaryRes>> GetCartAsync(int userId);
      Task<CommonResponse<CartItemRes>> UpdateCartItemAsync(int userId, int cartItemId, int quantity);
       Task<CommonResponse<string>> RemoveCartItemAsync(int userId, int cartItemId);
        Task<CommonResponse<string>> ClearCartAsync(int userId);
    }
}