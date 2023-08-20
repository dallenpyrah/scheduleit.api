using System.ComponentModel.DataAnnotations;

namespace ScheduleIt.Contracts.Employee;

public class RegisterEmployeeRequest
{
    [Required]
    [MinLength(5)]
    [MaxLength(20)]
    public string Username { get; set; } 
    
    [Required]
    [MinLength(5)]
    [MaxLength(20)]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    
    [Required]
    public string FirstName { get; set; } 
    
    [Required]
    public string LastName { get; set; } 
    
    [Required]
    [EmailAddress]
    public string Email { get; set; } 
    
    [Required]
    [Phone]
    public string Phone { get; set; }
    
    [Required]
    public string Position { get; set; }
    public DateTime? HireDate { get; set; }
    public decimal? Salary { get; set; } 
    public bool? PartTime { get; set; } 
    
    [Required]
    public string Department { get; set; }
    
    [Required]
    public string Address { get; set; }
    
    [Required]
    public string EmergencyContactName { get; set; }
    
    [Required]
    public string EmergencyContactPhone { get; set; }
    public int? RoleId { get; set; } 
    
    [Required]
    public int CompanyId { get; set; }
}