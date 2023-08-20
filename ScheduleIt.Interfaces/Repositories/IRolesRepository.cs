using ScheduleIt.Data.Models;

namespace ScheduleIt.Interfaces.Repositories;

public interface IRolesRepository
{
    Task<Role?> GetRoleById(int id);
    Task<Role?> GetRoleByName(string name);
    Task<Role> CreateRole(Role newRole);
}