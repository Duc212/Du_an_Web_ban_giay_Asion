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

        /// <summary>
        /// Cập nhật thông tin đơn hàng GHN (note)
        /// </summary>
        Task<bool> UpdateOrderAsync(string orderCode, string note);

        /// <summary>
        /// Hủy đơn hàng GHN
        /// </summary>
        Task<bool> CancelOrderAsync(List<string> orderCodes);

        /// <summary>
        /// Chuyển đơn về trạng thái trả hàng
        /// </summary>
        Task<bool> ReturnOrderAsync(List<string> orderCodes);

        /// <summary>
        /// Cập nhật số tiền COD
        /// </summary>
        Task<bool> UpdateCODAsync(string orderCode, int codAmount);

        /// <summary>
        /// Lấy thời gian dự kiến giao hàng
        /// </summary>
        Task<DateTime?> GetLeadTimeAsync(int fromDistrictId, string fromWardCode, int toDistrictId, string toWardCode, int serviceId);

        /// <summary>
        /// Preview đơn hàng trước khi tạo
        /// </summary>
        Task<GhnOrderPreviewResponse?> PreviewOrderAsync(GhnCreateOrderPayload payload);

        /// <summary>
        /// Lấy danh sách Shop từ GHN (for testing/debugging)
        /// </summary>
        Task<string> GetAllShopsAsync();

        /// <summary>
        /// Lấy danh sách tỉnh/thành phố
        /// </summary>
        Task<GhnProvinceResponse?> GetProvincesAsync();

        /// <summary>
        /// Lấy danh sách quận/huyện theo tỉnh
        /// </summary>
        Task<GhnDistrictResponse?> GetDistrictsAsync(int provinceId);

        /// <summary>
        /// Lấy danh sách phường/xã theo quận
        /// </summary>
        Task<GhnWardResponse?> GetWardsAsync(int districtId);
    }
}
