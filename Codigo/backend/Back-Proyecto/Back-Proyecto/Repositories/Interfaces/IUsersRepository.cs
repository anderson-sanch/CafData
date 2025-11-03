using Back_Proyecto.Models;


namespace Back_Proyecto.Repositories.interfaces

{
    public interface IUsersRepository // Interface for Users repository
    {
        Task<List<Users>> GetUsers(); // Method to get all Users
        Task<Users> GetUserById(Guid id); // Method to get a Users by its Id
        Task<bool> CreateUser(Users User); // Method to create a new Users
        Task<bool> UpdateUser(Users User); // Method to update an existing Users
        Task<bool> DeleteUser(Guid id); // Method to delete a Users by its Id

    }
}
