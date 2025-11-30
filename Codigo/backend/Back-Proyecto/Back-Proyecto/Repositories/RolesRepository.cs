using Back_Proyecto.Context;
using Back_Proyecto.Models;
using Back_Proyecto.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Back_Proyecto.Repositories
{
    public class RolesRepository : IRoles
    {

        private readonly CafDataContext _context;

        public RolesRepository(CafDataContext context) 
        {
            _context = context;
        }

        public async Task<List<Roles>> GetRoles()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Roles> GetRol_Id(Guid id) 
        {
            var roles = await _context.Roles.FindAsync(id);

            if (roles == null) 
            { 
                throw new Exception("Rol no encontrado");
            }

            return roles;
        }

        public async Task<Roles> CreateRol(Roles role)
        {
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();
            return role;
        }

        public async Task<Roles> UpdateRol(Roles role)
        {
            var existing = await _context.Roles.FindAsync(role.Rol_Id);

            if (existing == null)
                throw new Exception("Rol no encontrado");

            existing.Name = role.Name;
            existing.Description = role.Description;

            _context.Roles.Update(existing);
            await _context.SaveChangesAsync();

            return existing;
        }

        public async Task<bool> DeleteRole(Guid id)
        {
            var existing = await _context.Roles.FindAsync(id);

            if (existing == null)
                return false;

            _context.Roles.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
