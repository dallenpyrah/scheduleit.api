using Microsoft.EntityFrameworkCore;
using ScheduleIt.Data;
using ScheduleIt.Data.Models;
using ScheduleIt.Interfaces.Repositories;

namespace ScheduleIt.DataAccess.Repositories;

public class EmployeesRepository : IEmployeesRepository
{
    private readonly ScheduleItContext _context;

    public EmployeesRepository(ScheduleItContext context)
    {
        _context = context;
    }
    public async Task<Employee?> GetEmployeeByEmail(string email)
    {
        return await _context.Employees.FirstOrDefaultAsync(e => e.Email == email);
    }

    public async Task<Employee> CreateEmployee(Employee employee)
    {
        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();
        return employee;
    }
}