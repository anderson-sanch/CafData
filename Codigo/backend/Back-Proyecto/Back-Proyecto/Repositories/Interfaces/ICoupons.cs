using Back_Proyecto.Models;

namespace Back_Proyecto.Repositories.Interfaces
{
    public interface ICoupons
    {
        Task<List<Coupons>> GetCoupons();
        Task<Coupons> GetCoupon_Id(Guid id);
        Task<Coupons> CreateCoupon(Coupons coupon);
        Task<Coupons> UpdateCoupon(Coupons coupon);
        Task<bool> InactiveCoupon(Guid id);
    }

}
