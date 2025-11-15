using Back_Proyecto.Models;

namespace Back_Proyecto.Repositories.Interfaces
{
    public interface ICategories
    {
        Task<List<Categories>> GetCategories();
        Task<Categories> GetCategory_Id(Guid id);
        Task<Categories> CreateCategory(Categories category);
        Task<Categories> UpdateCategory(Categories category);
        Task<bool> InactiveCategory(Guid id);
    }
}
