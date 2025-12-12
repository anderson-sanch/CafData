using Back_Proyecto.Context;
using Back_Proyecto.Models;
using Back_Proyecto.Services;
using Microsoft.EntityFrameworkCore;

namespace Back_Proyecto.Repositories
{
    public class SystemLogRepository : ISystemLogService
    {
        private readonly CafDataContext _context;

        public SystemLogRepository(CafDataContext context)
        {
            _context = context;
        }

        // ============================================================
        // GET ALL
        // ============================================================
        public async Task<IEnumerable<System_Log>> GetAllAsync()
        {
            return await _context.System_Log
                .AsNoTracking()
                .ToListAsync();
        }

        // ============================================================
        // GET BY ID
        // ============================================================
        public async Task<System_Log?> GetByIdAsync(Guid id)
        {
            return await _context.System_Log
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id_Logs == id);
        }

        // ============================================================
        // CREATE
        // ============================================================
        public async Task<System_Log> CreateAsync(System_Log log)
        {
            log.Id_Logs = Guid.NewGuid();
            log.Date = DateTime.UtcNow;

            await _context.System_Log.AddAsync(log);
            await _context.SaveChangesAsync();

            return log;
        }

        // ============================================================
        // UPDATE
        // ============================================================
        public async Task<System_Log?> UpdateAsync(Guid id, System_Log log)
        {
            var existing = await _context.System_Log.FindAsync(id);
            if (existing == null)
                return null;

            existing.User_Id = log.User_Id;
            existing.Acction = log.Acction;
            existing.Description = log.Description;
            existing.Module = log.Module;
            existing.Date = log.Date;

            await _context.SaveChangesAsync();
            return existing;
        }

        // ============================================================
        // DELETE
        // ============================================================
        public async Task<bool> DeleteAsync(Guid id)
        {
            var log = await _context.System_Log.FindAsync(id);
            if (log == null)
                return false;

            _context.System_Log.Remove(log);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
