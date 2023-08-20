using ScheduleIt.Data.Models;

namespace ScheduleIt.Interfaces.Repositories;

public interface IEmployeesRepository
{
     Task<Employee?> GetEmployeeByEmail(string email);
     Task<Employee> CreateEmployee(Employee employee);
}