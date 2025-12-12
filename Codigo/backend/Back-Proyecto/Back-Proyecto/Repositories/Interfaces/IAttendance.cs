using Back_Proyecto.Models;

namespace Back_Proyecto.Services
{
    public interface IAttendanceLogService
    {
        Task<IEnumerable<Attendance_Log>> GetAllAsync();
        Task<Attendance_Log?> GetByIdAsync(Guid id);
        Task<Attendance_Log> CreateAsync(Attendance_Log log);
        Task<Attendance_Log?> UpdateAsync(Guid id, Attendance_Log log);
        Task<bool> DeleteAsync(Guid id);
    }
}