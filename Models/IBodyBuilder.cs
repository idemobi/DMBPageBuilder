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
    ///     Defines the document body layout contract used by <see cref="PageBuilder" /> when it opens and closes the
    ///     page body, header, main content, and footer regions.
    /// </summary>
    /// <remarks>
    ///     Implementations write directly to the provided <see cref="TextWriter" />. They are responsible for producing
    ///     balanced markup because <see cref="PageBuilder" /> calls the start methods before Razor body content and the
    ///     matching end methods after the body content.
    /// </remarks>
    public interface IBodyBuilder
    {
        #region Instance methods

        /// <summary>
        ///     Writes the closing markup for the HTML <c>body</c> region.
        /// </summary>
        /// <param name="writer">The writer receiving the rendered markup.</param>
        /// <param name="html">The current Razor HTML helper.</param>
        /// <param name="page">The page information being rendered.</param>
        public void RenderBodyEnd(TextWriter writer, IHtmlHelper html, PageInformation page);

        /// <summary>
        ///     Writes the opening markup for the HTML <c>body</c> region.
        /// </summary>
        /// <param name="writer">The writer receiving the rendered markup.</param>
        /// <param name="html">The current Razor HTML helper.</param>
        /// <param name="page">The page information being rendered.</param>
        public void RenderBodyStart(TextWriter writer, IHtmlHelper html, PageInformation page);

        /// <summary>
        ///     Writes the closing markup for the footer region.
        /// </summary>
        /// <param name="writer">The writer receiving the rendered markup.</param>
        /// <param name="html">The current Razor HTML helper.</param>
        /// <param name="page">The page information being rendered.</param>
        public void RenderFooterEnd(TextWriter writer, IHtmlHelper html, PageInformation page);

        /// <summary>
        ///     Writes the opening markup for the footer region.
        /// </summary>
        /// <param name="writer">The writer receiving the rendered markup.</param>
        /// <param name="html">The current Razor HTML helper.</param>
        /// <param name="page">The page information being rendered.</param>
        public void RenderFooterStart(TextWriter writer, IHtmlHelper html, PageInformation page);

        /// <summary>
        ///     Writes the closing markup for the header region.
        /// </summary>
        /// <param name="writer">The writer receiving the rendered markup.</param>
        /// <param name="html">The current Razor HTML helper.</param>
        /// <param name="page">The page information being rendered.</param>
        public void RenderHeaderEnd(TextWriter writer, IHtmlHelper html, PageInformation page);

        /// <summary>
        ///     Writes the opening markup for the header region.
        /// </summary>
        /// <param name="writer">The writer receiving the rendered markup.</param>
        /// <param name="html">The current Razor HTML helper.</param>
        /// <param name="page">The page information being rendered.</param>
        public void RenderHeaderStart(TextWriter writer, IHtmlHelper html, PageInformation page);

        /// <summary>
        ///     Writes the closing markup for the main content region.
        /// </summary>
        /// <param name="writer">The writer receiving the rendered markup.</param>
        /// <param name="html">The current Razor HTML helper.</param>
        /// <param name="page">The page information being rendered.</param>
        public void RenderMainEnd(TextWriter writer, IHtmlHelper html, PageInformation page);

        /// <summary>
        ///     Writes the opening markup for the main content region.
        /// </summary>
        /// <param name="writer">The writer receiving the rendered markup.</param>
        /// <param name="html">The current Razor HTML helper.</param>
        /// <param name="page">The page information being rendered.</param>
        public void RenderMainStart(TextWriter writer, IHtmlHelper html, PageInformation page);

        #endregion
    }
}