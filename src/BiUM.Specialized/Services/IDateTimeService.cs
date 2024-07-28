namespace BiUM.Specialized.Services;

public interface IDateTimeService
{
    DateTime Now { get; }
    DateOnly Today { get; }
    TimeOnly TimeNow { get; }
}