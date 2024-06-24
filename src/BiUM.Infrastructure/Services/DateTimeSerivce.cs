using BiUM.Core.Services;

namespace BiUM.Infrastructure.Services;

public class DateTimeService : IDateTimeService
{
    public DateTime Now => DateTime.Now;
    public DateOnly Today => DateOnly.FromDateTime(Now);
    public TimeOnly TimeNow => TimeOnly.FromDateTime(Now);
}