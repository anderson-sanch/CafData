using System;
using Back_Proyecto.Context;
using Back_Proyecto.Models;
using Back_Proyecto.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Back_Proyecto.Repositories
{
    public class CouponsRepository : ICoupons
    {
        private readonly CafDataContext _context;

        public CouponsRepository(CafDataContext context)
        {
            _context = context;
        }

        public async Task<List<Coupons>> GetCoupons()
        {
            return await _context.Coupons.ToListAsync();
        }

        public async Task<Coupons> GetCoupon_Id(Guid id)
        {
            return await _context.Coupons.FirstOrDefaultAsync(x => x.Coupon_Id == id);
        }

        public async Task<Coupons> CreateCoupon(Coupons coupon)
        {
            _context.Coupons.Add(coupon);
            await _context.SaveChangesAsync();
            return coupon;
        }

        public async Task<Coupons> UpdateCoupon(Coupons coupon)
        {
            _context.Coupons.Update(coupon);
            await _context.SaveChangesAsync();
            return coupon;
        }

        public async Task<bool> InactiveCoupon(Guid id)
        {
            var cp = await GetCoupon_Id(id);
            if (cp == null) return false;

            cp.Status = false;
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
