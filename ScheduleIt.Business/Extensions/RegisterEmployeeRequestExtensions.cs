using System.ComponentModel.DataAnnotations;
using System.Globalization;
using ScheduleIt.Business.Exceptions;
using ScheduleIt.Business.Utils;
using ScheduleIt.Contracts.Employee;
using ScheduleIt.Data.Models;

namespace ScheduleIt.Business.Extensions;

public static class RegisterEmployeeRequestExtensions
{
    public static void Validate(this RegisterEmployeeRequest registerEmployeeRequest)
    {
        registerEmployeeRequest.IsEmailValid();
        if (registerEmployeeRequest.CompanyId <= 0)
        {
            throw new InvalidCompanyIdException("Company Id is invalid");
        }
    }
    private static void IsEmailValid(this RegisterEmployeeRequest employee)
    {
        EmailAddressAttribute emailAttribute = new EmailAddressAttribute();
        if (!emailAttribute.IsValid(employee.Email))
        {
            throw new InvalidEmailException("Email is invalid");
        }
    }
    
    public static Employee CreateEmployeeFromRegisterRequest(this RegisterEmployeeRequest registerEmployeeRequest)
    {
        Employee employee = new()
        {
            Username = registerEmployeeRequest.Username,
            FirstName = registerEmployeeRequest.FirstName,
            LastName = registerEmployeeRequest.LastName,
            Email = registerEmployeeRequest.Email,
            Password = registerEmployeeRequest.Password,
            CompanyId = registerEmployeeRequest.CompanyId,
            Phone = registerEmployeeRequest.Phone,
            Address = registerEmployeeRequest.Address,
            Position = registerEmployeeRequest.Position,
            Department = registerEmployeeRequest.Department,
            EmergencyContactName = registerEmployeeRequest.EmergencyContactName,
            EmergencyContactPhone = registerEmployeeRequest.EmergencyContactPhone,
            HireDate = DateTimeUtil.ConvertToUtc(registerEmployeeRequest.HireDate),
            Salary = registerEmployeeRequest.Salary,
            PartTime = registerEmployeeRequest.PartTime ?? false,
            RoleId = registerEmployeeRequest.RoleId,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        return employee;
    }
}