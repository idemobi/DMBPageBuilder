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
    ///     Builds an HTML <c>img</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_ImgBuilder : HtmlVoidTagBuilder<PB_ImgBuilder>
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_ImgBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_ImgBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "img";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_ImgBuilder CreateInstance()
        {
            return new PB_ImgBuilder(_textWriter, _htmlHelper);
        }

        /// <inheritdoc />
        protected override void ValidateAttributeValue(string name, string value)
        {
            HtmlUrlAttributeDataPolicy dataPolicy = string.Equals(name, "src", StringComparison.OrdinalIgnoreCase)
                ? HtmlUrlAttributeDataPolicy.Image
                : HtmlUrlAttributeDataPolicy.None;
            HtmlUrlAttributeValidator.Validate(name, value, dataPolicy);
        }

        /// <summary>
        ///     Sets the HTML <c>alt</c> attribute.
        /// </summary>
        /// <param name="alt">The value to assign to the HTML <c>alt</c> attribute.</param>
        /// <returns>The current <see cref="PB_ImgBuilder" /> instance for chaining.</returns>
        public PB_ImgBuilder SetAlt(string alt)
        {
            return SetAttribute("alt", alt);
        }

        /// <summary>
        ///     Sets the HTML <c>height</c> attribute.
        /// </summary>
        /// <param name="height">The value to assign to the HTML <c>height</c> attribute.</param>
        /// <returns>The current <see cref="PB_ImgBuilder" /> instance for chaining.</returns>
        public PB_ImgBuilder SetHeight(int height)
        {
            return SetAttribute("height", height);
        }

        /// <summary>
        ///     Sets the HTML <c>loading</c> attribute.
        /// </summary>
        /// <param name="loading">The value to assign to the HTML <c>loading</c> attribute.</param>
        /// <returns>The current <see cref="PB_ImgBuilder" /> instance for chaining.</returns>
        public PB_ImgBuilder SetLoading(string loading)
        {
            return SetAttribute("loading", loading);
        }

        /// <summary>
        ///     Sets the HTML <c>src</c> attribute.
        /// </summary>
        /// <param name="src">The value to assign to the HTML <c>src</c> attribute.</param>
        /// <returns>The current <see cref="PB_ImgBuilder" /> instance for chaining.</returns>
        public PB_ImgBuilder SetSrc(string src)
        {
            return SetAttribute("src", src);
        }

        /// <summary>
        ///     Sets the HTML <c>width</c> attribute.
        /// </summary>
        /// <param name="width">The value to assign to the HTML <c>width</c> attribute.</param>
        /// <returns>The current <see cref="PB_ImgBuilder" /> instance for chaining.</returns>
        public PB_ImgBuilder SetWidth(int width)
        {
            return SetAttribute("width", width);
        }

        #endregion
    }
}
