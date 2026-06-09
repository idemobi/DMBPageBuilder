#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using DMBBootstrapBuilder;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace DMBPageBuilderLabs.Controllers
{
    /// <summary>
    ///     Provides documentation pages for PageBuilder.
    /// </summary>
    public class PageBuilderController : RawBootstrapController
    {
        #region Instance methods

        /// <summary>
        ///     Renders the PageBuilder architecture page.
        /// </summary>
        /// <returns>The architecture view.</returns>
        public IActionResult Architecture()
        {
            SetTitle("PageBuilder - Architecture");
            SetDescription("PageBuilder");
            SetKeywords("PageBuilder", "Architecture");
            return View();
        }

        /// <summary>
        ///     Renders the HTML attributes documentation page.
        /// </summary>
        /// <returns>The attributes view.</returns>
        public IActionResult Attributes()
        {
            SetTitle("PageBuilder - Attributes");
            SetDescription("PageBuilder");
            SetKeywords("PageBuilder", "Attributes");
            return View();
        }

        /// <summary>
        ///     Renders the body builder documentation page.
        /// </summary>
        /// <returns>The body builder view.</returns>
        public IActionResult BodyBuilder()
        {
            SetTitle("PageBuilder - Body builder");
            SetDescription("PageBuilder");
            SetKeywords("PageBuilder", "Body", "Builder");
            return View();
        }

        /// <summary>
        ///     Renders the builder lifecycle documentation page.
        /// </summary>
        /// <returns>The builder lifecycle view.</returns>
        public IActionResult BuilderLifecycle()
        {
            SetTitle("PageBuilder - Builder lifecycle");
            SetDescription("PageBuilder");
            SetKeywords("PageBuilder", "Builder", "Lifecycle");
            return View();
        }

        /// <summary>
        ///     Renders the PageBuilder C# usage page.
        /// </summary>
        /// <returns>The CSharp view.</returns>
        public IActionResult CSharp()
        {
            SetTitle("PageBuilder - CSharp");
            SetDescription("PageBuilder");
            SetKeywords("PageBuilder", "CSharp");
            return View();
        }

        /// <summary>
        ///     Renders the PageBuilder Razor/CSHTML usage page.
        /// </summary>
        /// <returns>The CSHtml view.</returns>
        public IActionResult CSHtml()
        {
            SetTitle("PageBuilder - CSHtml");
            SetDescription("PageBuilder");
            SetKeywords("PageBuilder", "CSHtml");
            return View();
        }

        /// <summary>
        ///     Renders the CSS system documentation page.
        /// </summary>
        /// <returns>The CSS system view.</returns>
        public IActionResult CSSSystem()
        {
            SetTitle("PageBuilder - CSSSystem");
            SetDescription("PageBuilder");
            SetKeywords("PageBuilder", "CSSSystem");
            return View();
        }

        /// <summary>
        ///     Renders the diagnostics documentation page.
        /// </summary>
        /// <returns>The diagnostics view.</returns>
        public IActionResult Diagnostics()
        {
            SetTitle("PageBuilder - Diagnostics");
            SetDescription("PageBuilder");
            SetKeywords("PageBuilder", "Diagnostics");
            return View();
        }

        /// <summary>
        ///     Renders the PageBuilder examples page.
        /// </summary>
        /// <returns>The examples view.</returns>
        public IActionResult Examples()
        {
            SetTitle("PageBuilder - Examples");
            SetDescription("PageBuilder");
            SetKeywords("PageBuilder", "Examples");
            return View();
        }

        /// <summary>
        ///     Renders the extensibility documentation page.
        /// </summary>
        /// <returns>The extensibility view.</returns>
        public IActionResult Extensibility()
        {
            SetTitle("PageBuilder - Extensibility");
            SetDescription("PageBuilder");
            SetKeywords("PageBuilder", "Extensibility");
            return View();
        }

        /// <summary>
        ///     Renders the PageBuilder getting started page.
        /// </summary>
        /// <returns>The getting started view.</returns>
        public IActionResult GettingStarted()
        {
            SetTitle("PageBuilder - Getting started");
            SetDescription("PageBuilder");
            SetKeywords("PageBuilder", "Getting", "Started");
            return View();
        }

        /// <summary>
        ///     Renders the HtmlBuilderBase documentation page.
        /// </summary>
        /// <returns>The HtmlBuilderBase view.</returns>
        public IActionResult HtmlBuilderBase()
        {
            SetTitle("PageBuilder - HtmlBuilderBase");
            SetDescription("PageBuilder");
            SetKeywords("PageBuilder", "HtmlBuilderBase");
            return View();
        }

        /// <summary>
        ///     Renders the HTML components documentation page.
        /// </summary>
        /// <returns>The HTML components view.</returns>
        public IActionResult HtmlComponents()
        {
            SetTitle("PageBuilder - HtmlComponents");
            SetDescription("PageBuilder");
            SetKeywords("PageBuilder", "HtmlComponents");
            return View();
        }

        /// <summary>
        ///     Renders the PageBuilder introduction page.
        /// </summary>
        /// <returns>The introduction view.</returns>
        public IActionResult Introduction()
        {
            SetTitle("PageBuilder - Introduction");
            SetDescription("PageBuilder");
            SetKeywords("PageBuilder");
            return View();
        }

        /// <summary>
        ///     Renders the PageBuilder rendering pipeline page.
        /// </summary>
        /// <returns>The rendering pipeline view.</returns>
        public IActionResult RenderingPipeline()
        {
            SetTitle("PageBuilder - Rendering pipeline");
            SetDescription("PageBuilder");
            SetKeywords("PageBuilder", "Rendering", "Pipeline");
            return View();
        }

        /// <summary>
        ///     Renders the inline styles documentation page.
        /// </summary>
        /// <returns>The styles view.</returns>
        public IActionResult Styles()
        {
            SetTitle("PageBuilder - Styles");
            SetDescription("PageBuilder");
            SetKeywords("PageBuilder", "Styles");
            return View();
        }

        #endregion
    }
}