using Back_Proyecto.Models;

namespace Back_Proyecto.Repositories.Interfaces
{
    public interface IGlobalDiscounts
    {
        Task<List<Global_Discounts>> GetGlobalDiscounts();
        Task<Global_Discounts> GetGlobalDiscount_Id(Guid id);
        Task<Global_Discounts> CreateGlobalDiscount(Global_Discounts discount);
        Task<Global_Discounts> UpdateGlobalDiscount(Global_Discounts discount);
        Task<bool> InactiveGlobalDiscount(Guid id);
    }
}
