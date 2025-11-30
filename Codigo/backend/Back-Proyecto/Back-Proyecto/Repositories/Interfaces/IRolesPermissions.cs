using Back_Proyecto.Models;

namespace Back_Proyecto.Repositories.Interfaces
{
    public interface IRolesPermissions
    {
        Task<List<RolesPermissions>> GetRoles_Permissions();

        Task<RolesPermissions> GetRole_Permission(Guid rolId, Guid permissionId);

        Task<RolesPermissions> CreateRole_Permission(RolesPermissions rp);

        Task<bool> DeleteRole_Permission(Guid rolId, Guid permissionId);
    }
}
