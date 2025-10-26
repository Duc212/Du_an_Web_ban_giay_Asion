using DAL.DTOs;
using DAL.Entities;
using DAL.Models;

namespace BUS.Services.Interfaces
{
    public interface IOrderServices
    {
        Task<CommonResponse<bool>> CreateOrder(CreateOrderDTO createOrder);
    }
}
