namespace ScheduleIt.Data.Models;

public class Employee
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Position { get; set; }
    public DateTime HireDate { get; set; }
    public decimal? Salary { get; set; }
    public bool PartTime { get; set; }
    public string Department { get; set; }
    public string Address { get; set; }
    public string EmergencyContactName { get; set; }
    public string EmergencyContactPhone { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int? RoleId { get; set; }
    public Role Role { get; set; }
    public ICollection<EmployeeSkillMapping> Skills { get; set; }
    public Company Company { get; set; }
    public int? CompanyId { get; set; }
    public ICollection<EmployeeShift> EmployeeShifts { get; set; }
}
