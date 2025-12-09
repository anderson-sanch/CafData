using Back_Proyecto.Models;

namespace Back_Proyecto.Repositories.Interfaces
{
    public interface IInventoryMovement
    {
        Task<IEnumerable<InventoryMovement>> GetAll();
        Task<InventoryMovement?> GetById(Guid id);
        Task<InventoryMovement> Create(InventoryMovement movement);
        Task<InventoryMovement> Update(InventoryMovement movement);
        Task<bool> Delete(Guid id);
    }
}
