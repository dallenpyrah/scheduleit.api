namespace ScheduleIt.Data.Models;

public class ShiftType
{
    public int Id { get; set; }
    public string Name { get; set; } // e.g., Morning, Afternoon, Evening
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public ICollection<Shift> Shifts { get; set; }
}
