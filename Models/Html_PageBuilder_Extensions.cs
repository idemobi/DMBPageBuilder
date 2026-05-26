#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj Html_PageBuilder_Extensions.cs create at 2026/05/05 15:05:00
// ©2024-2026 idéMobi SARL FRANCE

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