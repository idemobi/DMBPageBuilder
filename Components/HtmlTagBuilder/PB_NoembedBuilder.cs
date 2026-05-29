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
    ///     Builds an HTML <c>noembed</c> element for PageBuilder Razor output.
    /// </summary>
    [Obsolete("noembed is obsolete.")]
    public sealed class PB_NoembedBuilder : HtmlTagBuilder<PB_NoembedBuilder>
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_NoembedBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_NoembedBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "noembed";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_NoembedBuilder CreateInstance() => new(_textWriter, _htmlHelper);

        #endregion
    }
}