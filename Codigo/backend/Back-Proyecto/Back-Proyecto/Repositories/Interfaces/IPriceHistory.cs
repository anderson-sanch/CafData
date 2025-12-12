using Back_Proyecto.Models;

namespace Back_Proyecto.Repositories.Interfaces
{
    public interface IPriceHistory
    {
        Task<List<Price_History>> GetPriceHistory();
        Task<Price_History> GetPriceHistory_Id(Guid id);
        Task<Price_History> CreatePriceHistory(Price_History history);
        Task<Price_History> UpdatePriceHistory(Price_History history);
        Task<bool> DeletePriceHistory(Guid id);
    }
}
