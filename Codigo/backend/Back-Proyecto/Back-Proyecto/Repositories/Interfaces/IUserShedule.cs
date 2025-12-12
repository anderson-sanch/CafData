using Back_Proyecto.Models;

public interface IUserSheduleService
{
    Task<IEnumerable<User_Schedule>> GetAllAsync();
    Task<User_Schedule?> GetByIdAsync(Guid id);
    Task<User_Schedule> AddAsync(User_Schedule schedule);
    Task<User_Schedule?> UpdateAsync(Guid id, User_Schedule schedule);
    Task<bool> DeleteAsync(Guid id);
}
