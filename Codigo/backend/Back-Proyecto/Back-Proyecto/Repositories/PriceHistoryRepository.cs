using Back_Proyecto.Context;
using Back_Proyecto.Models;
using Back_Proyecto.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Back_Proyecto.Repositories
{
    public class PriceHistoryRepository : IPriceHistory
    {
        private readonly CafDataContext _context;

        public PriceHistoryRepository(CafDataContext context)
        {
            _context = context;
        }

        // GET ALL
        public async Task<List<Price_History>> GetPriceHistory()
        {
            return await _context.Price_Histories
                .OrderByDescending(x => x.Change_Date)
                .ToListAsync();
        }

        // GET BY ID
        public async Task<Price_History> GetPriceHistory_Id(Guid id)
        {
            var record = await _context.Price_Histories.FindAsync(id);

            if (record == null)
                throw new KeyNotFoundException("No se encontró el registro de historial de precios.");

            return record;
        }

        // CREATE
        public async Task<Price_History> CreatePriceHistory(Price_History history)
        {
            if (history.Product_Id == Guid.Empty)
                throw new Exception("Debe especificar un producto válido.");

            if (history.New_Price <= 0)
                throw new Exception("El nuevo precio debe ser mayor a 0.");

            if (history.Previous_Price < 0)
                throw new Exception("El precio anterior no puede ser negativo.");

            if (history.History_Id == Guid.Empty)
                history.History_Id = Guid.NewGuid();

            if (history.Change_Date == default)
                history.Change_Date = DateTime.UtcNow;

            _context.Price_Histories.Add(history);
            await _context.SaveChangesAsync();

            return history;
        }

        // UPDATE
        public async Task<Price_History> UpdatePriceHistory(Price_History history)
        {
            var existing = await _context.Price_Histories.FindAsync(history.History_Id);

            if (existing == null)
                throw new KeyNotFoundException("No se encontró el registro de historial para actualizar.");

            if (history.New_Price <= 0)
                throw new Exception("El nuevo precio debe ser mayor a 0.");

            if (history.Previous_Price < 0)
                throw new Exception("El precio anterior no puede ser negativo.");

            existing.Product_Id = history.Product_Id;
            existing.Previous_Price = history.Previous_Price;
            existing.New_Price = history.New_Price;
            existing.Change_Date = history.Change_Date;
            existing.User_Id = history.User_Id;
            existing.Reason = history.Reason;

            await _context.SaveChangesAsync();
            return existing;
        }

        // DELETE
        public async Task<bool> DeletePriceHistory(Guid id)
        {
            var existing = await _context.Price_Histories.FindAsync(id);

            if (existing == null)
                return false;

            _context.Price_Histories.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
