using Back_Proyecto.Models;

namespace Back_Proyecto.Repositories.Interfaces
{
    public interface IDiscountedProducts
    {
        Task<List<DiscountedProducts>> GetAll();
        Task<DiscountedProducts> Add(DiscountedProducts item);
        Task<bool> Delete(Guid productId, Guid globalId);
    }
}
