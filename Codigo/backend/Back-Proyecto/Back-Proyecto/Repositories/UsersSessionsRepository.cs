using Back_Proyecto.Context;
using Back_Proyecto.Models;
using Back_Proyecto.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Back_Proyecto.Repositories
{
    public class UserSessionsRepository : IUsers_Sessions
    {
        private readonly CafDataContext _context;

        public UserSessionsRepository(CafDataContext context)
        {
            _context = context;
        }

        // ============================================================
        // GET ALL
        // ============================================================
        public async Task<List<User_Sessions>> GetUsers_Sessions()
        {
            return await _context.Users_Sesions     // ← AQUI EL CAMBIO
                .Include(x => x.User)
                .OrderByDescending(x => x.Start_Date)
                .ToListAsync();
        }

        // ============================================================
        // GET BY ID
        // ============================================================
        public async Task<User_Sessions> GetUser_Session_Id(Guid id)
        {
            var session = await _context.Users_Sesions   // ← AQUI EL CAMBIO
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id_Session == id);

            if (session == null)
                throw new KeyNotFoundException("Sesión no encontrada.");

            return session;
        }

        // ============================================================
        // CREATE
        // ============================================================
        public async Task<User_Sessions> CreateUser_Session(User_Sessions session)
        {
            if (string.IsNullOrWhiteSpace(session.Token))
                throw new Exception("El token no puede estar vacío.");

            if (session.User_Id == Guid.Empty)
                throw new Exception("Debe especificarse un User_Id válido.");

            if (session.Start_Date == default)
                session.Start_Date = DateTime.UtcNow;

            _context.Users_Sesions.Add(session);   // ← AQUI EL CAMBIO
            await _context.SaveChangesAsync();
            return session;
        }

        // ============================================================
        // UPDATE
        // ============================================================
        public async Task<User_Sessions> UpdateUser_Session(User_Sessions session)
        {
            var existing = await _context.Users_Sesions.FindAsync(session.Id_Session); // ← CAMBIO

            if (existing == null)
                throw new KeyNotFoundException("Sesión no encontrada para actualización.");

            existing.Token = session.Token;
            existing.User_Id = session.User_Id;
            existing.Start_Date = session.Start_Date;
            existing.End_Date = session.End_Date;
            existing.Status = session.Status;

            await _context.SaveChangesAsync();
            return existing;
        }

        // ============================================================
        // DELETE
        // ============================================================
        public async Task<bool> DeleteUser_Session(Guid id)
        {
            var existing = await _context.Users_Sesions.FindAsync(id); // ← CAMBIO

            if (existing == null)
                return false;

            _context.Users_Sesions.Remove(existing); // ← CAMBIO
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
