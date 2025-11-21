using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DAL.DTOs.Shipping
{
    // ===== Configuration Options =====
    public class GhnOptions
    {
        public string BaseUrl { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public string ShopId { get; set; } = string.Empty;
    }

    // ===== Request DTOs =====
    
    /// <summary>
    /// Request để tạo đơn hàng GHN từ Order trong hệ thống
    /// </summary>
    public class CreateGhnOrderRequest
    {
        public int OrderId { get; set; }
        
        // Nếu không truyền, sẽ lấy từ Order
        public string? ToName { get; set; }
        public string? ToPhone { get; set; }
        public string? ToAddress { get; set; }
        public string? ToWardCode { get; set; }
        public string? ToDistrictId { get; set; }
        
        // Thông tin gửi (nếu khác config mặc định)
        public string? FromName { get; set; }
        public string? FromPhone { get; set; }
        public string? FromAddress { get; set; }
        public string? FromWardCode { get; set; }
        public string? FromDistrictId { get; set; }
        
        public int? ServiceTypeId { get; set; } = 2; // 2 = Chuẩn, 5 = Nhanh
        public int? PaymentTypeId { get; set; } = 2; // 1 = Người gửi trả, 2 = Người nhận trả
        public string? Note { get; set; }
        public int? RequiredNote { get; set; } = 2; // KHONGCHOXEMHANG
        public int? CodAmount { get; set; } // Tiền thu hộ COD
        public int? Weight { get; set; } = 1000; // gram
        public int? Length { get; set; } = 20; // cm
        public int? Width { get; set; } = 20; // cm
        public int? Height { get; set; } = 10; // cm
    }

    /// <summary>
    /// Payload gửi đến GHN API để tạo đơn hàng
    /// Theo docs: https://api.ghn.vn/home/docs/detail?id=62
    /// </summary>
    public class GhnCreateOrderPayload
    {
        [JsonPropertyName("payment_type_id")]
        public int PaymentTypeId { get; set; }

        [JsonPropertyName("note")]
        public string? Note { get; set; }

        [JsonPropertyName("required_note")]
        public string RequiredNote { get; set; } = "KHONGCHOXEMHANG";

        [JsonPropertyName("from_name")]
        public string FromName { get; set; } = string.Empty;

        [JsonPropertyName("from_phone")]
        public string FromPhone { get; set; } = string.Empty;

        [JsonPropertyName("from_address")]
        public string FromAddress { get; set; } = string.Empty;

        [JsonPropertyName("from_ward_name")]
        public string? FromWardName { get; set; }

        [JsonPropertyName("from_district_name")]
        public string? FromDistrictName { get; set; }

        [JsonPropertyName("from_province_name")]
        public string? FromProvinceName { get; set; }

        [JsonPropertyName("from_ward_code")]
        public string? FromWardCode { get; set; }

        [JsonPropertyName("from_district_id")]
        public int? FromDistrictId { get; set; }

        [JsonPropertyName("to_name")]
        public string ToName { get; set; } = string.Empty;

        [JsonPropertyName("to_phone")]
        public string ToPhone { get; set; } = string.Empty;

        [JsonPropertyName("to_address")]
        public string ToAddress { get; set; } = string.Empty;

        [JsonPropertyName("to_ward_code")]
        public string? ToWardCode { get; set; }

        [JsonPropertyName("to_district_id")]
        public int? ToDistrictId { get; set; }

        [JsonPropertyName("cod_amount")]
        public int? CodAmount { get; set; }

        [JsonPropertyName("content")]
        public string? Content { get; set; }

        [JsonPropertyName("weight")]
        public int Weight { get; set; }

        [JsonPropertyName("length")]
        public int Length { get; set; }

        [JsonPropertyName("width")]
        public int Width { get; set; }

        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("service_type_id")]
        public int ServiceTypeId { get; set; } = 2;

        [JsonPropertyName("items")]
        public List<GhnOrderItem>? Items { get; set; }
    }

    public class GhnOrderItem
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("price")]
        public int Price { get; set; }
    }

    /// <summary>
    /// Request tính phí ship GHN
    /// </summary>
    public class GhnCalculateFeeRequest
    {
        [JsonPropertyName("service_type_id")]
        public int ServiceTypeId { get; set; } = 2;

        [JsonPropertyName("from_district_id")]
        public int FromDistrictId { get; set; }

        [JsonPropertyName("to_district_id")]
        public int ToDistrictId { get; set; }

        [JsonPropertyName("to_ward_code")]
        public string? ToWardCode { get; set; }

        [JsonPropertyName("weight")]
        public int Weight { get; set; }

        [JsonPropertyName("length")]
        public int Length { get; set; }

        [JsonPropertyName("width")]
        public int Width { get; set; }

        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("insurance_value")]
        public int? InsuranceValue { get; set; }

        [JsonPropertyName("cod_value")]
        public int? CodValue { get; set; }
    }

    // ===== Response DTOs =====

    /// <summary>
    /// Response chung từ GHN API
    /// </summary>
    public class GhnApiResponse<T>
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("data")]
        public T? Data { get; set; }
    }

    /// <summary>
    /// Response khi tạo đơn GHN thành công
    /// </summary>
    public class GhnCreateOrderResponse
    {
        [JsonPropertyName("order_code")]
        public string OrderCode { get; set; } = string.Empty;

        [JsonPropertyName("sort_code")]
        public string? SortCode { get; set; }

        [JsonPropertyName("trans_type")]
        public string? TransType { get; set; }

        [JsonPropertyName("ward_encode")]
        public string? WardEncode { get; set; }

        [JsonPropertyName("district_encode")]
        public string? DistrictEncode { get; set; }

        [JsonPropertyName("fee")]
        public GhnFeeDetail? Fee { get; set; }

        [JsonPropertyName("total_fee")]
        public int? TotalFee { get; set; }

        [JsonPropertyName("expected_delivery_time")]
        public DateTime? ExpectedDeliveryTime { get; set; }
    }

    public class GhnFeeDetail
    {
        [JsonPropertyName("main_service")]
        public int? MainService { get; set; }

        [JsonPropertyName("insurance")]
        public int? Insurance { get; set; }

        [JsonPropertyName("cod_fee")]
        public int? CodFee { get; set; }

        [JsonPropertyName("station_do")]
        public int? StationDo { get; set; }

        [JsonPropertyName("station_pu")]
        public int? StationPu { get; set; }

        [JsonPropertyName("return")]
        public int? Return { get; set; }

        [JsonPropertyName("r2s")]
        public int? R2s { get; set; }
    }

    /// <summary>
    /// Response chi tiết đơn hàng GHN
    /// </summary>
    public class GhnOrderDetailResponse
    {
        [JsonPropertyName("order_code")]
        public string OrderCode { get; set; } = string.Empty;

        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("status_text")]
        public string? StatusText { get; set; }

        [JsonPropertyName("cod_amount")]
        public int? CodAmount { get; set; }

        [JsonPropertyName("cod_collect_date")]
        public DateTime? CodCollectDate { get; set; }

        [JsonPropertyName("total_fee")]
        public int? TotalFee { get; set; }

        [JsonPropertyName("expected_delivery_time")]
        public DateTime? ExpectedDeliveryTime { get; set; }

        [JsonPropertyName("log")]
        public List<GhnOrderLog>? Log { get; set; }
    }

    public class GhnOrderLog
    {
        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("updated_date")]
        public DateTime? UpdatedDate { get; set; }
    }

    /// <summary>
    /// Response tính phí GHN
    /// </summary>
    public class GhnCalculateFeeResponse
    {
        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("service_fee")]
        public int ServiceFee { get; set; }

        [JsonPropertyName("insurance_fee")]
        public int? InsuranceFee { get; set; }

        [JsonPropertyName("cod_fee")]
        public int? CodFee { get; set; }
    }

    // ===== Webhook DTOs =====

    /// <summary>
    /// Payload nhận từ GHN Webhook
    /// </summary>
    public class GhnWebhookPayload
    {
        [JsonPropertyName("OrderCode")]
        public string? OrderCode { get; set; }

        [JsonPropertyName("Status")]
        public string? Status { get; set; }

        [JsonPropertyName("CODAmount")]
        public int? CODAmount { get; set; }

        [JsonPropertyName("CODTransferDate")]
        public string? CODTransferDate { get; set; }

        [JsonPropertyName("ShopID")]
        public int? ShopID { get; set; }

        [JsonPropertyName("ClientOrderCode")]
        public string? ClientOrderCode { get; set; }

        [JsonPropertyName("Fee")]
        public int? Fee { get; set; }

        [JsonPropertyName("Reason")]
        public string? Reason { get; set; }

        [JsonPropertyName("ReasonCode")]
        public string? ReasonCode { get; set; }

        [JsonPropertyName("Weight")]
        public int? Weight { get; set; }

        [JsonPropertyName("Time")]
        public DateTime? Time { get; set; }
    }

    /// <summary>
    /// Response trả về cho client khi tạo đơn GHN thành công
    /// </summary>
    public class CreateGhnOrderResult
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public string? GhnOrderCode { get; set; }
        public int? TotalFee { get; set; }
        public DateTime? ExpectedDeliveryTime { get; set; }
    }

    /// <summary>
    /// Response tracking đơn hàng
    /// </summary>
    public class OrderTrackingResponse
    {
        public int OrderId { get; set; }
        public string? OrderCode { get; set; }
        public string? GhnOrderCode { get; set; }
        public string? GhnStatus { get; set; }
        public string? GhnStatusText { get; set; }
        public int? GhnFee { get; set; }
        public bool CodCollected { get; set; }
        public DateTime? ExpectedDeliveryTime { get; set; }
        public DateTime? LastUpdated { get; set; }
    }
}
