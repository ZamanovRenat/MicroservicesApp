using System.Threading.Tasks;
using MicroservicesApp.Services.CouponAPI.Models.Dto;

namespace MicroservicesApp.Services.CouponAPI.Respository
{
    public interface ICouponRepository
    {
        Task<CouponDto> GetCouponByCode(string couponCode);
    }
}
