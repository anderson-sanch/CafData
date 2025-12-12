using Back_Proyecto.Models;

namespace Back_Proyecto.Services
{
    public interface ISystemLogService
    {
        Task<IEnumerable<System_Log>> GetAllAsync();
        Task<System_Log?> GetByIdAsync(Guid id);
        Task<System_Log> CreateAsync(System_Log log);
        Task<System_Log?> UpdateAsync(Guid id, System_Log log);
        Task<bool> DeleteAsync(Guid id);
    }
}
