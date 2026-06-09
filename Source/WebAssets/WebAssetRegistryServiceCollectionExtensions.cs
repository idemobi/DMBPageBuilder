#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using Microsoft.Extensions.DependencyInjection;

#endregion

namespace DMBPageBuilder;

/// <summary>
///     Provides service registration helpers for <see cref="IWebAssetRegistry" />.
/// </summary>
public static class WebAssetRegistryServiceCollectionExtensions
{
    #region Static methods

    /// <summary>
    ///     Adds the global web asset registry service.
    /// </summary>
    /// <param name="services">The service collection to configure.</param>
    /// <returns>The same <see cref="IServiceCollection" /> instance for chaining.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="services" /> is <see langword="null" />.</exception>
    public static IServiceCollection AddWebAssetRegistry(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);
        _ = GetOrCreateRegistry(services);
        return services;
    }

    private static WebAssetRegistry GetOrCreateRegistry(IServiceCollection services)
    {
        ServiceDescriptor? existing = services.FirstOrDefault(descriptor => descriptor.ServiceType == typeof(IWebAssetRegistry) && descriptor.ImplementationInstance is WebAssetRegistry
        );

        if (existing?.ImplementationInstance is WebAssetRegistry existingRegistry)
        {
            return existingRegistry;
        }

        var registry = new WebAssetRegistry();
        services.AddSingleton<IWebAssetRegistry>(registry);
        return registry;
    }

    /// <summary>
    ///     Registers one global script asset in <see cref="IWebAssetRegistry" />.
    /// </summary>
    /// <param name="services">The service collection to configure.</param>
    /// <param name="key">A unique key for deduplication.</param>
    /// <param name="url">The script URL.</param>
    /// <param name="location">The script location in the document.</param>
    /// <param name="loadingMode">The script loading mode.</param>
    /// <param name="order">The script order.</param>
    /// <param name="crossOrigin">The crossorigin policy.</param>
    /// <param name="integrity">The optional integrity hash.</param>
    /// <returns>The same <see cref="IServiceCollection" /> instance for chaining.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="services" /> is <see langword="null" />.</exception>
    public static IServiceCollection RegisterGlobalScriptAsset(
        this IServiceCollection services,
        string key,
        string url,
        PageScriptLocation location = PageScriptLocation.Head,
        PageScriptLoadingMode loadingMode = PageScriptLoadingMode.Defer,
        int order = 0,
        PageCrossOrigin crossOrigin = PageCrossOrigin.None,
        string? integrity = null
    )
    {
        ArgumentNullException.ThrowIfNull(services);
        WebAssetRegistry registry = GetOrCreateRegistry(services);
        registry.RegisterScript(key, url, location, loadingMode, order, crossOrigin, integrity);
        return services;
    }

    /// <summary>
    ///     Registers one global stylesheet asset in <see cref="IWebAssetRegistry" />.
    /// </summary>
    /// <param name="services">The service collection to configure.</param>
    /// <param name="key">A unique key for deduplication.</param>
    /// <param name="href">The stylesheet URL.</param>
    /// <param name="order">The stylesheet order.</param>
    /// <param name="crossOrigin">The crossorigin policy.</param>
    /// <param name="integrity">The optional integrity hash.</param>
    /// <returns>The same <see cref="IServiceCollection" /> instance for chaining.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="services" /> is <see langword="null" />.</exception>
    public static IServiceCollection RegisterGlobalStylesheetAsset(
        this IServiceCollection services,
        string key,
        string href,
        int order = 0,
        PageCrossOrigin crossOrigin = PageCrossOrigin.None,
        string? integrity = null
    )
    {
        ArgumentNullException.ThrowIfNull(services);
        WebAssetRegistry registry = GetOrCreateRegistry(services);
        registry.RegisterStylesheet(key, href, order, crossOrigin, integrity);
        return services;
    }

    #endregion
}