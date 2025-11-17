using System;
using Back_Proyecto.Context;
using Back_Proyecto.Models;
using Back_Proyecto.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Back_Proyecto.Repositories
{
    public class GlobalDiscountsRepository : IGlobalDiscounts
    {
        private readonly CafDataContext _context;

        public GlobalDiscountsRepository(CafDataContext context)
        {
            _context = context;
        }

        public async Task<List<Global_Discounts>> GetGlobalDiscounts()
        {
            return await _context.Global_Discounts.ToListAsync();
        }

        public async Task<Global_Discounts> GetGlobalDiscount_Id(Guid id)
        {
            return await _context.Global_Discounts.FirstOrDefaultAsync(x => x.Global_Id == id);
        }

        public async Task<Global_Discounts> CreateGlobalDiscount(Global_Discounts discount)
        {
            _context.Global_Discounts.Add(discount);
            await _context.SaveChangesAsync();
            return discount;
        }

        public async Task<Global_Discounts> UpdateGlobalDiscount(Global_Discounts discount)
        {
            _context.Global_Discounts.Update(discount);
            await _context.SaveChangesAsync();
            return discount;
        }

        public async Task<bool> InactiveGlobalDiscount(Guid id)
        {
            var dis = await GetGlobalDiscount_Id(id);
            if (dis == null) return false;

            dis.Status = false;
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
