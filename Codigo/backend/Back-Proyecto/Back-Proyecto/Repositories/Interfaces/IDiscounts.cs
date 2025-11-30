using Back_Proyecto.Models;

namespace Back_Proyecto.Repositories.Interfaces
{
    public interface IDiscounts
    {
        Task<List<Discounts>> GetDiscounts();
        Task<Discounts> GetDiscountById(Guid id);
        Task<Discounts> CreateDiscount(Discounts discount);
        Task<Discounts> UpdateDiscount(Discounts discount);
        Task<bool> DeleteDiscount(Guid id);
    }
}
