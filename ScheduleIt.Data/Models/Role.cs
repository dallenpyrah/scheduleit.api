namespace ScheduleIt.Data.Models;

public class Role
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<Employee> Employees { get; set; }
    public ICollection<RoleSkillMapping> RoleSkills { get; set; }
}
