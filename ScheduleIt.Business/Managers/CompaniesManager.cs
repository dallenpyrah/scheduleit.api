using ScheduleIt.Business.Extensions;
using ScheduleIt.Contracts.Company;
using ScheduleIt.Data.Models; // Assuming your Company model is defined here
using ScheduleIt.Interfaces.Repositories;

namespace ScheduleIt.Business.Managers
{
    public class CompaniesManager
    {
        private readonly ICompaniesRepository _companiesRepository;

        public CompaniesManager(ICompaniesRepository companiesRepository)
        {
            _companiesRepository = companiesRepository;
        }

        public async Task<List<Company?>> GetCompanies()
        {
            return await _companiesRepository.GetCompanies();
        }

        public async Task<Company?> GetCompanyById(int id)
        {
            return await _companiesRepository.GetCompanyById(id);
        }

        public async Task<Company> CreateCompany(CreateCompanyRequest createCompanyRequest)
        {
            Company? existingCompany = await GetCompanyByName(createCompanyRequest.Name);
            if (existingCompany != null)
                throw new ArgumentException($"Company with name {createCompanyRequest.Name} already exists");

            return await _companiesRepository.CreateCompany(createCompanyRequest.CreateCompanyFromCreateCompanyRequest());
        }

        public async Task<Company> UpdateCompany(Company updateCompany)
        {
            Company? existingCompany = await _companiesRepository.GetCompanyById(updateCompany.Id);
            if (existingCompany == null)
                throw new KeyNotFoundException($"Company with id {updateCompany.Id} could not be found");
            
            existingCompany.MapUpdateCompanyToExistingCompany(updateCompany);
            return await _companiesRepository.UpdateCompany(existingCompany);
        }

        public async Task<Company> DeleteCompany(int id)
        {
            Company? existingCompany = await _companiesRepository.GetCompanyById(id);
            if (existingCompany == null)
                throw new KeyNotFoundException($"Company with id {id} could not be found");
            
            return await _companiesRepository.DeleteCompany(existingCompany);
        }

        public async Task<Company?> GetCompanyByName(string companyName)
        {
            return await _companiesRepository.GetCompanyByName(companyName);
        }
    }
}