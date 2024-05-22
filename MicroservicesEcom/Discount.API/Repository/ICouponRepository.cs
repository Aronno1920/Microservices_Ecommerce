using Discount.API.Models;

namespace Discount.API.Repository
{
    public interface ICouponRepository
    {
        Task<Coupon> GetDiscount(String productId);
        Task<bool> CreateDiscount(Coupon coupon);
        Task<bool> UpdateDiscount(Coupon coupon);
        Task<bool> DeleteDiscount(String productId);
    }
}
