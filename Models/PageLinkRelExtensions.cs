#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Provides conversion helpers for link relationship values.
    /// </summary>
    public static class PageLinkRelExtensions
    {
        #region Static methods

        /// <summary>
        ///     Gets the HTML rel attribute value for a link relationship.
        /// </summary>
        /// <param name="rel">The link relationship value.</param>
        /// <returns>The HTML rel attribute value.</returns>
        public static string GetValue(this PageLinkRel rel)
        {
            return rel switch
            {
                PageLinkRel.Stylesheet => "stylesheet",
                PageLinkRel.Icon => "icon",
                PageLinkRel.AppleTouchIcon => "apple-touch-icon",
                PageLinkRel.Canonical => "canonical",
                PageLinkRel.Manifest => "manifest",
                PageLinkRel.Preload => "preload",
                PageLinkRel.Prefetch => "prefetch",
                _ => string.Empty
            };
        }

        #endregion
    }
}