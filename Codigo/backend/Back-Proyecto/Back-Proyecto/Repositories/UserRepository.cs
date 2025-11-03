using System.Linq.Expressions;
using Back_Proyecto.Context;
using Back_Proyecto.Models;
using Back_Proyecto.Repositories.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Back_Proyecto.Repositories.interfaces

{
    public class UserRepository : Users // Implementación del repositorio de Users
    {
        private readonly CafDataContext _context; // Contexto de datos para acceder a la base de datos

        public UserRepository(CafDataContext context) // Constructor con inyección de dependencia
        {
            _context = context; // Inyección de dependencia del contexto de datos
        }
        public async Task<Users> CreateUser(Users User) // Implementación del método para crear un nuevo usuario
        {
            _context.Users.Add(User); // Agregar el nuevo usuario al contexto
            await _context.SaveChangesAsync(); // Guardar los cambios en la base de datos
            return User; // Devolver el usuario creado
        }
    }
}