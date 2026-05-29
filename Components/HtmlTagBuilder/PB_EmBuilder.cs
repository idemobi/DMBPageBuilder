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
    ///     Builds an HTML <c>em</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_EmBuilder : HtmlTagBuilder<PB_EmBuilder>
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_EmBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_EmBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "em";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_EmBuilder CreateInstance()
        {
            return new PB_EmBuilder(_textWriter, _htmlHelper);
        }

        #endregion
    }
}