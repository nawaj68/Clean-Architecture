using TaskManagement.Shared.Common.Interfaces;

namespace TaskManagement.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTimeOffset Now => DateTimeOffset.Now;
}
