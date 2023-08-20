using System.ComponentModel.DataAnnotations;
using ScheduleIt.Data.Models;

namespace ScheduleIt.Business.Extensions;

public static class CompanyExtensions
{
    public static void Validate(this Company company)
    {
        EmailAddressAttribute emailAddressAttribute = new();
        if (!emailAddressAttribute.IsValid(company.Email))
            throw new ArgumentException("Email is not valid");
        
        if (string.IsNullOrWhiteSpace(company.Name))
            throw new ArgumentException("Name is required");
        
        if (string.IsNullOrWhiteSpace(company.Address))
            throw new ArgumentException("Address is required");
    }
    
    public static void MapUpdateCompanyToExistingCompany(this Company existingCompany, Company updateCompany)
    {
        existingCompany.Name = updateCompany.Name;
        existingCompany.Address = updateCompany.Address;
        existingCompany.City = updateCompany.City;
        existingCompany.State = updateCompany.State;
        existingCompany.Country = updateCompany.Country;
        existingCompany.Description = updateCompany.Description;
        existingCompany.Email = updateCompany.Email;
        existingCompany.Industry = updateCompany.Industry;
        existingCompany.Logo = updateCompany.Logo;
        existingCompany.Website = updateCompany.Website;
        existingCompany.UpdatedAt = DateTime.UtcNow;
        existingCompany.PhoneNumber = updateCompany.PhoneNumber;
        existingCompany.PostalCode = updateCompany.PostalCode;
    }
}