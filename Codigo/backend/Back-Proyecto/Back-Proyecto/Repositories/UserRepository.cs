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

        public async Task<Users> CreateUser(Users user)
        {
            try
            {
                bool existingUser = await _context.Users.AnyAsync(u => u.Username.ToLower() == user.Username.ToLower());

                if (existingUser) 
                {
                    throw new Exception("No puedes usar este Nombre de usuario, intenta con otro");
                    
                }

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return user;
            }
            catch (DbUpdateException ex)
            {
                var innerMessage = ex.InnerException?.Message ?? ex.Message;
                throw new Exception($"Error al insertar usuario (DB): {innerMessage}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al insertar usuario: {ex.Message}");
            }
        }



        public async Task<Users> UpdateUser(Users user)
        {
            try
            {
                var ExistingUser = await _context.Users.FindAsync(user.User_Id);

                if (ExistingUser == null)
                {
                    return null;
                }

                ExistingUser.Name = user.Name;
                ExistingUser.Username = user.Username;
                ExistingUser.Password = user.Password;
                ExistingUser.Rol_Id = user.Rol_Id;
                ExistingUser.Status = user.Status;

                _context.Users.Update(ExistingUser);
                await _context.SaveChangesAsync();

                return ExistingUser; 
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar usuario: {ex.Message}");
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

