using Back_Proyecto.Context;
using Back_Proyecto.Models;
using Back_Proyecto.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Back_Proyecto.Repositories
{
    public class ClientsRepository : IClientsRepository
    {
        private readonly CafDataContext _context;

        public ClientsRepository(CafDataContext context)
        {
            _context = context;
        }

        // =============================
        // GET ALL CLIENTS
        // =============================
        public async Task<List<Clients>> GetClients()
        {
            return await _context.Clients.ToListAsync();
        }

        // =============================
        // GET CLIENT BY ID
        // =============================
        public async Task<Clients?> GetClientById(Guid id)
        {
            return await _context.Clients.FindAsync(id);
        }

        // =============================
        // CREATE CLIENT
        // =============================
        public async Task<Clients> CreateClient(Clients client)
        {
            try
            {
                // Validación simple opcional
                bool exists = await _context.Clients
                    .AnyAsync(c => c.Email.ToLower() == client.Email.ToLower());

                if (exists)
                {
                    throw new Exception("Ya existe un cliente con ese correo.");
                }

                // Si la BD no autogenera fecha
                if (client.Registration_Date == default(DateTime))
                    client.Registration_Date = DateTime.UtcNow;

                _context.Clients.Add(client);
                await _context.SaveChangesAsync();

                return client;
            }
            catch (DbUpdateException ex)
            {
                var inner = ex.InnerException?.Message ?? ex.Message;
                throw new Exception($"Error DB al crear cliente: {inner}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al crear cliente: {ex.Message}");
            }
        }

        // =============================
        // UPDATE CLIENT
        // =============================
        public async Task<Clients?> UpdateClient(Clients client)
        {
            try
            {
                var existingClient = await _context.Clients.FindAsync(client.Client_Id);

                if (existingClient == null)
                {
                    return null;
                }

                existingClient.Name = client.Name;
                existingClient.Email = client.Email;
                existingClient.Phone_Number = client.Phone_Number;
                existingClient.Address = client.Address;

                _context.Clients.Update(existingClient);
                await _context.SaveChangesAsync();

                return existingClient;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar cliente: {ex.Message}");
            }
        }

        // =============================
        // DELETE CLIENT
        // =============================
        public async Task<bool> DeleteClient(Guid id)
        {
            try
            {
                var existingClient = await _context.Clients.FindAsync(id);

                if (existingClient == null)
                    return false;

                _context.Clients.Remove(existingClient);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
