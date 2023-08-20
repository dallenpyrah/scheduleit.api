namespace ScheduleIt.Data.Models;

public class EmployeeSkillMapping
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public int SkillId { get; set; }
    public Employee Employee { get; set; }
    public Skill Skill { get; set; }
}
