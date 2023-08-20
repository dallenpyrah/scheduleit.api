using ScheduleIt.Data.Models;
using ScheduleIt.Interfaces.Repositories;

namespace ScheduleIt.Business.Managers;

public class EmployeesManager
{
    private readonly IEmployeesRepository _employeesRepository;

    public EmployeesManager(IEmployeesRepository employeesRepository)
    {
        _employeesRepository = employeesRepository;
    }

    public async Task<Employee> GetEmployeeByEmail(string email)
    {
        return await _employeesRepository.GetEmployeeByEmail(email);
    }

    public async Task<Employee> CreateEmployee(Employee employee)
    {
        return await _employeesRepository.CreateEmployee(employee);
    }
}