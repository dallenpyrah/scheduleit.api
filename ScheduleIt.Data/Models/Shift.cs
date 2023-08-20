namespace ScheduleIt.Data.Models;

public class Shift
{
    public int Id { get; set; }
    public int ShiftTypeId { get; set; }
    public ShiftType ShiftType { get; set; }
    public int ScheduleId { get; set; }
    public Schedule Schedule { get; set; }
    public DateTime Date { get; set; } // The date of the shift within the weekly schedule
    public ICollection<EmployeeShift> EmployeeShifts { get; set; } // Many employees can fill the same shift type on the same day
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
