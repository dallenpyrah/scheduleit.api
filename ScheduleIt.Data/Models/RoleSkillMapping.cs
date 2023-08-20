namespace ScheduleIt.Data.Models;

public class RoleSkillMapping
{
    public int Id { get; set; }
    public int RoleId { get; set; }
    public int SkillId { get; set; }
    public Role Role { get; set; }
    public Skill Skill { get; set; }
}
