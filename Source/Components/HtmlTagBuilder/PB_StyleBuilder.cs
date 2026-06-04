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
    ///     Builds an HTML <c>style</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_StyleBuilder : HtmlTagBuilder<PB_StyleBuilder>
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_StyleBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_StyleBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "style";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_StyleBuilder CreateInstance() => new(_textWriter, _htmlHelper);

        /// <summary>
        ///     Sets the HTML <c>media</c> attribute.
        /// </summary>
        /// <param name="media">The value to assign to the HTML <c>media</c> attribute.</param>
        /// <returns>The current <see cref="PB_StyleBuilder" /> instance for chaining.</returns>
        public PB_StyleBuilder SetMedia(string media) => SetAttribute("media", media);

        #endregion
    }
}