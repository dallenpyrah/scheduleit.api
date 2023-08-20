using ScheduleIt.Business.Extensions;
using ScheduleIt.Contracts.Role;
using ScheduleIt.Data.Models;
using ScheduleIt.Interfaces.Repositories;

namespace ScheduleIt.Business.Managers;

public class RolesManager
{
    private readonly IRolesRepository _rolesRepository;

    public RolesManager(IRolesRepository rolesRepository)
    {
        _rolesRepository = rolesRepository;
    }

    public async Task<List<Company?>> GetRoles()
    {
        throw new NotImplementedException();
    }

    public async Task<Role?> GetRoleById(int id)
    {
        return await _rolesRepository.GetRoleById(id);
    }

    public async Task<Role> CreateRole(CreateRoleRequest createRoleRequest)
    {
        createRoleRequest.Validate();
        
        Role? role = await _rolesRepository.GetRoleByName(createRoleRequest.Name);
        if (role != null)
            throw new ArgumentException($"Role with name {createRoleRequest.Name} already exists");

        Role newRole = new()
        {
            Name = createRoleRequest.Name,
            Description = createRoleRequest.Description
        };
        
        return await _rolesRepository.CreateRole(newRole);
    }

    public async Task<Role> UpdateRole(Role updateRole)
    {
        throw new NotImplementedException();
    }

    public async Task<Role> DeleteRole(int id)
    {
        throw new NotImplementedException();
    }
}