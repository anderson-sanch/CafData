using Back_Proyecto.Models;

namespace Back_Proyecto.Repositories.Interfaces
{
    public interface ICompany
    {
        Task<List<Company>> GetCompany();
        Task<Company> GetCompany_Id(Guid id);
        Task<Company> CreateCompany(Company company);
        Task<Company> UpdateCompany(Company company);
        Task<bool> InactiveCompany(Guid id);
    }

}
