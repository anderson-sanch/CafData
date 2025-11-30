using System.Linq.Expressions;
using Back_Proyecto.Context;
using Back_Proyecto.Models;
using Back_Proyecto.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Back_Proyecto.Repositories
{
    public class RolesPermissionsRepository : IRolesPermissions
    {
        private readonly CafDataContext _context;

        public RolesPermissionsRepository(CafDataContext context)
        {
            _context = context;
        }

        public async Task<List<RolesPermissions>> GetRoles_Permissions()
        {
            return await _context.Roles_Permissions
                .Include(rp => rp.Role)
                .Include(rp => rp.Permission)
                .ToListAsync();
        }

        public async Task<RolesPermissions?> GetRole_Permission(Guid rolId, Guid permissionId)
        {
            return await _context.Roles_Permissions
                .FirstOrDefaultAsync(rp => rp.Role_Id == rolId && rp.Permission_Id == permissionId);
        }


        public async Task<RolesPermissions> CreateRole_Permission(RolesPermissions rp)
        {
            _context.Roles_Permissions.Add(rp);
            await _context.SaveChangesAsync();
            return rp;
        }

        public async Task<bool> DeleteRole_Permission(Guid Rol_Id, Guid Permission_id)
        {
            var data = await _context.Roles_Permissions
                .FirstOrDefaultAsync(x => x.Role_Id == Rol_Id && x.Permission_Id == Permission_id);

            if (data == null) return false;

            _context.Roles_Permissions.Remove(data);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}

