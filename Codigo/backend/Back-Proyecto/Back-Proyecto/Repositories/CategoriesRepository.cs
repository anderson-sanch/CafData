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

        public async Task<List<Categories>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Categories> GetCategory_Id(Guid id)
        {
            return await _context.Categories.FirstOrDefaultAsync(x => x.Category_Id == id);
        }

        public async Task<Categories> CreateCategory(Categories category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Categories> UpdateCategory(Categories category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<bool> DeleteCategory(Guid id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) return false;

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
