using System.Reflection;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Ayora.Shared.Modularity;

public static class ModuleLoader
{
    public static IServiceCollection RegisterModulesFrom(
        this IServiceCollection services,
        IEnumerable<Assembly> assemblies)
    {
        foreach (var module in DiscoverModules(assemblies))
        {
            module.RegisterServices(services);
            services.AddSingleton(module);
        }

        return services;
    }

    public static IEndpointRouteBuilder MapDiscoveredModules(this IEndpointRouteBuilder endpoints)
    {
        foreach (var module in endpoints.ServiceProvider.GetServices<IModule>())
        {
            module.MapEndpoints(endpoints);
        }

        return endpoints;
    }

    private static IEnumerable<IModule> DiscoverModules(IEnumerable<Assembly> assemblies)
    {
        foreach (var assembly in assemblies.Distinct())
        {
            Type[] types;
            try
            {
                types = assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException ex)
            {
                types = ex.Types.Where(t => t is not null).Cast<Type>().ToArray();
            }

            foreach (var type in types)
            {
                if (type is null)
                {
                    continue;
                }

                if (type.IsAbstract || type.IsInterface)
                {
                    continue;
                }

                if (!typeof(IModule).IsAssignableFrom(type))
                {
                    continue;
                }

                if (Activator.CreateInstance(type) is IModule module)
                {
                    yield return module;
                }
            }
        }
    }
}

