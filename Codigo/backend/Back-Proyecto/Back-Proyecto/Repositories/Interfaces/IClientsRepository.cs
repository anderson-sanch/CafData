using Back_Proyecto.Models;

namespace Back_Proyecto.Repositories.Interfaces
{
    public interface IClientsRepository
    {
        Task<List<Clients>> GetClients();                 // Obtener todos los clientes
        Task<Clients?> GetClientById(Guid id);           // Obtener cliente por Id
        Task<Clients> CreateClient(Clients client);      // Crear cliente
        Task<Clients?> UpdateClient(Clients client);     // Actualizar cliente
        Task<bool> DeleteClient(Guid id);                // Eliminar cliente
    }
}
