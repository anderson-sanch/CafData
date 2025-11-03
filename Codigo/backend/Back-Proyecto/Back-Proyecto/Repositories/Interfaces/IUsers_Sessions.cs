using Back_Proyecto.Models;

namespace Back_Proyecto.Repositories.Interfaces
{
    public interface IUsers_Sessions
    {
        Task<List<User_Sessions>> GetUsers_Sessions();  // Method to get all Users_Sessions
        Task<User_Sessions> GetUser_Session_Id(Guid id); // Method to get a User_Sessions by its Id
        Task<User_Sessions> CreateUser_Session(User_Sessions User_Session); // Method to create a new User_Sessions
        Task<User_Sessions> UpdateUser_Session(User_Sessions User_Session); // Method to update an existing User_Sessions       
        Task<bool> DeleteUser_Session(Guid id); // Method to delete a User_Sessions by its Id
    }
}
