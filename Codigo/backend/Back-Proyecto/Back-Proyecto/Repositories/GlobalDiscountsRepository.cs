using Back_Proyecto.Context;
using Back_Proyecto.Models;
using Back_Proyecto.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Back_Proyecto.Repositories.Implementations
{
    public class GlobalDiscountsRepository : IGlobalDiscounts
    {
        private readonly CafDataContext _context;

        public GlobalDiscountsRepository(CafDataContext context)
        {
            _context = context;
        }

        public async Task<List<GlobalDiscounts>> GetGlobalDiscounts()
        {
            return await _context.Global_Discounts.ToListAsync();
        }

        public async Task<GlobalDiscounts> GetGlobalDiscount_Id(Guid id)
        {
            return await _context.Global_Discounts
                                 .FirstOrDefaultAsync(g => g.Global_Id == id);
        }

        public async Task<GlobalDiscounts> CreateGlobalDiscount(GlobalDiscounts discount)
        {
            _context.Global_Discounts.Add(discount);
            await _context.SaveChangesAsync();
            return discount;
        }

        public async Task<GlobalDiscounts> UpdateGlobalDiscount(GlobalDiscounts discount)
        {
            _context.Global_Discounts.Update(discount);
            await _context.SaveChangesAsync();
            return discount;
        }

        public async Task<bool> DeleteGlobalDiscount(Guid id)
        {
            var globalDiscount = await _context.Global_Discounts
                                               .FirstOrDefaultAsync(g => g.Global_Id == id);

            if (globalDiscount == null)
                return false;

            _context.Global_Discounts.Remove(globalDiscount);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
