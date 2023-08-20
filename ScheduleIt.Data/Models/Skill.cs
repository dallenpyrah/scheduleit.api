namespace ScheduleIt.Data.Models;

public class Skill
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<EmployeeSkillMapping> EmployeeSkills { get; set; }
    public ICollection<RoleSkillMapping> RoleSkills { get; set; }
}
