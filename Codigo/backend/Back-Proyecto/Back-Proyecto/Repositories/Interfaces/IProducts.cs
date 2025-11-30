using Back_Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back_Proyecto.Repositories.Interfaces
{
    public interface IProducts
    {
        Task<List<Products>> GetProducts();
        Task<Products> GetProduct(Guid productId);
        Task<Products> CreateProduct(Products product);
        Task<Products> UpdateProduct(Products product);
        Task<bool> DeleteProduct(Guid productId);
    }
}
