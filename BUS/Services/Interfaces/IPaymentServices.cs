using DAL.DTOs.Payments.Req;
using DAL.DTOs.Payments.Res;
using DAL.Entities;
using DAL.Models;
using Helper.Utils;
using Microsoft.AspNetCore.Http;

namespace BUS.Services.Interfaces
{
    public interface IPaymentServices
    {
        Task<CommonResponse<VNPayPaymentRes>> CreateVNPayPaymentUrl(VNPayPaymentReq request, string ipAddress);
        Task<CommonResponse<VNPayReturnRes>> ProcessVNPayReturn(IQueryCollection queryParams);
    }
}
