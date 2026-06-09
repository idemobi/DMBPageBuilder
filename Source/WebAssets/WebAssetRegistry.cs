#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System.Collections.Concurrent;

#endregion

namespace DMBPageBuilder;

/// <summary>
///     Stores application-level web assets that are automatically injected into page rendering.
/// </summary>
/// <remarks>
///     The registry is intended for assets that should be available to every PageBuilder page, such as shared scripts
///     and stylesheets registered during application startup.
/// </remarks>
public sealed class WebAssetRegistry : IWebAssetRegistry
{
    #region Instance fields and properties

    private readonly ConcurrentDictionary<string, WebAssetRegistryEntry> _entries = new(StringComparer.OrdinalIgnoreCase);

    #endregion

    #region Instance methods

    #region From interface IWebAssetRegistry

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
    public void RegisterScript(
        string key,
        string url,
        PageScriptLocation location = PageScriptLocation.Head,
        PageScriptLoadingMode loadingMode = PageScriptLoadingMode.Defer,
        int order = 0,
        PageCrossOrigin crossOrigin = PageCrossOrigin.None,
        string? integrity = null
    )
    {
        if (string.IsNullOrWhiteSpace(key))
        {
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));
        }

        if (string.IsNullOrWhiteSpace(url))
        {
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(url));
        }

        _entries[key] = new WebAssetRegistryEntry
        {
            Key = key,
            ScriptUrl = url,
            ScriptLocation = location,
            ScriptLoadingMode = loadingMode,
            Order = order,
            CrossOrigin = crossOrigin,
            Integrity = integrity
        };
    }

    /// <summary>
    ///     Registers or replaces a global stylesheet asset by key.
    /// </summary>
    /// <param name="key">A unique key for deduplication.</param>
    /// <param name="href">The stylesheet URL.</param>
    /// <param name="order">The stylesheet order.</param>
    /// <param name="crossOrigin">The crossorigin policy.</param>
    /// <param name="integrity">The optional integrity hash.</param>
    /// <exception cref="ArgumentException">Thrown when <paramref name="key" /> or <paramref name="href" /> is empty.</exception>
    public void RegisterStylesheet(string key, string href, int order = 0, PageCrossOrigin crossOrigin = PageCrossOrigin.None, string? integrity = null)
    {
        if (string.IsNullOrWhiteSpace(key))
        {
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));
        }

        if (string.IsNullOrWhiteSpace(href))
        {
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(href));
        }

        _entries[key] = new WebAssetRegistryEntry
        {
            Key = key,
            StylesheetUrl = href,
            Order = order,
            CrossOrigin = crossOrigin,
            Integrity = integrity
        };
    }

    /// <summary>
    ///     Returns a snapshot of registered global assets.
    /// </summary>
    /// <returns>The immutable list of current entries.</returns>
    public IReadOnlyCollection<WebAssetRegistryEntry> Snapshot()
    {
        return _entries.Values.OrderBy(x => x.Order).ThenBy(x => x.Key, StringComparer.OrdinalIgnoreCase).ToArray();
    }

    #endregion

    #endregion
}