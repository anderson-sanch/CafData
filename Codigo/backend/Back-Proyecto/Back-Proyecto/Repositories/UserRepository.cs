using System.Linq.Expressions;
using Back_Proyecto.Context;
using Back_Proyecto.Models;
using Back_Proyecto.Repositories.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Back_Proyecto.Repositories
{
    public class UserRepository : IUsersRepository
    {
        private readonly CafDataContext _context;

        public UserRepository(CafDataContext context)
        {
            _context = context;
        }

        public async Task<List<Users>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<Users> GetUserById(Guid id)
        {

            var User = await _context.Users.FindAsync(id);
            if (User == null)
            {
                throw new Exception("Usuario no encontrado");
            }
            return User;

        }

        public async Task<bool> CreateUser(Users user)
        {
            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task<bool> UpdateUser(Users user)
        {
            try
            {
                var ExistingUser = await _context.Users.FindAsync(user.User_Id);
                if (ExistingUser == null)
                {
                    return false;
                    throw new Exception("Usuario no encontrado");
                }

                ExistingUser.Name = user.Name;
                ExistingUser.Username = user.Username;
                ExistingUser.Password = user.Password;
                ExistingUser.Rol_Id = user.Rol_Id;
                ExistingUser.Status = user.Status;

                _context.Users.Update(ExistingUser);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task<bool> DeleteUser(Guid id)
        {
            try
            {
                var ExistingUser = await _context.Users.FindAsync(id);
                if (ExistingUser == null)
                {
                    return false;
                    throw new Exception("Usuario no encontrado");
                }

                _context.Users.Remove(ExistingUser);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}

