#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj PB_FontBuilder.cs create at 2026/05/05 15:05:00
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBPageBuilder
{
    [Obsolete("font is obsolete in HTML5.")]
    /// <summary>
    /// Builds an HTML <c>font</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_FontBuilder : HtmlTagBuilder<PB_FontBuilder>
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_FontBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_FontBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "font";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_FontBuilder CreateInstance() => new(_textWriter, _htmlHelper);

        /// <summary>
        ///     Sets the HTML <c>color</c> attribute.
        /// </summary>
        /// <param name="color">The value to assign to the HTML <c>color</c> attribute.</param>
        /// <returns>The current <see cref="PB_FontBuilder" /> instance for chaining.</returns>
        public PB_FontBuilder SetColor(string color) => SetAttribute("color", color);

        /// <summary>
        ///     Sets the HTML <c>face</c> attribute.
        /// </summary>
        /// <param name="face">The value to assign to the HTML <c>face</c> attribute.</param>
        /// <returns>The current <see cref="PB_FontBuilder" /> instance for chaining.</returns>
        public PB_FontBuilder SetFace(string face) => SetAttribute("face", face);

        /// <summary>
        ///     Sets the HTML <c>size</c> attribute.
        /// </summary>
        /// <param name="size">The value to assign to the HTML <c>size</c> attribute.</param>
        /// <returns>The current <see cref="PB_FontBuilder" /> instance for chaining.</returns>
        public PB_FontBuilder SetSize(string size) => SetAttribute("size", size);

        #endregion
    }
}