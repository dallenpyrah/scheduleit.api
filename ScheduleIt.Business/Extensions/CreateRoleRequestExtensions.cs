using ScheduleIt.Contracts.Role;

namespace ScheduleIt.Business.Extensions;

public static class CreateRoleRequestExtensions
{
    public static void Validate(this CreateRoleRequest createRoleRequest)
    {
        if (string.IsNullOrWhiteSpace(createRoleRequest.Name))
            throw new ArgumentException("Name cannot be null or whitespace");
        
        if (string.IsNullOrWhiteSpace(createRoleRequest.Description))
            throw new ArgumentException("Description cannot be null or whitespace");
    }
}