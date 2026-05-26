#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj PB_SourceBuilder.cs create at 2026/05/05 15:05:00
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Builds an HTML <c>source</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_SourceBuilder : HtmlVoidTagBuilder<PB_SourceBuilder>
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_SourceBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_SourceBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "source";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_SourceBuilder CreateInstance() => new(_textWriter, _htmlHelper);

        /// <summary>
        ///     Sets the HTML <c>media</c> attribute.
        /// </summary>
        /// <param name="media">The value to assign to the HTML <c>media</c> attribute.</param>
        /// <returns>The current <see cref="PB_SourceBuilder" /> instance for chaining.</returns>
        public PB_SourceBuilder SetMedia(string media) => SetAttribute("media", media);

        /// <summary>
        ///     Sets the HTML <c>sizes</c> attribute.
        /// </summary>
        /// <param name="sizes">The value to assign to the HTML <c>sizes</c> attribute.</param>
        /// <returns>The current <see cref="PB_SourceBuilder" /> instance for chaining.</returns>
        public PB_SourceBuilder SetSizes(string sizes) => SetAttribute("sizes", sizes);

        /// <summary>
        ///     Sets the HTML <c>src</c> attribute.
        /// </summary>
        /// <param name="src">The value to assign to the HTML <c>src</c> attribute.</param>
        /// <returns>The current <see cref="PB_SourceBuilder" /> instance for chaining.</returns>
        public PB_SourceBuilder SetSrc(string src) => SetAttribute("src", src);

        /// <summary>
        ///     Sets the src set value.
        /// </summary>
        /// <param name="srcset">The value to assign to the HTML <c>srcset</c> attribute.</param>
        /// <returns>The current <see cref="PB_SourceBuilder" /> instance for chaining.</returns>
        public PB_SourceBuilder SetSrcSet(string srcset) => SetAttribute("srcset", srcset);

        /// <summary>
        ///     Sets the HTML <c>type</c> attribute.
        /// </summary>
        /// <param name="type">The value to assign to the HTML <c>type</c> attribute.</param>
        /// <returns>The current <see cref="PB_SourceBuilder" /> instance for chaining.</returns>
        public PB_SourceBuilder SetType(string type) => SetAttribute("type", type);

        #endregion
    }
}