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
    ///     Builds an HTML <c>canvas</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_CanvasBuilder : HtmlTagBuilder<PB_CanvasBuilder>
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_CanvasBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_CanvasBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "canvas";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_CanvasBuilder CreateInstance() => new(_textWriter, _htmlHelper);

        /// <summary>
        ///     Sets the HTML <c>height</c> attribute.
        /// </summary>
        /// <param name="height">The value to assign to the HTML <c>height</c> attribute.</param>
        /// <returns>The current <see cref="PB_CanvasBuilder" /> instance for chaining.</returns>
        public PB_CanvasBuilder SetHeight(int height) => SetAttribute("height", height);

        /// <summary>
        ///     Sets the HTML <c>width</c> attribute.
        /// </summary>
        /// <param name="width">The value to assign to the HTML <c>width</c> attribute.</param>
        /// <returns>The current <see cref="PB_CanvasBuilder" /> instance for chaining.</returns>
        public PB_CanvasBuilder SetWidth(int width) => SetAttribute("width", width);

        #endregion
    }
}