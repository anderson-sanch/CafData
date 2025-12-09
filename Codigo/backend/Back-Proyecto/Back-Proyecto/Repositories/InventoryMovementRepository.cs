using Back_Proyecto.Context;
using Back_Proyecto.Models;
using Back_Proyecto.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Back_Proyecto.Repositories.Implementations
{
    public class Inventory_MovementRepository : IInventoryMovement
    {
        private readonly CafDataContext _context;

        public Inventory_MovementRepository(CafDataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InventoryMovement>> GetAll()
        {
            return await _context.InventoryMovement
                .Include(p => p.Product)
                .Include(u => u.User)
                .ToListAsync();
        }

        public async Task<InventoryMovement?> GetById(Guid id)
        {
            return await _context.InventoryMovement
                .Include(p => p.Product)
                .Include(u => u.User)
                .FirstOrDefaultAsync(x => x.Movement_Id == id);
        }

        public async Task<InventoryMovement> Create(InventoryMovement movement)
        {
            _context.InventoryMovement.Add(movement);
            await _context.SaveChangesAsync();
            return movement;
        }

        public async Task<InventoryMovement> Update(InventoryMovement movement)
        {
            _context.InventoryMovement.Update(movement);
            await _context.SaveChangesAsync();
            return movement;
        }

        public async Task<bool> Delete(Guid id)
        {
            var existing = await _context.InventoryMovement.FindAsync(id);

            if (existing == null)
                return false;

            _context.InventoryMovement.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
