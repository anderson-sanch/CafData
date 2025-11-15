using Back_Proyecto.Models;

namespace Back_Proyecto.Repositories.Interfaces
{
    public interface IDiscounts_Products
    {
        Task<List<Disocunts_Products>> GetDiscountsProducts();
        Task<Disocunts_Products> GetDiscountProduct_Id(Guid productId, Guid discountId);
        Task<Disocunts_Products> CreateDiscountProduct(Disocunts_Products dp);
        Task<Disocunts_Products> UpdateDiscountProduct(Disocunts_Products dp);
        Task<bool> DeleteDiscountProduct(Guid productId, Guid discountId);
    }
}
