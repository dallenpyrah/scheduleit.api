namespace ScheduleIt.Business.Utils;

public static class DateTimeUtil
{
    public static DateTime ConvertToUtc(DateTime? date)
    {
        return date == null ? DateTime.UtcNow : DateTime.SpecifyKind(date.Value, DateTimeKind.Utc);
    }
}