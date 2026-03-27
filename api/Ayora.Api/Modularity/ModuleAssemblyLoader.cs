using System.Reflection;

namespace Ayora.Api.Modularity;

public static class ModuleAssemblyLoader
{
    public static IReadOnlyList<Assembly> LoadFromModulesFolder(string contentRootPath)
    {
        var modulesRoot = Path.Combine(contentRootPath, "..", "Modules");
        if (!Directory.Exists(modulesRoot))
        {
            return Array.Empty<Assembly>();
        }

        var dlls = Directory.EnumerateFiles(modulesRoot, "Ayora.Modules.*.dll", SearchOption.AllDirectories)
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToArray();

        if (dlls.Length == 0)
        {
            return Array.Empty<Assembly>();
        }

        var loaded = new List<Assembly>(dlls.Length);
        foreach (var path in dlls)
        {
            try
            {
                loaded.Add(Assembly.LoadFrom(path));
            }
            catch
            {
                // ignore modules that can't be loaded
            }
        }

        return loaded;
    }
}

