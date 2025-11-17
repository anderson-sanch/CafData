using Back_Proyecto.Context;
using Back_Proyecto.Models;
using Back_Proyecto.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Back_Proyecto.Repositories
{
    public class DiscountsProductsRepository : IDiscountsProducts
{
    private readonly CafDataContext _context;

    public DiscountsProductsRepository(CafDataContext context)
    {
        _context = context;
    }

    public async Task<List<Disocunts_Products>> GetDiscountsProducts()
    {
        return await _context.Discounts_Products.ToListAsync();
    }

    public async Task<Disocunts_Products> GetDiscountProduct_Id(Guid productId, Guid discountId)
    {
        return await _context.Discounts_Products
            .FirstOrDefaultAsync(x => x.Product_Id == productId && x.Global_Id == discountId);
    }

    public async Task<Disocunts_Products> CreateDiscountProduct(Disocunts_Products dp)
    {
        _context.Discounts_Products.Add(dp);
        await _context.SaveChangesAsync();
        return dp;
    }

    public async Task<Disocunts_Products> UpdateDiscountProduct(Disocunts_Products dp)
    {
        _context.Discounts_Products.Update(dp);
        await _context.SaveChangesAsync();
        return dp;
    }

    public async Task<bool> DeleteDiscountProduct(Guid productId, Guid discountId)
    {
        var dp = await GetDiscountProduct_Id(productId, discountId);

        if (dp == null) return false;

        _context.Discounts_Products.Remove(dp);
        await _context.SaveChangesAsync();
        return true;
    }
}

}
