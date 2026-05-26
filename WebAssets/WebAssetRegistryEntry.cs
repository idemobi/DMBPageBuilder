#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj WebAssetRegistryEntry.cs create at 2026/05/14 23:05:58
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBPageBuilder;

/// <summary>
///     Represents one global web asset entry registered at application level.
/// </summary>
public sealed class WebAssetRegistryEntry
{
    #region Instance fields and properties

    /// <summary>
    ///     Gets or sets the crossorigin policy.
    /// </summary>
    public PageCrossOrigin CrossOrigin { get; set; } = PageCrossOrigin.None;

    /// <summary>
    ///     Gets or sets the optional subresource integrity hash.
    /// </summary>
    public string? Integrity { get; set; }

    /// <summary>
    ///     Gets whether this entry is a script entry.
    /// </summary>
    public bool IsScript => !string.IsNullOrWhiteSpace(ScriptUrl);

    /// <summary>
    ///     Gets whether this entry is a stylesheet entry.
    /// </summary>
    public bool IsStylesheet => !string.IsNullOrWhiteSpace(StylesheetUrl);

    /// <summary>
    ///     Gets or sets a unique key used for deduplication.
    /// </summary>
    public required string Key { get; set; }

    /// <summary>
    ///     Gets or sets the asset order.
    /// </summary>
    public int Order { get; set; }

    /// <summary>
    ///     Gets or sets the script loading mode.
    /// </summary>
    public PageScriptLoadingMode ScriptLoadingMode { get; set; } = PageScriptLoadingMode.Defer;

    /// <summary>
    ///     Gets or sets the script location.
    /// </summary>
    public PageScriptLocation ScriptLocation { get; set; } = PageScriptLocation.Head;

    /// <summary>
    ///     Gets or sets the script URL when the entry represents a script asset.
    /// </summary>
    public string? ScriptUrl { get; set; }

    /// <summary>
    ///     Gets or sets the stylesheet URL when the entry represents a stylesheet asset.
    /// </summary>
    public string? StylesheetUrl { get; set; }

    #endregion
}