using Back_Proyecto.Models;

namespace Back_Proyecto.Repositories.Interfaces
{
    public interface ICategories
    {
        Task<List<Catogories>> GetCategories();
        Task<Catogories> GetCategory_Id(Guid id);
        Task<Catogories> CreateCategory(Catogories category);
        Task<Catogories> UpdateCategory(Catogories category);
        Task<bool> InactiveCategory(Guid id);
    }

}
