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
    ///     Builds an HTML <c>ul</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_UlBuilder : HtmlConstrainedTagBuilder<PB_UlBuilder>
    {
        #region Instance fields and properties

        /// <inheritdoc />
        protected override HtmlRenderContextKind ContextKind => HtmlRenderContextKind.UnorderedList;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_UlBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_UlBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "ul";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_UlBuilder CreateInstance()
        {
            return new PB_UlBuilder(_textWriter, _htmlHelper);
        }

        #endregion
    }
}