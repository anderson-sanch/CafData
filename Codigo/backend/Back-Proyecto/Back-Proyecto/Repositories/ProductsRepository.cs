using Back_Proyecto.Context;
using Back_Proyecto.Models;
using Back_Proyecto.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back_Proyecto.Repositories.Implementations
{
    public class ProductsRepository : IProducts
    {
        private readonly CafDataContext _context;

        public ProductsRepository(CafDataContext context)
        {
            _context = context;
        }
        public async Task<List<Products>> GetProducts()
        {
            return await _context.Products
                                 .Include(p => p.Category)               // <- singular
                                 .Include(p => p.DiscountedProducts)    // opcional: cargar descuentos aplicados
                                 .ToListAsync();
        }

        public async Task<Products> GetProduct(Guid productId)
        {
            return await _context.Products
                                 .Include(p => p.Category)
                                 .Include(p => p.DiscountedProducts)
                                 .FirstOrDefaultAsync(p => p.Product_Id == productId);
        }

        public async Task<Products> CreateProduct(Products product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }


        public async Task<Products> UpdateProduct(Products product)
        {
            var existingProduct = await _context.Products.FindAsync(product.Product_Id);
            if (existingProduct == null) return null;

            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.Stock = product.Stock;
            existingProduct.Min_Stock = product.Min_Stock;
            existingProduct.Category_Id = product.Category_Id;

            _context.Products.Update(existingProduct);
            await _context.SaveChangesAsync();

            return existingProduct;
        }

        public async Task<bool> DeleteProduct(Guid productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
