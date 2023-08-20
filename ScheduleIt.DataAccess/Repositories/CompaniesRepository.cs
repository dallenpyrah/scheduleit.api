using Microsoft.EntityFrameworkCore;
using ScheduleIt.Data;
using ScheduleIt.Data.Models;
using ScheduleIt.Interfaces.Repositories;

namespace ScheduleIt.DataAccess.Repositories;

public class CompaniesRepository : ICompaniesRepository
{
    private readonly ScheduleItContext _context;

    public CompaniesRepository(ScheduleItContext context)
    {
        _context = context;
    }
    public async Task<List<Company?>> GetCompanies()
    {
        return await _context.Companies.ToListAsync();
    }

    public async Task<Company?> GetCompanyById(int id)
    {
        return await _context.Companies.FindAsync(id);
    }

    public async Task<Company> CreateCompany(Company createCompany)
    {
        await _context.Companies.AddAsync(createCompany);
        await _context.SaveChangesAsync();
        return createCompany;
    }

    public async Task<Company> UpdateCompany(Company modifiedCompany)
    {
        _context.Entry(modifiedCompany).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return modifiedCompany;
    }

    public async Task<Company> DeleteCompany(Company company)
    {
        _context.Companies.Remove(company);
        await _context.SaveChangesAsync();
        return company;
    }

    public async Task<Company?> GetCompanyByName(string companyName)
    {
        Company company = await _context.Companies.FirstOrDefaultAsync(c => c.Name == companyName);
        return company;
    }
}