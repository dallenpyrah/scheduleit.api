using ScheduleIt.Data.Models;

namespace ScheduleIt.Interfaces.Repositories;

public interface ICompaniesRepository
{
    Task<List<Company?>> GetCompanies();
    Task<Company?> GetCompanyById(int id);
    Task<Company> CreateCompany(Company createCompany);
    Task<Company> UpdateCompany(Company updateCompany);
    Task<Company> DeleteCompany(Company id);
    Task<Company?> GetCompanyByName(string companyName);
}