using Back_Proyecto.Models;

namespace Back_Proyecto.Repositories.Interfaces

{
    public interface IPermissions
    {
        Task<List<Permissions>> GetPermissions();  // Method to get all Permissions
        Task<Permissions> GetPermission_Id(Guid id); // Method to get a Permission by its Id
        Task<Permissions> CreatePermission(Permissions Permission); // Method to create a new Permission
        Task<Permissions> UpdatePermission(Permissions Permission); // Method to update an existing Permission
        Task<bool> DeletePermission(Guid id); // Method to delete a Permission by its Id


    }
}
