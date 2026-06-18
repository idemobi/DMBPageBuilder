#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBPageBuilder;

/// <summary>
///     Provides optional global registration for page-level <c>link</c> assets.
/// </summary>
/// <remarks>
///     This interface extends the global asset registry without changing the original <see cref="IWebAssetRegistry" />
///     contract for existing external implementations.
/// </remarks>
public interface IWebLinkAssetRegistry : IWebAssetRegistry
{
    #region Instance methods

    /// <summary>
    ///     Registers or replaces a global link asset by key.
    /// </summary>
    /// <param name="key">A unique key for deduplication.</param>
    /// <param name="link">The link definition to copy into the registry.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="link" /> is <see langword="null" />.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="key" /> or <see cref="PageLinkDefinition.Href" /> is empty or unsafe.</exception>
    void RegisterLink(string key, PageLinkDefinition link);

    #endregion
}
