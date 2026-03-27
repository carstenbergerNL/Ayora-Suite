# Ayora Modules

Place future plug-and-play modules here.

Recommended conventions:

- One module = one project under `api/Modules/<ModuleName>/<ModuleName>.csproj`
- Namespace/prefix: `Ayora.Modules.<ModuleName>`
- Each module must provide an `IModule` implementation (see `Ayora.Shared.Modularity.IModule`)

