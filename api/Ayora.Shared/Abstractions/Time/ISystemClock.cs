namespace Ayora.Shared.Abstractions.Time;

public interface ISystemClock
{
    DateTimeOffset UtcNow { get; }
}

