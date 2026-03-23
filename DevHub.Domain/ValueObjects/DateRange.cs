using ErrorOr;

namespace DevHub.Domain.ValueObjects;

public record DateRange
{
    public DateTime Start { get; }
    public DateTime End { get; }

    private DateRange(DateTime start, DateTime end)
    {
        Start = start;
        End = end;
    }

    public static ErrorOr<DateRange> Create(DateTime start, DateTime end)
    {
        if (end < start)
            return Error.Validation("DateRange.Invalid", "End date cannot be before start date.");

        return new DateRange(start, end);
    }

    public TimeSpan Duration => End - Start;
}