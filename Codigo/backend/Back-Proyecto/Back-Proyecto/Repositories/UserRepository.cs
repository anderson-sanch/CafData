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
			return await _context.Users.FindAsync(id);
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
				var UserToUpdate = await _context.Users.FindAsync(user.User_Id);
				if (UserToUpdate == null) 
				{
					return false;
					throw new Exception("Usuario no encontrado");
                }
                UserToUpdate.Name = user.Name;
				UserToUpdate.Username = user.Username;
				UserToUpdate.Password = user.Password;
				UserToUpdate.Rol_Id = user.Rol_Id;
				UserToUpdate.Status = user.Status;

				_context.Users.Update(UserToUpdate);
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
				var UserToDelete = await _context.Users.FindAsync(id);
				if (UserToDelete == null)
				{
					return false;
					throw new Exception("Usuario No encontrado");
				}
				_context.Users.Remove(UserToDelete);
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