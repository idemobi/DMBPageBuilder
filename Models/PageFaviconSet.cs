#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj PageFaviconSet.cs create at 2026/05/05 15:05:00
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Defines the favicon link set rendered by <see cref="PageBuilder" />.
    /// </summary>
    public enum PageFaviconSet
    {
        /// <summary>
        ///     Does not render favicon link tags.
        /// </summary>
        None,

        /// <summary>
        ///     Renders the base icon and a 32x32 PNG icon.
        /// </summary>
        Minimal,

        /// <summary>
        ///     Renders the common browser and Apple touch icon set.
        /// </summary>
        Default,

        /// <summary>
        ///     Renders the extended browser, Apple touch, and Android icon set.
        /// </summary>
        Full
    }
}