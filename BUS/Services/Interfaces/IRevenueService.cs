namespace BUS.Services.Interfaces
{
    public interface IRevenueService
    {
        Task<bool> RecordRevenueAsync(int orderId, decimal amount);
    }
}
