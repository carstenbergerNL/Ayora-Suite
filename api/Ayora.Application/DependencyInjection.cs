using Ayora.Application.Auth.Interfaces;
using Ayora.Application.Auth.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Ayora.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        return services;
    }
}

