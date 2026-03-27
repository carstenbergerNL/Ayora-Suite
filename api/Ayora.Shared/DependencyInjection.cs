using Ayora.Shared.Abstractions.Time;
using Ayora.Shared.Infrastructure.Time;
using Microsoft.Extensions.DependencyInjection;

namespace Ayora.Shared;

public static class DependencyInjection
{
    public static IServiceCollection AddShared(this IServiceCollection services)
    {
        services.AddSingleton<ISystemClock, SystemClock>();
        return services;
    }
}

