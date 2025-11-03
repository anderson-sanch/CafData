using Back_Proyecto.Models;


namespace Back_Proyecto.Repositories.interfaces

{
    public interface IUsers // Interface for Users repository
    {
        Task<List<Users>> GetUsers();  // Method to get all Users 
        Task<Users> GetUser_Id(Guid id); // Method to get a Users by its Id
        Task<Users> CreateUser(Users User); // Method to create a new Users
        Task<Users> UpdateUser(Users User); // Method to update an existing Users
        Task<bool> DeleteUser(Guid id); // Method to delete a Users by its Id

    }
}
