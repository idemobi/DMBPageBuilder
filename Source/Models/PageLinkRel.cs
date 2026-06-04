#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Defines known relationship values for page-level <c>link</c> tags.
    /// </summary>
    public enum PageLinkRel
    {
        /// <summary>
        ///     Renders a stylesheet resource link.
        /// </summary>
        Stylesheet,

        /// <summary>
        ///     Renders a generic icon resource link.
        /// </summary>
        Icon,

        /// <summary>
        ///     Renders an Apple touch icon resource link.
        /// </summary>
        AppleTouchIcon,

        /// <summary>
        ///     Renders a canonical URL link.
        /// </summary>
        Canonical,

        /// <summary>
        ///     Renders a web app manifest link.
        /// </summary>
        Manifest,

        /// <summary>
        ///     Renders a preload resource link.
        /// </summary>
        Preload,

        /// <summary>
        ///     Renders a prefetch resource link.
        /// </summary>
        Prefetch
    }
}