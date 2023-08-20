using System.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ScheduleIt.Business.Exceptions;
using ScheduleIt.Business.Extensions;
using ScheduleIt.Business.Managers;
using ScheduleIt.Contracts.Auth;
using ScheduleIt.Contracts.Employee;
using ScheduleIt.Data.Models;

public class AuthManager
{
    private readonly IConfiguration _configuration;
    private readonly EmployeesManager _employeesManager;
    private readonly CompaniesManager _companiesManager;

    public AuthManager(IConfiguration configuration, EmployeesManager employeesManager, CompaniesManager companiesManager)
    {
        _configuration = configuration;
        _employeesManager = employeesManager;
        _companiesManager = companiesManager;
    }

    public async Task<string> Login(LoginRequest loginRequest)
    {
        Employee? employee = await _employeesManager.GetEmployeeByEmail(loginRequest.Email);
        if (employee == null)
        {
            throw new KeyNotFoundException("Email does not exist");
        }
        
        bool isPasswordValid = BCrypt.Net.BCrypt.Verify(loginRequest.Password, employee.Password);
        if (!isPasswordValid)
        {
            throw new InvalidPasswordException("Invalid Password, please try again");
        }
        
        return GenerateJwtToken(employee);
    }

    public async Task<string> RegisterEmployee(RegisterEmployeeRequest registerEmployeeRequest)
    {
        registerEmployeeRequest.Validate();

        Employee? existingEmployee = await _employeesManager.GetEmployeeByEmail(registerEmployeeRequest.Email);
        if (existingEmployee != null)
        {
            throw new DuplicateEmailException("Email already exists");
        }
        
        registerEmployeeRequest.Password = await HashPassword(registerEmployeeRequest.Password);
        
        Company? company = await _companiesManager.GetCompanyById(registerEmployeeRequest.CompanyId);
        if (company == null)
        {
            throw new KeyNotFoundException("Company does not exist");
        }

        Employee newEmployee = await _employeesManager.CreateEmployee(registerEmployeeRequest.CreateEmployeeFromRegisterRequest());
        return GenerateJwtToken(newEmployee);
    }

    private string GenerateJwtToken(Employee employee)
    {
        string? jwtSecret = _configuration["JWT_SECRET"];
        if (string.IsNullOrEmpty(jwtSecret))
        {
            throw new Exception("JWT_SECRET is not defined");
        }

        List<Claim> claims = new List<Claim>()
        {
            new(ClaimTypes.NameIdentifier, employee.Id.ToString()),
            new(ClaimTypes.Email, employee.Email),
            new(ClaimTypes.Name, employee.FirstName + " " + employee.LastName),
            new("CompanyId", employee.CompanyId.ToString() ?? string.Empty),
        };

        SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret));
        SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

        SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddHours(12),
            SigningCredentials = signingCredentials
        };

        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
    

    public Task<string> HashPassword(string password)
    {
        return Task.FromResult(BCrypt.Net.BCrypt.HashPassword(password));
    }
}
