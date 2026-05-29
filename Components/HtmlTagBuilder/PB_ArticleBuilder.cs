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
    ///     Builds an HTML <c>article</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_ArticleBuilder : HtmlTagBuilder<PB_ArticleBuilder>
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_ArticleBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_ArticleBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "article";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_ArticleBuilder CreateInstance()
        {
            return new PB_ArticleBuilder(_textWriter, _htmlHelper);
        }

        #endregion
    }
}