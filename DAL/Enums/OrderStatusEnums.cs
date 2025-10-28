namespace DAL.Enums
{
    public enum OrderStatusEnums
    {
        /// <summary>
        /// Đơn hàng vừa được tạo, chờ xác nhận.
        /// </summary>
        Pending = 0,

        /// <summary>
        /// Đơn hàng đã được xác nhận bởi admin / hệ thống.
        /// </summary>
        Confirmed = 1,

        /// <summary>
        /// Đơn hàng đang được chuẩn bị để giao (đóng gói).
        /// </summary>
        Processing = 2,

        /// <summary>
        /// Đơn hàng đã bàn giao cho đơn vị vận chuyển.
        /// </summary>
        Shipped = 3,

        /// <summary>
        /// Đơn hàng đã được giao thành công đến khách hàng.
        /// </summary>
        Delivered = 4,

        /// <summary>
        /// Đơn hàng bị hủy (do khách hàng hoặc admin).
        /// </summary>
        Cancelled = 5,

        /// <summary>
        /// Đơn hàng bị trả lại hoặc hoàn tiền.
        /// </summary>
        Returned = 6
    }
}
