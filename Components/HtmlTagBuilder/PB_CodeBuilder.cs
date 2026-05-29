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
    ///     Builds an HTML <c>code</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_CodeBuilder : HtmlTagBuilder<PB_CodeBuilder>
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_CodeBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_CodeBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "code";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_CodeBuilder CreateInstance()
        {
            return new PB_CodeBuilder(_textWriter, _htmlHelper);
        }

        #endregion
    }
}