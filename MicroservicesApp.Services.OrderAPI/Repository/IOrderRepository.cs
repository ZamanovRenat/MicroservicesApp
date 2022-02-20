using System.Threading.Tasks;
using MicroservicesApp.Services.OrderAPI.Models;

namespace MicroservicesApp.Services.OrderAPI.Repository
{
    public interface IOrderRepository
    {
        Task<bool> AddOrder(OrderHeader orderHeader);
        Task UpdateOrderPaymentStatus(int orderHeaderId, bool paid);
    }
}
