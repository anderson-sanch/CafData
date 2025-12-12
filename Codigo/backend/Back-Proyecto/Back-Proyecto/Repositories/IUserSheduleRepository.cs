using Back_Proyecto.Context;
using Back_Proyecto.Models;
using Back_Proyecto.Services;
using Microsoft.EntityFrameworkCore;

namespace Back_Proyecto.Repositories
{
    public class UserSheduleRepository : IUserSheduleService
    {
        private readonly CafDataContext _context;

        public UserSheduleRepository(CafDataContext context)
        {
            _context = context;
        }

        // GET ALL
        public async Task<IEnumerable<User_Schedule>> GetAllAsync()
        {
            return await _context.User_Shedules
                .AsNoTracking()
                .ToListAsync();
        }

        // GET BY ID
        public async Task<User_Schedule?> GetByIdAsync(Guid id)
        {
            return await _context.User_Shedules
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Schedules_Id == id);
        }

        // CREATE
        public async Task<User_Schedule> AddAsync(User_Schedule schedule)
        {
            schedule.Schedules_Id = Guid.NewGuid();

            await _context.User_Shedules.AddAsync(schedule);
            await _context.SaveChangesAsync();

            return schedule;
        }

        // UPDATE
        public async Task<User_Schedule?> UpdateAsync(Guid id, User_Schedule schedule)
        {
            var existing = await _context.User_Shedules.FindAsync(id);

            if (existing == null)
                return null;

            existing.User_Id = schedule.User_Id;
            existing.Check_In_Time = schedule.Check_In_Time;
            existing.Check_Out_Time = schedule.Check_Out_Time;
            existing.Weekday = schedule.Weekday;

            await _context.SaveChangesAsync();
            return existing;
        }

        // DELETE
        public async Task<bool> DeleteAsync(Guid id)
        {
            var schedule = await _context.User_Shedules.FindAsync(id);

            if (schedule == null)
                return false;

            _context.User_Shedules.Remove(schedule);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
