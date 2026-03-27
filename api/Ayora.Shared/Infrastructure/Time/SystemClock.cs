using Ayora.Shared.Abstractions.Time;

namespace Ayora.Shared.Infrastructure.Time;

public sealed class SystemClock : ISystemClock
{
    public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
}

