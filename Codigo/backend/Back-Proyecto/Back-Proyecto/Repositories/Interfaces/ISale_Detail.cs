using Back_Proyecto.Models;

namespace Back_Proyecto.Repositories.Interfaces
{
    public interface ISale_Detail
    {
        Task<List<Sale_Detail>> GetAll();
        Task<Sale_Detail> GetById(Guid id);
        Task<List<Sale_Detail>> GetBySaleId(Guid saleId);
        Task<Sale_Detail> Create(Sale_Detail detail);
        Task<Sale_Detail> Update(Sale_Detail detail);
        Task<bool> Delete(Guid id);
    }
}
