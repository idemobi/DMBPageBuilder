#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using DMBServerWebHelper;
using Microsoft.AspNetCore.Mvc.Filters;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Provides a PageBuilder-aware MVC controller base class.
    /// </summary>
    /// <remarks>
    ///     The controller initializes a request-scoped <see cref="PageInformation" /> instance, applies common metadata,
    ///     imports globally registered assets, and publishes the page model through <see cref="PageRegistry" /> before
    ///     the action result is rendered.
    /// </remarks>
    public abstract class RawPageController : RawWebController
    {
        #region Instance fields and properties

        /// <summary>
        ///     Stores the page information configured by the controller before the view renders.
        /// </summary>
        protected readonly PageInformation Page = new PageInformation();

        #endregion

        #region Instance methods

        /// <summary>
        ///     Adds or replaces a link definition on the current page.
        /// </summary>
        /// <param name="link">The link definition to add.</param>
        /// <returns>The current controller instance for chaining.</returns>
        protected RawPageController AddLink(PageLinkDefinition link)
        {
            Page.AddLink(link);
            return this;
        }


        /// <summary>
        ///     Adds a metadata definition to the current page.
        /// </summary>
        /// <param name="meta">The metadata definition to add.</param>
        /// <returns>The current controller instance for chaining.</returns>
        protected RawPageController AddMeta(PageMetaDefinition meta)
        {
            Page.AddMeta(meta);
            return this;
        }

        private void ApplyGlobalAssetsFromRegistry()
        {
            IWebAssetRegistry? registry = HttpContext.RequestServices.GetService(typeof(IWebAssetRegistry)) as IWebAssetRegistry;
            if (registry is null)
            {
                return;
            }

            foreach (WebAssetRegistryEntry entry in registry.Snapshot())
            {
                if (entry.IsLink && entry.Link != null)
                {
                    Page.AddLink(WebAssetRegistry.CopyLink(entry.Link));
                }

                if (entry.IsScript && !string.IsNullOrWhiteSpace(entry.ScriptUrl))
                {
                    Page.SetScriptFile(entry.ScriptUrl, entry.ScriptLocation, entry.ScriptLoadingMode, entry.Order, entry.CrossOrigin, entry.Integrity);
                }

                if (entry.IsStylesheet && !string.IsNullOrWhiteSpace(entry.StylesheetUrl))
                {
                    Page.SetStylesheet(entry.StylesheetUrl, entry.Order, entry.CrossOrigin, entry.Integrity);
                }
            }
        }

        /// <summary>
        ///     Initializes default PageBuilder metadata and publishes the request-scoped page model.
        /// </summary>
        /// <param name="context">The action execution context.</param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            Page.Title = "Default title";
            Page.SetCharset(PageCharset.Utf8);
            Page.SetFavicon(PageFaviconSet.Full);
            Page.SetStylesheet("/css/site.css", 999);
            Page.SetScriptFile("/js/script.js", PageScriptLocation.Head, PageScriptLoadingMode.Defer, 999);
            Page.SetScriptFile("/js/script_at_end.js", PageScriptLocation.EndOfBody, PageScriptLoadingMode.Defer, 999);
            Page.SetRevisitAfterDays(7);
            ApplyGlobalAssetsFromRegistry();
            PageRegistry.SetPageInformation(HttpContext, Page);
        }

        /// <summary>
        ///     Sets the charset metadata for the current page.
        /// </summary>
        /// <param name="charset">The charset value to render.</param>
        /// <returns>The current controller instance for chaining.</returns>
        protected RawPageController SetCharset(PageCharset charset)
        {
            Page.SetCharset(charset);
            return this;
        }

        /// <summary>
        ///     Sets the description metadata for the current page.
        /// </summary>
        /// <param name="description">The page description.</param>
        /// <returns>The current controller instance for chaining.</returns>
        protected RawPageController SetDescription(string description)
        {
            Page.SetDescription(description);
            return this;
        }

        /// <summary>
        ///     Configures the favicon set for the current page.
        /// </summary>
        /// <param name="set">The favicon set to render.</param>
        /// <param name="basePath">The path containing favicon files.</param>
        /// <param name="baseName">The base filename used for favicon files.</param>
        /// <returns>The current controller instance for chaining.</returns>
        protected RawPageController SetFavicon(PageFaviconSet set, string basePath = "/favicons/", string baseName = "favicon")
        {
            Page.SetFavicon(set, basePath, baseName);
            return this;
        }

        /// <summary>
        ///     Sets the keywords metadata for the current page.
        /// </summary>
        /// <param name="keywords">The keyword values. Empty values are ignored.</param>
        /// <returns>The current controller instance for chaining.</returns>
        public RawPageController SetKeywords(params string[] keywords)
        {
            Page.SetKeywords(keywords);
            return this;
        }

        /// <summary>
        ///     Adds or replaces an external script file for the current page.
        /// </summary>
        /// <param name="url">The script URL.</param>
        /// <param name="location">The document location where the script is rendered.</param>
        /// <param name="loadingMode">The browser loading mode.</param>
        /// <param name="integrity">The optional subresource integrity hash.</param>
        /// <returns>The current controller instance for chaining.</returns>
        protected RawPageController SetScriptFile(
            string url,
            PageScriptLocation location = PageScriptLocation.EndOfBody,
            PageScriptLoadingMode loadingMode = PageScriptLoadingMode.Defer,
            string? integrity = null
        )
        {
            Page.SetScriptFile(url, location, loadingMode, integrity: integrity);
            return this;
        }

        /// <summary>
        ///     Adds or replaces a stylesheet link for the current page.
        /// </summary>
        /// <param name="href">The stylesheet URL.</param>
        /// <param name="integrity">The optional subresource integrity hash.</param>
        /// <returns>The current controller instance for chaining.</returns>
        protected RawPageController SetStylesheet(string href, string? integrity = null)
        {
            Page.SetStylesheet(href, integrity: integrity);
            return this;
        }

        /// <summary>
        ///     Sets the document title for the current page.
        /// </summary>
        /// <param name="title">The document title.</param>
        /// <returns>The current controller instance for chaining.</returns>
        protected RawPageController SetTitle(string title)
        {
            Page.SetTitle(title);
            return this;
        }

        #endregion
    }
}
