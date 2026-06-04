#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Builds an HTML <c>embed</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_EmbedBuilder : HtmlVoidTagBuilder<PB_EmbedBuilder>
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_EmbedBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_EmbedBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "embed";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_EmbedBuilder CreateInstance() => new(_textWriter, _htmlHelper);

        /// <summary>
        ///     Sets the HTML <c>height</c> attribute.
        /// </summary>
        /// <param name="height">The value to assign to the HTML <c>height</c> attribute.</param>
        /// <returns>The current <see cref="PB_EmbedBuilder" /> instance for chaining.</returns>
        public PB_EmbedBuilder SetHeight(int height) => SetAttribute("height", height);

        /// <summary>
        ///     Sets the HTML <c>src</c> attribute.
        /// </summary>
        /// <param name="src">The value to assign to the HTML <c>src</c> attribute.</param>
        /// <returns>The current <see cref="PB_EmbedBuilder" /> instance for chaining.</returns>
        public PB_EmbedBuilder SetSrc(string src) => SetAttribute("src", src);

        /// <summary>
        ///     Sets the HTML <c>type</c> attribute.
        /// </summary>
        /// <param name="type">The value to assign to the HTML <c>type</c> attribute.</param>
        /// <returns>The current <see cref="PB_EmbedBuilder" /> instance for chaining.</returns>
        public PB_EmbedBuilder SetType(string type) => SetAttribute("type", type);

        /// <summary>
        ///     Sets the HTML <c>width</c> attribute.
        /// </summary>
        /// <param name="width">The value to assign to the HTML <c>width</c> attribute.</param>
        /// <returns>The current <see cref="PB_EmbedBuilder" /> instance for chaining.</returns>
        public PB_EmbedBuilder SetWidth(int width) => SetAttribute("width", width);

        #endregion
    }
}