using Back_Proyecto.Models;

namespace Back_Proyecto.Repositories.Interfaces
{
    public interface IGlobalDiscounts
    {
        Task<List<GlobalDiscounts>> GetGlobalDiscounts();
        Task<GlobalDiscounts> GetGlobalDiscount_Id(Guid id);
        Task<GlobalDiscounts> CreateGlobalDiscount(GlobalDiscounts discount);
        Task<GlobalDiscounts> UpdateGlobalDiscount(GlobalDiscounts discount);
        Task<bool> DeleteGlobalDiscount(Guid id);
    }
}
