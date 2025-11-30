using Back_Proyecto.Context;
using Back_Proyecto.Models;
using Back_Proyecto.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Back_Proyecto.Repositories
{
    public class PermissionsRepository : IPermissions
    {

        private readonly CafDataContext _context;

        public PermissionsRepository(CafDataContext context)
        {
            _context = context;
        }

        public async Task<List<Permissions>> GetPermissions()
        {
            return await _context.Permissions.ToListAsync();
        }

        public async Task<Permissions> GetPermission_Id( Guid id) 
        { 
            var permission = await _context.Permissions.FindAsync(id);

            if (permission == null) 
            {
                throw new Exception("Permiso no encontrado");
            }

            return permission;
        }

        public async Task<Permissions> CreatePermission(Permissions permission)
        {
            _context.Permissions.Add(permission);
            await _context.SaveChangesAsync();
            return permission;
        }

        public async Task<Permissions> UpdatePermission(Permissions permission)
        {
            var existing = await _context.Permissions.FindAsync(permission.Permission_Id);

            if (existing == null)
                throw new Exception("Permiso no encontrado");

            existing.Name = permission.Name;
            existing.Description = permission.Description;

            _context.Permissions.Update(existing);
            await _context.SaveChangesAsync();

            return existing;
        }

        public async Task<bool> DeletePermission(Guid id)
        {
            var existing = await _context.Permissions.FindAsync(id);

            if (existing == null)
                return false;

            _context.Permissions.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
