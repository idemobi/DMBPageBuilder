#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj IWebAssetRegistry.cs create at 2026/05/14 23:05:59
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBPageBuilder;

/// <summary>
///     Provides a registry for global web assets that should be injected into every page.
/// </summary>
/// <remarks>
///     Registered entries are copied into <see cref="PageInformation" /> by PageBuilder-aware MVC infrastructure before
///     the page renders. Keys are used for deduplication so later registrations can replace earlier entries.
/// </remarks>
public interface IWebAssetRegistry
{
    #region Instance methods

    /// <summary>
    ///     Registers or replaces a global script asset by key.
    /// </summary>
    /// <param name="key">A unique key for deduplication.</param>
    /// <param name="url">The script URL.</param>
    /// <param name="location">The script location in the document.</param>
    /// <param name="loadingMode">The script loading mode.</param>
    /// <param name="order">The script order.</param>
    /// <param name="crossOrigin">The crossorigin policy.</param>
    /// <param name="integrity">The optional integrity hash.</param>
    /// <exception cref="ArgumentException">Thrown when <paramref name="key" /> or <paramref name="url" /> is empty.</exception>
    void RegisterScript(
        string key,
        string url,
        PageScriptLocation location = PageScriptLocation.Head,
        PageScriptLoadingMode loadingMode = PageScriptLoadingMode.Defer,
        int order = 0,
        PageCrossOrigin crossOrigin = PageCrossOrigin.None,
        string? integrity = null
    );

    /// <summary>
    ///     Registers or replaces a global stylesheet asset by key.
    /// </summary>
    /// <param name="key">A unique key for deduplication.</param>
    /// <param name="href">The stylesheet URL.</param>
    /// <param name="order">The stylesheet order.</param>
    /// <param name="crossOrigin">The crossorigin policy.</param>
    /// <param name="integrity">The optional integrity hash.</param>
    /// <exception cref="ArgumentException">Thrown when <paramref name="key" /> or <paramref name="href" /> is empty.</exception>
    void RegisterStylesheet(string key, string href, int order = 0, PageCrossOrigin crossOrigin = PageCrossOrigin.None, string? integrity = null);

    /// <summary>
    ///     Returns a snapshot of registered global assets.
    /// </summary>
    /// <returns>The immutable list of current entries.</returns>
    IReadOnlyCollection<WebAssetRegistryEntry> Snapshot();

    #endregion
}