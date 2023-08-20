using ScheduleIt.Contracts.Company;
using ScheduleIt.Data.Models;

namespace ScheduleIt.Business.Extensions;

public static class CreateCompanyRequestExtensions
{
    public static Company CreateCompanyFromCreateCompanyRequest(this CreateCompanyRequest createCompanyRequest)
    {
        Company company = new Company
        {
            Name = createCompanyRequest.Name,
            Address = createCompanyRequest.Address,
            City = createCompanyRequest.City,
            State = createCompanyRequest.State,
            PostalCode = createCompanyRequest.PostalCode,
            Country = createCompanyRequest.Country,
            PhoneNumber = createCompanyRequest.PhoneNumber,
            Email = createCompanyRequest.Email,
            Website = createCompanyRequest.Website,
            Industry = createCompanyRequest.Industry,
            Description = createCompanyRequest.Description,
            Logo = createCompanyRequest.Logo,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
        
        return company;
    }
}