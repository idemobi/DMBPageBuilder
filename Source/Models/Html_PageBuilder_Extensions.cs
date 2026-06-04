#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Provides Razor helper extensions for creating PageBuilder document renderers.
    /// </summary>
    public static class Html_PageBuilder_Extensions
    {
        #region Static methods

        /// <summary>
        ///     Creates a <see cref="PageBuilder" /> for the current Razor helper and page information.
        /// </summary>
        /// <param name="html">The current Razor HTML helper.</param>
        /// <param name="page">The page information to render.</param>
        /// <returns>A <see cref="PageBuilder" /> bound to the current helper and page model.</returns>
        public static PageBuilder PageBuilder(this IHtmlHelper html, PageInformation page)
        {
            return new PageBuilder(html, page);
        }

        #endregion
    }
}