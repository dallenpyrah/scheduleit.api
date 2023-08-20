namespace ScheduleIt.Business.Exceptions;

public class InvalidCompanyIdException : Exception
{
    public InvalidCompanyIdException(string message) : base(message)
    {
    }
}