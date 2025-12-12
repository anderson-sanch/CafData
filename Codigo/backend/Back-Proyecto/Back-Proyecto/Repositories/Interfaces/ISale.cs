using Back_Proyecto.Models;

namespace Back_Proyecto.Repositories.Interfaces
{
    public interface ISales
    {
        Task<List<Sales>> GetSales();
        Task<Sales> GetSale_Id(Guid id);
        Task<Sales> CreateSale(Sales sale);
        Task<Sales> UpdateSale(Sales sale);
        Task<bool> DeleteSale(Guid id);
    }
}

