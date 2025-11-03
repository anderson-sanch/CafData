using Back_Proyecto.Models;

namespace Back_Proyecto.Repositories.Interfaces
{
    public interface IRoles_Permissions
    {
        Task<List<Roles_Permissions>> GetRoles_Permissions();  // Method to get all Roles_Permissions
        Task<Roles_Permissions> GetRole_Permission_Id(Guid id); // Method to get a Roles_Permissions by its Id
        Task<Roles_Permissions> CreateRole_Permission(Roles_Permissions Role_Permission); // Method to create a new Roles_Permissions
        Task<Roles_Permissions> UpdateRole_Permission(Roles_Permissions Role_Permission); // Method to update an existing Roles_Permissions
        Task<bool> DeleteRole_Permission(Guid id); // Method to delete a Roles_Permissions by its Id
    }
}
