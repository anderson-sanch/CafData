using System;
using Back_Proyecto.Context;
using Back_Proyecto.Models;
using Back_Proyecto.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Back_Proyecto.Repositories
{
    public class CompanyRepository : ICompany
    {
        private readonly CafDataContext _context;

        public CompanyRepository(CafDataContext context)
        {
            _context = context;
        }

        public async Task<List<Company>> GetCompany()
        {
            return await _context.Company. ToListAsync();
        }

        public async Task<Company> GetCompany_Id(Guid id)
        {
            return await _context.Company.FirstOrDefaultAsync(x => x.Company_Id == id);
        }

        public async Task<Company> CreateCompany(Company company)
        {
            _context.Company.Add(company);
            await _context.SaveChangesAsync();
            return company;
        }

        public async Task<Company> UpdateCompany(Company company)
        {
            _context.Company.Update(company);
            await _context.SaveChangesAsync();
            return company;
        }

        public async Task<bool> InactiveCompany(Guid id)
        {
            var c = await GetCompany_Id(id);
            if (c == null) return false;

            

            await _context.SaveChangesAsync();
            return true;
        }
    }

}
