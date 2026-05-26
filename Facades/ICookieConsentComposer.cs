#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj ICookieConsentComposer.cs create at 2026/05/05 15:05:00
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBServerHelper;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Defines the contract for rendering cookie consent markup in a PageBuilder page.
    /// </summary>
    public interface ICookieConsentComposer
    {
        #region Instance methods

        /// <summary>
        ///     Renders the cookie consent output.
        /// </summary>
        /// <param name="htmlHelper">The Razor HTML helper used to render the consent markup.</param>
        /// <param name="page">The page information associated with the current request.</param>
        /// <param name="cookieConsent">The cookie definition that describes the consent policy.</param>
        /// <param name="context">The current HTTP context.</param>
        /// <returns>The rendered cookie consent content.</returns>
        public IHtmlContent RenderCookieConsent(IHtmlHelper htmlHelper, PageInformation page, CookieDefinition cookieConsent, HttpContext context);

        #endregion
    }
}