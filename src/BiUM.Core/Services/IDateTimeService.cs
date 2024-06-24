namespace BiUM.Core.Services;

public interface IDateTimeService
{
    DateTime Now { get; }
    DateOnly Today { get; }
    TimeOnly TimeNow { get; }
}