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
    ///     Builds an HTML <c>ol</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_OrderedListBuilder : HtmlConstrainedTagBuilder<PB_OrderedListBuilder>
    {
        #region Instance fields and properties

        /// <inheritdoc />
        protected override HtmlRenderContextKind ContextKind => HtmlRenderContextKind.OrderedList;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_OrderedListBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_OrderedListBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "ol";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_OrderedListBuilder CreateInstance()
        {
            return new PB_OrderedListBuilder(_textWriter, _htmlHelper);
        }

        #endregion
    }
}