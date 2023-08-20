using Microsoft.EntityFrameworkCore;
using ScheduleIt.Data;
using ScheduleIt.Data.Models;
using ScheduleIt.Interfaces.Repositories;

namespace ScheduleIt.DataAccess.Repositories;

public class RolesRepository : IRolesRepository
{
    private readonly ScheduleItContext _context;

    public RolesRepository(ScheduleItContext context)
    {
        _context = context;
    }

    public async Task<Role?> GetRoleById(int id)
    {
        return await _context.Roles.FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<Role?> GetRoleByName(string name)
    {
        return await _context.Roles.FirstOrDefaultAsync(r => r.Name == name);
    }

    public async Task<Role> CreateRole(Role newRole)
    {
        await _context.Roles.AddAsync(newRole);
        await _context.SaveChangesAsync();
        return newRole;
    }
}