using System;
using Back_Proyecto.Context;
using Back_Proyecto.Models;
using Back_Proyecto.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Back_Proyecto.Repositories
{
    public class CategoriesRepository : ICategories
    {
        private readonly CafDataContext _context;

        public CategoriesRepository(CafDataContext context)
        {
            _context = context;
        }

        public async Task<List<Catogories>> GetCategories()
        {
            return await _context.Catogories.ToListAsync();
        }

        public async Task<Catogories> GetCategory_Id(Guid id)
        {
            return await _context.Catogories.FirstOrDefaultAsync(x => x.Category_Id == id);
        }

        public async Task<Catogories> CreateCategory(Catogories category)
        {
            _context.Catogories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Catogories> UpdateCategory(Catogories category)
        {
            _context.Catogories.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<bool> InactiveCategory(Guid id)
        {
            var cat = await GetCategory_Id(id);
            if (cat == null) return false;

            cat.status = false;
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
