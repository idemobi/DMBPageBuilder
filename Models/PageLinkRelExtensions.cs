#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj PageLinkRelExtensions.cs create at 2026/05/05 15:05:00
// ©2024-2026 idéMobi SARL FRANCE

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