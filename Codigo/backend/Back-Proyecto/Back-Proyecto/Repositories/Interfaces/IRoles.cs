using Back_Proyecto.Models;

namespace Back_Proyecto.Repositories.Interfaces

{
    public interface IRoles
    {
        Task<List<Roles>> GetRoles();  // Method to get all Roles
        Task<Roles> GetRol_Id(Guid id); // Method to get a Rol by its Id
        Task<Roles> CreateRol(Roles Rol); // Method to create a new Roles
        Task<Roles> UpdateRol(Roles Rol); // Method to update an existing Roles
        Task<bool> DeleteRole(Guid id); // Method to Inactive a Rol by its Id

    }
}
