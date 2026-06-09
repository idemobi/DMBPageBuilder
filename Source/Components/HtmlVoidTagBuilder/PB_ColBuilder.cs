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
    ///     Builds an HTML <c>col</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_ColBuilder : HtmlVoidTagBuilder<PB_ColBuilder>
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_ColBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_ColBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "col";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_ColBuilder CreateInstance()
        {
            return new PB_ColBuilder(_textWriter, _htmlHelper);
        }

        /// <summary>
        ///     Sets the HTML <c>span</c> attribute.
        /// </summary>
        /// <param name="span">The value to assign to the HTML <c>span</c> attribute.</param>
        /// <returns>The current <see cref="PB_ColBuilder" /> instance for chaining.</returns>
        public PB_ColBuilder SetSpan(int span)
        {
            if (span < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(span), span, "Span must be greater than or equal to 1.");
            }

            return SetAttribute("span", span);
        }

        #endregion
    }
}