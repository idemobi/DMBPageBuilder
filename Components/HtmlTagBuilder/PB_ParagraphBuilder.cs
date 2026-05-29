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
    ///     Builds an HTML <c>p</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_ParagraphBuilder : HtmlTagBuilder<PB_ParagraphBuilder>, ICanUseCustomClasses
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_ParagraphBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_ParagraphBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "p";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_ParagraphBuilder CreateInstance()
        {
            return new PB_ParagraphBuilder(_textWriter, _htmlHelper);
        }

        #endregion
    }
}