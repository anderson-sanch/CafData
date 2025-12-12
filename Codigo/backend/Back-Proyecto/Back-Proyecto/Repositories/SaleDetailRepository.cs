using Back_Proyecto.Context;
using Back_Proyecto.Models;
using Back_Proyecto.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Back_Proyecto.Repositories
{
    public class SaleDetailRepository : ISale_Detail
    {
        private readonly CafDataContext _context;

        public SaleDetailRepository(CafDataContext context)
        {
            _context = context;
        }

        public async Task<List<Sale_Detail>> GetAll()
        {
            return await _context.Sale_Details.ToListAsync();
        }

        public async Task<Sale_Detail> GetById(Guid id)
        {
            var detail = await _context.Sale_Details.FirstOrDefaultAsync(x => x.Detail_Id == id);

            if (detail == null)
                throw new KeyNotFoundException("Detalle no encontrado.");

            return detail;
        }

        public async Task<List<Sale_Detail>> GetBySaleId(Guid saleId)
        {
            return await _context.Sale_Details
                .Where(x => x.Sale_Id == saleId)
                .ToListAsync();
        }

        public async Task<Sale_Detail> Create(Sale_Detail detail)
        {
            detail.Subtotal = (detail.Quantity * detail.Unit_Price) - detail.Discount_Applied;

            detail.Detail_Id = Guid.NewGuid();

            _context.Sale_Details.Add(detail);
            await _context.SaveChangesAsync();

            return detail;
        }

        public async Task<Sale_Detail> Update(Sale_Detail detail)
        {
            var existing = await _context.Sale_Details.FindAsync(detail.Detail_Id);

            if (existing == null)
                throw new KeyNotFoundException("Detalle no encontrado para actualizar.");

            existing.Quantity = detail.Quantity;
            existing.Unit_Price = detail.Unit_Price;
            existing.Discount_Applied = detail.Discount_Applied;

            existing.Subtotal = (existing.Quantity * existing.Unit_Price) - existing.Discount_Applied;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> Delete(Guid id)
        {
            var existing = await _context.Sale_Details.FindAsync(id);

            if (existing == null)
                return false;

            _context.Sale_Details.Remove(existing);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
