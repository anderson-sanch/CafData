using Back_Proyecto.Context;
using Back_Proyecto.Models;
using Back_Proyecto.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Back_Proyecto.Repositories
{
    public class SalesRepository : ISales
    {
        private readonly CafDataContext _context;

        public SalesRepository(CafDataContext context)
        {
            _context = context;
        }

        // ===============================================
        // GET ALL
        // ===============================================
        public async Task<List<Sales>> GetSales()
        {
            return await _context.Sales
                .OrderByDescending(x => x.Sale_Date)
                .ToListAsync();
        }

        // ===============================================
        // GET BY ID
        // ===============================================
        public async Task<Sales> GetSale_Id(Guid id)
        {
            var sale = await _context.Sales.FindAsync(id);

            if (sale == null)
                throw new KeyNotFoundException("Venta no encontrada.");

            return sale;
        }

        // ===============================================
        // CREATE
        // ===============================================
        public async Task<Sales> CreateSale(Sales sale)
        {
            if (sale.Sale_Date == default)
                sale.Sale_Date = DateTime.UtcNow;

            if (sale.Total <= 0)
                throw new Exception("El total debe ser mayor a 0.");

            sale.Sale_Id = Guid.NewGuid();

            _context.Sales.Add(sale);
            await _context.SaveChangesAsync();

            return sale;
        }

        // ===============================================
        // UPDATE
        // ===============================================
        public async Task<Sales> UpdateSale(Sales sale)
        {
            var existing = await _context.Sales.FindAsync(sale.Sale_Id);

            if (existing == null)
                throw new KeyNotFoundException("Venta no encontrada para actualización.");

            existing.User_Id = sale.User_Id;
            existing.Client_Id = sale.Client_Id;
            existing.Cupon_Id = sale.Cupon_Id;
            existing.Sale_Date = sale.Sale_Date;
            existing.Total = sale.Total;
            existing.Payment_Method = sale.Payment_Method;
            existing.Status = sale.Status;
            existing.Total_Discount = sale.Total_Discount;
            existing.Type_Discount = sale.Type_Discount;

            await _context.SaveChangesAsync();

            return existing;
        }

        // ===============================================
        // DELETE
        // ===============================================
        public async Task<bool> DeleteSale(Guid id)
        {
            var existing = await _context.Sales.FindAsync(id);

            if (existing == null)
                return false;

            _context.Sales.Remove(existing);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
