using Back_Proyecto.Context;
using Back_Proyecto.Models;
using Back_Proyecto.Services;
using Microsoft.EntityFrameworkCore;

namespace Back_Proyecto.Repositories
{
    public class AttendanceLogRepository : IAttendanceLogService
    {
        private readonly CafDataContext _context;

        public AttendanceLogRepository(CafDataContext context)
        {
            _context = context;
        }

        // ============================================================
        // GET ALL
        // ============================================================
        public async Task<IEnumerable<Attendance_Log>> GetAllAsync()
        {
            return await _context.Attendance_Logs
                .AsNoTracking()
                .Include(a => a.Users)      // si necesitas traer los datos del usuario
                .ToListAsync();
        }

        // ============================================================
        // GET BY ID
        // ============================================================
        public async Task<Attendance_Log?> GetByIdAsync(Guid id)
        {
            return await _context.Attendance_Logs
                .AsNoTracking()
                .Include(a => a.Users)
                .FirstOrDefaultAsync(x => x.Attendance_Id == id);
        }

        // ============================================================
        // CREATE
        // ============================================================
        public async Task<Attendance_Log> CreateAsync(Attendance_Log log)
        {
            log.Attendance_Id = Guid.NewGuid();
            log.Date = DateTime.UtcNow;

            await _context.Attendance_Logs.AddAsync(log);
            await _context.SaveChangesAsync();
            return log;
        }

        // ============================================================
        // UPDATE
        // ============================================================
        public async Task<Attendance_Log?> UpdateAsync(Guid id, Attendance_Log log)
        {
            var existing = await _context.Attendance_Logs.FindAsync(id);

            if (existing == null)
                return null;

            existing.User_Id = log.User_Id;
            existing.Date = log.Date;
            existing.Start_Date = log.Start_Date;
            existing.End_Date = log.End_Date;
            existing.Status = log.Status;

            await _context.SaveChangesAsync();
            return existing;
        }

        // ============================================================
        // DELETE
        // ============================================================
        public async Task<bool> DeleteAsync(Guid id)
        {
            var existing = await _context.Attendance_Logs.FindAsync(id);

            if (existing == null)
                return false;

            _context.Attendance_Logs.Remove(existing);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
