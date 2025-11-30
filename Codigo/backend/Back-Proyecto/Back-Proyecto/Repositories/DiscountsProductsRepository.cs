using Back_Proyecto.Context;
using Back_Proyecto.Models;
using Back_Proyecto.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Back_Proyecto.Repositories.Implementations
{
    public class DiscountedProductsRepository : IDiscountedProducts
    {
        private readonly CafDataContext _context;

        public DiscountedProductsRepository(CafDataContext context)
        {
            _context = context;
        }

        public async Task<List<DiscountedProducts>> GetAll()
        {
            return await _context.DiscountedProducts
                .Include(dp => dp.Product)
                .Include(dp => dp.GlobalDiscount)
                .ToListAsync();
        }

        public async Task<DiscountedProducts> Add(DiscountedProducts item)
        {
            _context.DiscountedProducts.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<bool> Delete(Guid productId, Guid globalId)
        {
            var find = await _context.DiscountedProducts
                .FirstOrDefaultAsync(x => x.Product_Id == productId && x.Global_Id == globalId);

            if (find == null) return false;

            _context.DiscountedProducts.Remove(find);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
