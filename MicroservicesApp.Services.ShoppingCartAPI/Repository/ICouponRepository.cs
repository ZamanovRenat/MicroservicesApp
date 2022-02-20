using System.Threading.Tasks;
using MicroservicesApp.Services.ShoppingCartAPI.Models.Dto;

namespace MicroservicesApp.Services.ShoppingCartAPI.Repository
{
    public interface ICouponRepository
    {
        Task<CouponDto> GetCoupon(string couponName);
    }
}
