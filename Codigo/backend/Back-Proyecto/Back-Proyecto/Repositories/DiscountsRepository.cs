using Back_Proyecto.Context;
using Back_Proyecto.Models;
using Back_Proyecto.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Back_Proyecto.Repositories.Implementations
{
    public class DiscountsRepository : IDiscounts
    {
        private readonly CafDataContext _context;

        public DiscountsRepository(CafDataContext context)
        {
            _context = context;
        }

        public async Task<List<Discounts>> GetDiscounts()
        {
            return await _context.Discounts
                .Include(d => d.Products)
                .ToListAsync();
        }

        public async Task<Discounts> GetDiscountById(Guid id)
        {
            return await _context.Discounts
                .Include(d => d.Products)
                .FirstOrDefaultAsync(d => d.Discount_Id == id);
        }

        public async Task<Discounts> CreateDiscount(Discounts discount)
        {
            await _context.Discounts.AddAsync(discount);
            await _context.SaveChangesAsync();
            return discount;
        }

        public async Task<Discounts> UpdateDiscount(Discounts discount)
        {
            _context.Discounts.Update(discount);
            await _context.SaveChangesAsync();
            return discount;
        }

        public async Task<bool> DeleteDiscount(Guid id)
        {
            var discount = await _context.Discounts.FirstOrDefaultAsync(d => d.Discount_Id == id);
            if (discount == null) return false;

            _context.Discounts.Remove(discount);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
