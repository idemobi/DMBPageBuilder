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
    ///     Builds an HTML <c>ul</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_UnorderedListBuilder : HtmlConstrainedTagBuilder<PB_UnorderedListBuilder>
    {
        #region Instance fields and properties

        /// <inheritdoc />
        protected override HtmlRenderContextKind ContextKind => HtmlRenderContextKind.UnorderedList;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_UnorderedListBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_UnorderedListBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "ul";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_UnorderedListBuilder CreateInstance()
        {
            return new PB_UnorderedListBuilder(_textWriter, _htmlHelper);
        }

        #endregion
    }
}