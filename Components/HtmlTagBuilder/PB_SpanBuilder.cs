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
    ///     Builds an HTML <c>span</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_SpanBuilder : HtmlTagBuilder<PB_SpanBuilder>, ICanUseCustomClasses
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_SpanBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_SpanBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "span";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_SpanBuilder CreateInstance()
        {
            return new PB_SpanBuilder(_textWriter, _htmlHelper);
        }

        #endregion
    }
}