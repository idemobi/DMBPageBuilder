#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

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