using DAL.DTOs.Shipping;
using DAL.Entities;

namespace BUS.Services.Interfaces
{
    public interface IGhnService
    {
        /// <summary>
        /// Tạo đơn hàng trên GHN và lưu thông tin vào DB
        /// </summary>
        Task<CreateGhnOrderResult> CreateOrderAsync(CreateGhnOrderRequest request);

        /// <summary>
        /// Lấy chi tiết đơn hàng từ GHN API
        /// </summary>
        Task<GhnOrderDetailResponse?> GetOrderDetailAsync(string ghnOrderCode);

        /// <summary>
        /// Tính phí vận chuyển GHN
        /// </summary>
        Task<GhnCalculateFeeResponse?> CalculateFeeAsync(GhnCalculateFeeRequest request);

        /// <summary>
        /// Lấy thông tin tracking đơn hàng từ DB
        /// </summary>
        Task<OrderTrackingResponse?> GetOrderTrackingAsync(int orderId);
    }
}
